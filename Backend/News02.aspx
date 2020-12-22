<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="News02.aspx.cs" Inherits="tayanaBackend.Backend.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Back" runat="server" Text="回新聞列表" OnClick="Back_Click" class="btn btn-primary btn-fill"/>
    <ul>
        <li>
            <asp:Image ID="previewPicture" runat="server" ImageUrl='<%#Eval("previewPicture") %>' />
        </li>
        <li>
            <h3>
                <asp:Label ID="title" runat="server" Text="Label"></asp:Label>
            </h3>
        </li>
        <li>
            <asp:Label ID="article" runat="server" Text="Label"></asp:Label>
        </li>
        <li>
            <asp:Button ID="Edit" runat="server" Text="編輯" OnClick="Edit_Click" class="btn btn-info btn-fill"/><asp:Button ID="Delete" runat="server" Text="刪除" OnClick="Delete_Click" class="btn btn-danger btn-fill"/>
        </li>
    </ul>
</asp:Content>
