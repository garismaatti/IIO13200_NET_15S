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
        <asp:Label ID="lblHello" runat="server" Text="Label">Terve, ole hyvä annan nimesi:</asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:Button ID="btnFire" Text="Paina tästä" runat="server" OnClick="btnFire_Click" />
    </div>
    </form>
</body>
</html>
