<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YachtsPhoto.aspx.cs" Inherits="tayanaBackend.Backend.WebForm16" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>看原圖</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8" />
    <link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png">
    <link rel="icon" type="image/png" href="assets/img/favicon.ico">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />

    <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no' name='viewport' />
    <!--     Fonts and icons     -->
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700,200" rel="stylesheet" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" />
    <!-- CSS Files -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/light-bootstrap-dashboard.css?v=2.0.0 " rel="stylesheet" />
    <!-- CSS Just for demo purpose, don't include it in your project -->
    <link href="assets/css/demo.css" rel="stylesheet" />
    
    <script src="../Scripts/ckeditor/ckeditor.js"></script><%--ck editor--%>
    <style type="text/css">
        ul {
            list-style: none;
            padding: 0;
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <ul>
            <li>
                <asp:Button ID="GoAlbum" runat="server" Text="返回相簿" OnClick="GoAlbum_Click" class="table table-primary table-striped"/>
                <asp:Button ID="DeletePhoto" runat="server" Text="移除圖片" OnClick="DeletePhoto_Click" 
                            OnClientClick="javascript:if(!window.confirm('移除並返回相簿?')) window.event.returnValue = false;" class="table table-danger table-striped"/>
            </li>
            <li>
                <asp:Image ID="Image1" runat="server"/>
            </li>
        </ul>
    </form>
</body>
</html>
