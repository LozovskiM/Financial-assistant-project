using Financial_assistant.Services;
using Financial_assistant.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;

namespace Financial_assistant.Attributes
{
    public class AuthAttribute : Attribute, IActionFilter
    {


        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            JWTService jwtService = new JWTService();
            var jwt = context.HttpContext.Request.Cookies["jwt"];
            try
            {
                var token = jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
            }
            catch
            {
                context.Result = new JsonResult(new { HttpStatusCode.Unauthorized });
            }
        }
    }
}
