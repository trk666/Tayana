<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="AdminstratorEdit.aspx.cs" Inherits="tayanaBackend.Backend.WebForm14" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <ul class="col">
                <li>
                    <h4>新增管理員</h4>
                </li>
                <li>頭像<asp:HiddenField ID="HiddenField1" runat="server" />
                    <p>
                        <asp:Image ID="Photo" runat="server" />
                    </p>
                    <p>
                        <asp:FileUpload ID="FileUpload1" runat="server" /><asp:Label ID="PictureFormatError" runat="server" Text="圖片格式錯誤" Visible="False"></asp:Label>
                        <br/>
                        此欄位留白會沿用舊圖片
                    </p>
                </li>
                <li>帳號:
                    <p>
                        <asp:TextBox ID="account" runat="server"></asp:TextBox>
                    </p>
                </li>
                <li>密碼:
                    <p>
                        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    </p>
                </li>
                <li>暱稱:
                    <p>
                        <asp:TextBox ID="userName" runat="server"></asp:TextBox>
                    </p>
                </li>
                <li>Email:
                    <p>
                        <asp:TextBox ID="email" runat="server"></asp:TextBox>
                    </p>
                </li>
                <li>
                    <asp:CheckBoxList ID="authoritylist" runat="server">
                        <asp:ListItem Text="船隻編輯" Value="01"></asp:ListItem>
                        <asp:ListItem Text="新聞編輯" Value="02"></asp:ListItem>
                        <asp:ListItem Text="經銷商管理" Value="03"></asp:ListItem>
                        <asp:ListItem Text="管理者編輯" Value="04"></asp:ListItem>
                    </asp:CheckBoxList>
                    <input id="CheckAll" type="checkbox" />全選
                </li>
                <li>
                    <asp:Label ID="authority" runat="server" Text="Label" Visible="False"></asp:Label>
                </li>
            </ul>
        </div>
    </div>
    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" class="btn btn-info btn-fill"/>
    <script src="../javascript/check.js"></script>
</asp:Content>
