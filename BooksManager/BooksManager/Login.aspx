<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BooksManager.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td colspan="6" style="text-align: center; vertical-align: top"></td>
                </tr>
            </table>

        </div>
        <asp:Label ID="UserId" runat="server" Text="UserId"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Password" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="LogId" runat="server" OnClick="Button2_Click" Text="Login" />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Signup" />
        </p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
</body>
</html>
