<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Accordion.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="Scripts/jquery-3.3.1.js" type="text/javascript"></script>
    <script src="jquery-ui.js" type="text/javascript"></script>
    <link href="jquery-ui.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                url: 'CountryService.asmx/GetCountries',
                method: 'post',
                contentType: 'application/json;charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    var htmlString = '';
                    $(data.d).each(function (index, country) {
                        htmlString += '<h3>' + country.Name + '</h3><div>'
                            + country.CountryDescription + '</div>';
                    });
                    $('#accordion').html(htmlString).accordion({
                        collapsible: true,
                        active: 2
                    });
                },
                error: function (err) { alert(err.responseText); alert(err.status); alert(err.statusText); }
            });
        });
    </script>
</head>
<body style="font-family: Arial">
    <form id="form1" runat="server">
        <div id="accordion" style="width: 600px">
        </div>
    </form>
</body>
</html>
