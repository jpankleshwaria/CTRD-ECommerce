using Microsoft.AspNetCore.Mvc.Filters;
using Common.Domain.Models;

namespace CTRD.ECommerce.Api.Filters
{
    /// <summary>
    /// RegisterUserFilter
    /// </summary>
    public class SetUserInfoToRequestParamFilter : IActionFilter
    {
        /// <summary>
        /// Called after the action executes, before the action result.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutedContext" />.</param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //TODO
        }

        /// <summary>
        /// Called before the action executes, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext" />.</param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated && context.HttpContext.Request.Method != "GET")
            {
                string userName = context.HttpContext.User.Identity.Name;
                var actionParams = context.ActionArguments;
                foreach (var key in actionParams.Keys)
                {
                    dynamic dto;
                    actionParams.TryGetValue(key, out dto);
                    if (dto != null)
                    {
                        if (dto.GetType().GetProperty(nameof(Entity.CreatedBy)) != null || dto.GetType().GetProperty(nameof(Entity.LastModifiedBy)) != null)
                        {
                            if (dto.GetType().GetProperty(nameof(Entity.CreatedBy)) != null)
                                dto.CreatedBy = userName;
                            if (dto.GetType().GetProperty(nameof(Entity.LastModifiedBy)) != null)
                                dto.LastModifiedBy = userName;
                        }
                    }
                }
            }
        }
    }
}
