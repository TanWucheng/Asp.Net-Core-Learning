using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.NewtonsoftJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SimpleGraphQL.Interfaces;

namespace SimpleGraphQL.MiddleWare
{
    public class PersonGraphQlMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IPersonRepository _personRepository;

        public PersonGraphQlMiddleWare(RequestDelegate next, IPersonRepository personRepository)
        {
            _next = next;
            _personRepository = personRepository;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/graphql"))
            {
                using var stream = new StreamReader(httpContext.Request.Body);
                var query = await stream.ReadToEndAsync();
                if (!string.IsNullOrWhiteSpace(query))
                {
                    var schema = new Schema {Query = new PersonQuery(_personRepository)};
                    var result = await new DocumentExecuter().ExecuteAsync(options =>
                    {
                        options.Schema = schema;
                        options.Query = query;
                    }).ConfigureAwait(false);
                    await WriteResultAsync(httpContext, result);
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

        private static async Task WriteResultAsync(HttpContext httpContext, ExecutionResult executionResult)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode =
                executionResult.Errors?.Any() == true ? (int) HttpStatusCode.BadRequest : (int) HttpStatusCode.OK;
            var writer = new DocumentWriter(true);
            await writer.WriteAsync(httpContext.Response.Body, executionResult);
        }

        private static async Task ExecuteAsync(HttpContext context, ISchema schema)
        {
            GraphQLRequest request;
            using (var reader = new StreamReader(context.Request.Body))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var ser = new JsonSerializer();
                request = ser.Deserialize<GraphQLRequest>(jsonReader);
            }

            var executer = new DocumentExecuter();
            var result = await executer.ExecuteAsync(options =>
            {
                options.Schema = schema;
                if (request == null) return;
                options.Query = request.Query;
                options.OperationName = request.OperationName;
                options.Inputs = request.Variables.ToInputs();
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode =
                result.Errors?.Any() == true ? (int) HttpStatusCode.BadRequest : (int) HttpStatusCode.OK;

            var writer = new DocumentWriter();
            await writer.WriteAsync(context.Response.Body, result);
        }

        private class GraphQLRequest
        {
            public string OperationName { get; set; }
            public string Query { get; set; }
            public Newtonsoft.Json.Linq.JObject Variables { get; set; }
        }
    }
}