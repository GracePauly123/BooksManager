<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentBook.aspx.cs" Inherits="BooksManager.RentBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Taken Book List"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="Id,BookId" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowSorting="True">
            <Columns>
                    <asp:CommandField SelectText="Remove" ShowSelectButton="True" />
                 <asp:BoundField DataField="Id" HeaderText="Id" Visible="False" />
                <asp:BoundField DataField="BookId" HeaderText="BookId" Visible="False" />
                <asp:BoundField DataField="Title" HeaderText="Book Name" SortExpression="Title" />
                <asp:BoundField DataField="TakenDate" HeaderText="Time Taken" SortExpression="TakenDate" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label2" runat="server" Text="Books Available"></asp:Label>
        <asp:GridView ID="GridView2" runat="server" DataKeyNames="BookId,isAvailable" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" AllowSorting="True">
            <Columns>
                <asp:CommandField SelectText="Rent" ShowSelectButton="True" />
                <asp:BoundField DataField="BookId" HeaderText="BookId" Visible="False" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="AName" HeaderText="Author" SortExpression="AName" />
                <asp:BoundField DataField="isAvailable" HeaderText="isAvailable" SortExpression="isAvailable" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Manage Books" />
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <br />
    </form>
</body>
</html>
