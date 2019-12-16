using Common.Domain.Exceptions;
using CTRD.ECommerce.Web.ErrorObjectResult;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CTRD.ECommerce.Web.Helper
{
    public class ApiResponse
    {
        public ObjectResult GetObjectResult(HttpResponseMessage httpResponseMessage, string successMessage)
        {
            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(successMessage);
                case HttpStatusCode.BadRequest:
                    string responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    ValidationProblemDetails validationProblemDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent);
                    return new BadRequestObjectResult(validationProblemDetails.Errors.Values);
                case HttpStatusCode.InternalServerError:
                    JsonErrorResponse errorResponse = httpResponseMessage.Content.ReadAsAsync<JsonErrorResponse>().Result;
                    return new InternalServerErrorObjectResult(string.Join(",", errorResponse.Messages));
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(string.Join(",", "The Resource does not exist"));
                default:
                    return null;
            }
        }
    }
}
