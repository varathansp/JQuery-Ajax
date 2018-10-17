<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AutocompleteTextbox.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>--%>
    <script src="Scripts/jquery-3.3.1.min.js" type="text/javascript"></script>
    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>--%>
    <script src="jquery-ui.js" type="text/javascript"></script>
    <link href="jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {

            $('#txtName').autocomplete({
                source: 'EmployeeHandler.ashx'
                //source: ["Choice1", "Choice2"] 
                //source:  [ { label: "Choice1", value: "value1" }, ... ]
            });
        });
    </script>
</head>
<body style="font-family: Arial">
    <form id="form1" runat="server">
        Student Name :
        <asp:TextBox ID="txtName" runat="server">
        </asp:TextBox>
    </form>
</body>
</html>
