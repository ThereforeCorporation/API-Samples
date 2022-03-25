<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="TheAPIWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Retrieve By Document Number</title>
</head>
<body>
    <form id="WebSample" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Enter Document Number to View:"></asp:Label>
        <asp:TextBox ID="txtDocNo" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnView" runat="server" OnClick="btnView_Click" Text="View Now" /></div>
    </form>
</body>
</html>
