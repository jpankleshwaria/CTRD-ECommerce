﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using Common.Domain.Exceptions;

namespace CTRD.ECommerce.Api.Exceptions
{
    /// <summary>
    /// Http Global Exception Filter, for exception handling
    /// </summary>
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment env;

        private readonly ILogger<HttpGlobalExceptionFilter> logger;

        /// <summary>
        /// Constructor of HttpGlobalExceptionFilter class
        /// </summary>
        public HttpGlobalExceptionFilter(IHostingEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            this.env = env;
            this.logger = logger;
        }

        /// <summary>
        /// Handle event of exception
        /// </summary>
        public void OnException(ExceptionContext context)
        {
            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);

            if (context.Exception.GetType() == typeof(DomainException))
            {
                var problemDetails = new ValidationProblemDetails()
                {
                    Instance = context.HttpContext.Request.Path,
                    Status = StatusCodes.Status400BadRequest,
                    Detail = "Please refer to the errors property for additional details."
                };
                problemDetails.Errors.Add("DomainValidations", ((FluentValidation.ValidationException)context.Exception.InnerException).Errors.Select(c => c.ErrorMessage).ToArray());

                context.Result = new BadRequestObjectResult(problemDetails);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { "An error occur.Try it again." },
                    DeveloperMessage = context.Exception
                };

                if (env.IsDevelopment())
                {
                    json.DeveloperMessage = context.Exception;
                }

                // Result asigned to a result object but in destiny the response is empty. This is a known bug of .net core 1.1
                // It will be fixed in .net core 1.1.2. See https://github.com/aspnet/Mvc/issues/5594 for more information
                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
        }

        private class JsonErrorResponse
        {
            public string[] Messages { get; set; }

            public object DeveloperMessage { get; set; }
        }

        /// <summary>
        /// Error object for 500 status code
        /// </summary>
        public class InternalServerErrorObjectResult : ObjectResult
        {
            /// <summary>
            /// Constructor of InternalServerErrorObjectResult class
            /// </summary>
            public InternalServerErrorObjectResult(object error)
                : base(error)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
