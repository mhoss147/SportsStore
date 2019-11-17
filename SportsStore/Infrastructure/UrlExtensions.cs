using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Infrastructure
{
    public static class UrlExtensions
    {
        // this method will bring back to previous page to continue shopping 
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue
            // if has value
            ? $"{request.Path}{request.QueryString}"
            // if has no value
            : request.Path.ToString();
    }
}
