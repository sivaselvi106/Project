<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionMgmt.aspx.cs" Inherits="WebApplication1.SessionMgmt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="CountTextBox" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
			<asp:Button ID="CountButton" runat="server" OnClick="Button1_Click" Text="Submit" Width="200px" />
        </div>
    </form>
</body>
</html>
