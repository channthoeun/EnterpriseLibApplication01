<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeByDepartment.aspx.cs" Inherits="EnterpriseLibApplication01.EmployeeByDepartment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Department: "></asp:Label>
        <asp:DropDownList ID="ddlDepartment" runat="server"></asp:DropDownList>
        <asp:Button ID="btnListEmployee" runat="server" Text="List Employee" OnClick="btnListEmployee_Click"/>
        <br />
        <asp:GridView ID="grvEmployee" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
