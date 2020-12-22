<%@ Page Title="" Language="C#" ValidateRequest="False" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="NewsAdd.aspx.cs" Inherits="tayanaBackend.Backend.WebForm2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul>
        <li>
            <h2>Add news</h2>
        </li>
        <li>
            標題
        </li>
        <li>
            <asp:TextBox ID="title" runat="server" Width="380px"></asp:TextBox>

        </li>
        <li>
           預覽內容
        </li>
        <li>
            <asp:TextBox ID="previewArticle" runat="server" TextMode="MultiLine" Height="100px" Width="380px"></asp:TextBox>
        </li>
        <li>
          預覽圖片
        </li>
        <li>
            <asp:FileUpload ID="previewPicture" runat="server" />
        </li>
        <li>預設圖片:</li>
        <li>
            <img src="../images/pit008.jpg" />
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
        <li>
            內容
        </li>
        <li>
            <asp:TextBox ID="article" runat="server" TextMode="MultiLine" Class="ckeditor"></asp:TextBox>
        </li>
    </ul>
    <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" class="btn btn-info btn-fill"/><input id="Reset1" type="reset" value="Reset" class="btn btn-defult btn-fill"/>
</asp:Content>
