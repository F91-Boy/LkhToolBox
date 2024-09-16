﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LkhToolBox.Api.Auth
{
    public class ApiKeyAuthFilter : IAuthorizationFilter
    {
        private readonly IConfiguration _configuration;

        public ApiKeyAuthFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(AuthConstants.ApiKeyHeaderName,
                out var extractedApiKey))
            {
                context.Result = new UnauthorizedObjectResult("Api Key missing (密钥缺失)");
            }

            var apiKey = _configuration["ApiKey"]!;
            if (apiKey != extractedApiKey)
            {
                context.Result = new UnauthorizedObjectResult("Invalid Api Key (密钥无效)");
            }
        }
    }
}
