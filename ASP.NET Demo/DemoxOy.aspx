<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DemoxOy.aspx.cs" Inherits="DemoxOy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Meidän janoiset asiakkaat</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblNotes" runat="server" Text=""></asp:Label>
    
        <asp:GridView ID="gvCustomers" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
