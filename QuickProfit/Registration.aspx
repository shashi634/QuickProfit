<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="QuickProfit.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Registration Page | Quick Profit</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" 
        integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous" />
    <link href="Static/custom.css" rel="stylesheet"  />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login">
            <h2 class="form-signin-heading">Registration</h2>
            <label for="txtname">
                What we can call you
            </label>
            <asp:TextBox  ID="txtname" runat="server" CssClass="form-control" placeholder="Enter Full Name" required></asp:TextBox>
            <br />
            <label for="txtUsername">
                Make Unique Name
            </label>
            <asp:TextBox  ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username" required></asp:TextBox>
            <br />
            <label for="txtUsername">
                Create Strong Password
            </label>
            <asp:TextBox  ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control" placeholder="Enter Password" required></asp:TextBox>
            <br />
            <label for="txtEmailId">You must have an email Id</label>
            <asp:TextBox  ID="txtEmailId" runat="server" TextMode="Email" CssClass="form-control" placeholder="Enter Email Id" required></asp:TextBox>
            <br />
            <label for="txtPhone">You must have an Mobile Number</label>
            <asp:TextBox  ID="txtPhone" runat="server" TextMode="Phone" CssClass="form-control" placeholder="Enter Phone No." required></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" Text="Signup" runat="server"  Class="btn btn-primary" OnClick="BtnLogin_Click" />
            <a class="loginText" href="/">Already have account?</a>
            <br />
            <br />
            <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
                <strong>Error!</strong>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </div>
             <div id="divMsgSuccess" runat="server" visible="false" class="alert alert-success">
                <strong>Success!</strong>
                <asp:Label ID="lblMsgSuccess" runat="server"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
