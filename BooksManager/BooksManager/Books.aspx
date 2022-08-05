<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="BooksManager.Books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
      <form id="form1" runat="server">
        <div>
    <asp:GridView ID="GridView11" runat="server" ForeColor="#333333" GridLines="None" DataKeyNames="Id" OnSelectedIndexChanged="GridView11_SelectedIndexChanged"
        
        OnRowCancelingEdit="GridView11_RowCancelingEdit" OnRowEditing="GridView11_RowEditing" OnRowUpdating="GridView11_RowUpdating" AutoGenerateColumns="False" OnRowDeleting="GridView11_RowDeleting" AllowPaging="True" OnPageIndexChanging="GridView11_PageIndexChanging" PageSize="1" AllowSorting="True" OnSorting="GridView11_Sorting">

        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />

        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />

        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />

        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

        <AlternatingRowStyle BackColor="White" />

        <Columns>

            <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />

            <asp:TemplateField HeaderText="Id" SortExpression="Id">

              

                <ItemTemplate>

                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Id") %>'></asp:Label>

                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Book Name" SortExpression="Title">

               

                <ItemTemplate>

                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Title") %>'></asp:Label>

                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Author" SortExpression="Author">

              

                <ItemTemplate>

                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Author") %>'></asp:Label>

                </ItemTemplate>

            </asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">

                <EditItemTemplate>

                    <asp:TextBox ID="txtqty" runat="server" Text='<%# Bind("Quantity") %>'></asp:TextBox>

                </EditItemTemplate>

                <ItemTemplate>

                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Quantity") %>'></asp:Label>

                </ItemTemplate>

            </asp:TemplateField>


             <asp:TemplateField HeaderText="Available Quantity" SortExpression="AvailableQty">


                <ItemTemplate>

                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("AvailableQty") %>'></asp:Label>

                </ItemTemplate>

            </asp:TemplateField>


            <asp:TemplateField HeaderText="isAvailable" SortExpression="isAvailable">

               

                <ItemTemplate>

                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("isAvailable") %>'></asp:Label>

                </ItemTemplate>

            </asp:TemplateField>

        </Columns>

    </asp:GridView>
  
        </div>
          
          <div>
              <asp:Label ID="Label6" runat="server" Text="Book Name"></asp:Label>
              <asp:TextBox ID="txtBook" runat="server"></asp:TextBox>

              <asp:Label ID="Label8" runat="server" Text="Author"></asp:Label>
              <asp:DropDownList ID="ddAuthor" runat="server" DataTextField="AName" DataValueField="AuthorID" AppendDataBoundItems="true"></asp:DropDownList>

              <asp:Label ID="Label7" runat="server" Text="Quantity"></asp:Label>
              <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>


              <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add new Book" />
              <br />
              <br />
          </div>
          <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Rent Books" />
    </form>
</body>
</html>
