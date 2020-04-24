using System;
using System.Web;

namespace lab1a.handlers
{
    public class SUMHandler : IHttpHandler
    {
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            if (request.Params.Count >= 2)
            {
                int x = 0, y = 0;
                if (Int32.TryParse(request.Params[0], out x) && int.TryParse(request.Params[1], out y))
                {
                    response.Write(x + y);
                }
                else { response.Write("Not number"); }
            }
            else { response.Write("Put 2 params"); }
        }
    }
}
