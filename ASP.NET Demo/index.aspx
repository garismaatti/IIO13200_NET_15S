<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>To 22.10.2015</h1>
        <asp:HyperLink ID="Hyberlink" runat="server" NavigateUrl="~/Default.aspx">Eka sivuni</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/WinesOfWorld.aspx">Maailman Viinit</asp:HyperLink><br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/DemoxOy.aspx">Demox Oy</asp:HyperLink><br />
    </div>
    </form>
</body>
</html>
