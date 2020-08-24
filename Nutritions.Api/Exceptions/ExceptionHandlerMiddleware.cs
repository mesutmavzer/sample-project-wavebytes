using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutritions.Api.Exceptions
{
    public sealed class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (ApiException e)
			{
				context.Response.StatusCode = (int)e.StatusCode;
				context.Response.ContentType = "application/json";
				await context.Response.WriteAsync(e.ToString());
			}
        }
    }
}
