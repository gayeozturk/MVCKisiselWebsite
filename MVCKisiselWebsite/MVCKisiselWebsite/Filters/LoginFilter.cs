using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCKisiselWebsite.Filters
{
    public class LoginFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //gff
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.Controller as Controller;
            //Sessionlar kontrol edilecek 
            if (!context.HttpContext.Session.Keys.Contains("username"))
            {
                context.Result = controller.RedirectToAction("Login", "Admin");
            }
        }
        }
    }

