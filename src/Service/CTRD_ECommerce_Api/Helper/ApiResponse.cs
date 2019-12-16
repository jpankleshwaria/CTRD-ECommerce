using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using Common.Domain.Exceptions;
using CTRD.ECommerce.Api.Filters;

namespace CTRD.ECommerce.Api.Helper
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
                    if (responseContent.ToLower().Contains("domainvalidations"))
                    {
                        ValidationProblemDetails validationProblemDetails = JsonConvert.DeserializeObject<ValidationProblemDetails>(responseContent);
                        return new BadRequestObjectResult(validationProblemDetails.Errors.Values);
                    }
                    return new BadRequestObjectResult(new string[] { responseContent });
                case HttpStatusCode.InternalServerError:
                    JsonErrorResponse errorResponse = new JsonErrorResponse();
                    //JsonErrorResponse errorResponse = httpResponseMessage.Content.ReadAsAsync<JsonErrorResponse>().Result;
                    return new InternalServerErrorObjectResult(string.Join(",", errorResponse.Messages));
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(string.Join(",", "The Resource does not exist"));
                default:
                    return null;
            }
        }

    }
}
