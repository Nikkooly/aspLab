using System;
using System.Web;

namespace lab1a.handlers
{
    public class POSTHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            if (request.QueryString.Count == 2)
            {
                string param1 = request.QueryString[0];
                string param2 = request.QueryString[1];
                response.ContentType = "text/plain";
                response.Write($"POST-Http-YNS: ParmA: {param1}, ParmB: {param2}");
            }
            else 
            { 
                response.Write("Post HttpHandler Error");
            }
        }

        public bool IsReusable => false;
    }
}
