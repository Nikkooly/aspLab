<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="lab1b.Client" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        var ws;
        function exe_start() {
            if (ws == null) {
                ws = new WebSocket('ws://localhost:56267/websocket');
                ws.onopen = function ()
                {
                    ws.send('Connecting');
                }
                ws.onclose = function (s)
                {
                    console.log('onclose' + s);
                }
                ws.onmessage = function (evt)
                {
                    ta.innerHTML += '\n' + evt.data;
                }
            }
        }

        function exe_stop() {
            ws.close(3001, ' stopapplication');
            ws = null;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <h1>Web Sockets</h1>
        <br>
    <div>
        <input type="button" value="Пуск" id="bstart" onclick="exe_start()"/>
        <input type="button" value="Стоп" id="bstop" onclick="exe_stop()" />
    </div>
        <br>
    <div>
        <textarea id="ta" rows="20" cols="25" style="text-align:center" readonly="readonly">
        </textarea>
    </div>
    </form>
</body>
</html>
