using Microsoft.AspNetCore.Mvc.Filters;

namespace MVCKisiselWebsite.Filters
{
    public class LogFilter : ExceptionFilterAttribute, IActionFilter 
    {

        public override void OnException(ExceptionContext context)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now}\t HATA \t {context.HttpContext.Request.Path} \t {context.Exception.Message} \n");
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //action çalıştıktan sonra 
            File.AppendAllText("log.txt", $"{DateTime.Now}\t Çıkış \t {context.HttpContext.Request.Path} \n");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //henüz action başlamadan (session var mı kontrolü)
            //context nesnesinin alabileceği parametreler  
            //string logData = $"[{DateTime.Now}]: { context.HttpContext.Request.Path}\n"; 
            //File.AppendAllText("log.txt", logData);
            File.AppendAllText("log.txt", $"{DateTime.Now}\tGiriş\t{context.HttpContext.Request.Path}\n");

        }
    }
}
