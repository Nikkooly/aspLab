<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
            function sum() {
                let oReq = new XMLHttpRequest();
                let x = document.getElementById("x").value;
                let y = document.getElementById("y").value;
                let data = new FormData();
                data.append('x', x);
                data.append('y', y);
                let sUrl = "http://localhost:55689/Lab02/sum.KYA";
                oReq.open("POST", sUrl, true);
                oReq.send(data);
                oReq.onreadystatechange = function () {
                    if (oReq.readyState == 4 && oReq.status == 200) {
                        document.getElementById("z").value = oReq.response;
                    }
                }                
            }

           function mul() {
                let oReq = new XMLHttpRequest();
                let x = document.getElementById("x").value;
                let y = document.getElementById("y").value;
                let data = new FormData();
                data.append('x', x);
                data.append('y', y);
                let sUrl = "http://localhost:55689/Lab02/mul.KYA";
                oReq.open("POST", sUrl, true);
                oReq.send(data);
                oReq.onreadystatechange = function () {
                    if (oReq.readyState == 4 && oReq.status == 200) {
                        document.getElementById("z").value = oReq.response;
                    }
                }                
           }
            </script>
    <form runat="server">
                <div style="margin-top: 10px">
                    <asp:Button runat="server" Text="GetButton"  OnClick="GetButton_Click" Width="170px" />
                    <asp:Button runat="server" Text="PostButton" OnClick="PostButton_Click" Width="170px" />
                    <asp:Button runat="server" Text="PutButton"  OnClick="PutButton_Click" Width="170px" />
                    <asp:Button runat="server" Text="ErrorButton" OnClick="ErrorButton_Click" Width="170px" />
                </div>
                <div style="margin-top: 10px">
                    <asp:TextBox runat ="server" ID="x" ClientIDMode="Static" Width="170px" ></asp:TextBox>
                    <asp:TextBox runat ="server" ID="y" ClientIDMode="Static" Width="170px" ></asp:TextBox>
                    <asp:TextBox runat ="server" ID="z" ReadOnly="true" ClientIDMode="Static" Width="170px" ></asp:TextBox>                 
                    <input type="button" value="SumButton" onclick="sum()" style="width: 170px" />
                </div>
                <div style="margin-top: 10px">
                    <asp:Button runat="server" Text="HtmlButton" OnClick="HtmlButton_Click" Width="170px" />
                    <input type="button" value="MulButton" onclick="mul()" style="width: 170px" />
                </div>
           </form>
           <form action="http://localhost:55689/Lab02/mul.KYA?X=2&Y=40" method="post" style="margin-top: 10px">
               <input type="submit" value="MulButton" style="width: 170px" />
           </form>
</asp:Content>
