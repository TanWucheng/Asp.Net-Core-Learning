using System;
using System.Net.Http;
using IdentityModel.Client;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GetToken();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        private static async void GetToken()
        {
            var httpClient = new HttpClient();

            var disco = await httpClient.GetDiscoveryDocumentAsync("https://localhost:5001");
            if (disco.IsError)
            {
                Console.WriteLine("Discover Document Error:");
                Console.WriteLine(disco.Error);
                return;
            }

            var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "clientbook",
                ClientSecret = "secretbook",
                Scope = "apibook"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine("Get Token Error:");
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine("Token Response:");
            Console.WriteLine(tokenResponse.Json);

            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var apiResponse = await apiClient.GetAsync("https://localhost:5003/identity");
            if (!apiResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Api Response Error Code:");
                Console.WriteLine(apiResponse.StatusCode);
            }
            else
            {
                var content = await apiResponse.Content.ReadAsStringAsync();
                Console.WriteLine("Api Response Content String:");
                Console.WriteLine(content);
            }
        }
    }
}