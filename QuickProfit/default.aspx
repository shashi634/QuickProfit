<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="QuickProfit._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Landing Page | Quick Profit</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" 
        integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
    <link href="Static/custom.css" rel="stylesheet"  />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <h2 class="form-signin-heading">
                Login</h2>
            <label for="txtUsername">
                Username</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username"
                required ></asp:TextBox>
            <br />
            <label for="txtPassword">
                Password</label>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control"
                placeholder="Enter Password" required></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" Text="Login" runat="server"  Class="btn btn-primary" OnClick="btnLogin_Click" />
            <a class="loginText" href="Registration.aspx">New User</a>
            <a class="loginText" href="Registration.aspx">Forgot Credential</a>
            <br />
            <br />
            <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
                <strong>Error!</strong>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
