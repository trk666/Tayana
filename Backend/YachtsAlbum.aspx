<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="YachtsAlbum.aspx.cs" Inherits="tayanaBackend.Backend.WebForm15" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="photo" runat="server">
        <h3>封面圖片修改</h3>
        <ul>
            <li>
                目前封面圖:
            </li>
            <li>
                <asp:Image ID="Image1" runat="server" />
            </li>
            <li>
                未選擇新圖片則沿用現有封面圖
                <asp:HiddenField ID="HiddenField3" runat="server" />
            </li>
        </ul>
        <asp:FileUpload ID="changePhoto" runat="server" />
    </div>
    <asp:Button ID="Button2" runat="server" Text="修改封面圖" OnClick="Button2_Click" class="btn btn-info btn-fill"/>
    
    

    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    
    

    <div>
        <h3>電子相簿修改</h3>
        <div>
            <asp:FileUpload ID="FileUpload" runat="server" AllowMultiple="True" />
        </div>
        <asp:Button ID="btnSave" runat="server" Text="新增到電子相簿" OnClick="btnSave_OnClick" class="btn btn-info btn-fill"/>
        <asp:Label runat="server" Text="Label" ID="Label1"></asp:Label>
    </div>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table class="table table-hover table-striped">
     
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("img") %>'></asp:Label>
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%#@"~\images\yachts\"+"s_"+Eval("img") %>' 
                                     CommandName="photo" CommandArgument='<%#Eval("photoID") %>'/>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="移除" 
                                CommandName="delete" CommandArgument='<%#Eval("photoID") %>' 
                                OnClientClick="javascript:if(!window.confirm('確定要移除此圖片?')) window.event.returnValue = false;" class="btn btn-danger btn-fill"/>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
