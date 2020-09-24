using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace lab1b
{
    public class Server : IHttpHandler
    {
        WebSocket socket;

        bool IHttpHandler.IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(WebSocketRequest);
            }
        }

        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            socket = context.WebSocket;
            string s = await Receive();
            await Send(s);
            while (socket.State == WebSocketState.Open)
            {
                System.Threading.Thread.Sleep(2000);
                await Send("[" + DateTime.Now.ToLongTimeString() + "]");
            }
        }

        private async Task Send(string s)
        {
            var sendbuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes("Ответ: " + s));
            await socket.SendAsync(sendbuffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task<string> Receive()
        {
            string rc = null;
            var buffer = new ArraySegment<byte>(new byte[512]);
            var result = await socket.ReceiveAsync(buffer, CancellationToken.None);
            rc = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
            return rc;
        }

    }
}