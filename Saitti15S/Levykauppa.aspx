<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Levykauppa.aspx.cs" Inherits="DemoSQL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SqlDataSource testi</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--1. DataSourcen määrittely -->
        <asp:SqlDataSource ID="srcMuuvit" 
            ConnectionString="<%$ ConnectionStrings:Muuvit %>"
            SelectCommand="SELECT title, director, year FROM movies"
            runat="server"></asp:SqlDataSource>
    <!--1.1 DataSourcen määrittely -->
        <asp:XmlDataSource ID="srcLevyt" 
            DataFile="~/App_Code/LevykauppaX.xml"
            XPath="Records/genre[@name='Pop']/record"
            runat="server"></asp:XmlDataSource>
    <!--2. DataKontrolli data esittämistä varten-->
        <h2>Kinnfino ylpeänä esittää </h2>
        <asp:GridView ID="gvMuuvit"
            DataSourceID="srcMuuvit" 
            runat="server"></asp:GridView>
        <!--2b. Vaihtoehtoinen tapa data esittämistä varten-->
        <h2>Kinnfino toissen kerran ylpeänä esittää esittää Repeatter-lla </h2>
        <asp:Repeater ID="Repeater1" DataSourceID="srcMuuvit" runat="server">
            <HeaderTemplate>
                <table border="1">
                    <tr>
                        <td>Nimi</td>
                        <td>Maa</td>
                        <td>Ohjaaja</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("title") %></td>
                    <td><%# Eval("director") %></td>
                    <td><%# Eval("year") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate></table></FooterTemplate>
        </asp:Repeater>
         <!--2c. Vaihtoehtoinen tapa data esittämistä varten-->
        <h2>Kinnfino koomannen kerran ylpeänä esittää esittää Repeatter-lla </h2>
        <asp:Repeater ID="Repeater2" DataSourceID="srcMuuvit" runat="server">
             <ItemTemplate>
                 <b><%# Eval("title") %></b>
                 <%# Eval("director") %>
                 <%# Eval("year") %>
                 <br />
            </ItemTemplate>
        </asp:Repeater>
    <h2>Levykaupan erikoistarjoukset</h2>
        <asp:Repeater ID="Repeater3" DataSourceID="srcLevyt" runat="server">
             <ItemTemplate>
                 <b><%# Eval("Artist") %></b> present 
                 <%# Eval("Title") %>
                 <img alt="Kansikuva" src='<%#"Images/" + Eval("ISBN") + ".jpg"%>'" />
                 <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
