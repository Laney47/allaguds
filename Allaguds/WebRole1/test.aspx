<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebRole1.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        username:
        <asp:TextBox ID="userBox" runat="server" OnTextChanged="TextBox1_TextChanged" style="height: 22px"></asp:TextBox>
        <br />
        password: <asp:TextBox ID="passBox" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign in" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
