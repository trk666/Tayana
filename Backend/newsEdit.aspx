<%@ Page Title="" Language="C#" ValidateRequest="False" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="tayanaBackend.Backend.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit News</h2>
    <ul>
        <li>目前圖片
            <asp:Label ID="oldPhoto" runat="server" Text="Label" Visible="False"></asp:Label></li>
        <li>
            <asp:Image ID="previewPicture" runat="server" ImageUrl='<%#Eval("previewPicture") %>' />
        </li>
        <li>
            <asp:FileUpload ID="previewPictureEdit" runat="server" />
        </li>
        <li>標題</li>
        <li>
            <asp:TextBox ID="title" runat="server" Width="380px"></asp:TextBox>
        </li>
        <li>預覽內容</li>
        <li>
            <asp:TextBox ID="previewArticle" runat="server" TextMode="MultiLine" Height="100px" Width="380px"></asp:TextBox>
        </li>
        <li>
            是否置頂
        </li>
        <li>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
            </asp:RadioButtonList>
        </li>
        <li>內容</li>
        <li>
            <asp:TextBox ID="article" runat="server" TextMode="MultiLine" Class="ckeditor"></asp:TextBox>
        </li>
        <li>
            <asp:Button ID="Submit" runat="server" Text="Submit Edit" OnClick="Submit_Click" class="btn btn-info btn-fill"/><asp:Button ID="NoEdit" runat="server" Text="Back to News list" OnClick="NoEdit_Click" class="btn btn-defult btn-fill"/>
        </li>
    </ul>
</asp:Content>
