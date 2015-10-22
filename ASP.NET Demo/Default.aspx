<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Hello Universe</h1>
        <asp:Label ID="lblHello" runat="server" Text="Terve anna nimesi"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Button ID="btnFire" runat="server" Text="Paina tästä" OnClick="btnFire_Click" />
    </div>
    </form>
</body>
</html>
