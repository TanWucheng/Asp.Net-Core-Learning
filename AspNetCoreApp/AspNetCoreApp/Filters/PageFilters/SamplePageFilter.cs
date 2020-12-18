using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNetCoreApp.Filters.PageFilters
{
    public class SamplePageFilter : IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            Console.WriteLine("同步OnPageHandlerExecuted调用");
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Console.WriteLine("同步OnPageHandlerExecuting调用");
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            Console.WriteLine("同步OnPageHandlerSelected调用");
        }
    }
}