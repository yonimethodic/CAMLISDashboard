<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QR.aspx.cs" Inherits="QR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="ART Number:"></asp:Label>        
        <asp:TextBox ID="txtArt" runat="server"></asp:TextBox>
        <br />
        
        <asp:Label ID="Label2" runat="server" Text="Lab Number:"></asp:Label>        
        <asp:TextBox ID="txtLabNum" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="Label3" runat="server" Text="Facility ART Code:"></asp:Label>        
        <asp:TextBox ID="txtArtSiteCode" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

        <asp:Image ID="Image1" runat="server" />
        <%--<asp:PlaceHolder ID="Image1" runat="server" />--%>

    </div>
    </form>
</body>
</html>
