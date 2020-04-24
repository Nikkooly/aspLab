using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab1a.handlers
{
    public class YNSHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            if (request.HttpMethod == "GET")
            {
                response.WriteFile("Task5.html");
            }
            if (request.HttpMethod == "POST")
            {
                int x = Convert.ToInt32(request.Params["x"]);
                int y = Convert.ToInt32(request.Params["y"]);
                int mul = x * y;
                response.Write($"{mul}");
            }
        }
    }
}