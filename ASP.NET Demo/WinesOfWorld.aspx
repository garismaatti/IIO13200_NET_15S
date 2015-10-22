<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WinesOfWorld.aspx.cs" Inherits="WinesOfWorld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wines of World</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Viinit</h1>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country" />
                <asp:BoundField DataField="DeliverID" HeaderText="DeliverID" SortExpression="DeliverID" />
                <asp:BoundField DataField="Year" HeaderText="Year" SortExpression="Year" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="wineType" HeaderText="wineType" SortExpression="wineType" />
                <asp:BoundField DataField="InStock" HeaderText="InStock" SortExpression="InStock" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ViiniConnectionString1 %>" DeleteCommand="DELETE FROM [wine] WHERE [ID] = @ID" InsertCommand="INSERT INTO [wine] ([Name], [Country], [DeliverID], [Year], [Price], [wineType], [InStock]) VALUES (@Name, @Country, @DeliverID, @Year, @Price, @wineType, @InStock)" ProviderName="<%$ ConnectionStrings:ViiniConnectionString1.ProviderName %>" SelectCommand="SELECT [ID], [Name], [Country], [DeliverID], [Year], [Price], [wineType], [InStock] FROM [wine]" UpdateCommand="UPDATE [wine] SET [Name] = @Name, [Country] = @Country, [DeliverID] = @DeliverID, [Year] = @Year, [Price] = @Price, [wineType] = @wineType, [InStock] = @InStock WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="DeliverID" Type="Int32" />
                <asp:Parameter Name="Year" Type="Int16" />
                <asp:Parameter Name="Price" Type="Double" />
                <asp:Parameter Name="wineType" Type="String" />
                <asp:Parameter Name="InStock" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="DeliverID" Type="Int32" />
                <asp:Parameter Name="Year" Type="Int16" />
                <asp:Parameter Name="Price" Type="Double" />
                <asp:Parameter Name="wineType" Type="String" />
                <asp:Parameter Name="InStock" Type="Int32" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
