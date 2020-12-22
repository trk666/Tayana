<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="News01.aspx.cs" Inherits="tayanaBackend.Backend.WebForm4" %>

<%@ Register Src="~/Usercontrol/Pagination.ascx" TagPrefix="uc1" TagName="Pagination" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Usercontrol/pagination.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>News & Events</h2>
    <asp:Button ID="addNews" runat="server" Text="Add News" OnClick="addNews_Click" class="btn btn-info btn-fill"/>
    <div>
        <asp:TextBox ID="keyword" runat="server" placeholder="標題關鍵字"></asp:TextBox>
        <asp:Button ID="searchText" runat="server" Text="搜尋" OnClick="search_Click" />
        <asp:Button ID="clear" runat="server" Text="清空搜尋" OnClick="clear_Click" />
    </div>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table class="table table-hover table-striped">

        </HeaderTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%#gettop(Eval("gettop")) %>'></asp:Label>
                </td>
                <td>
                    <div>
                        <asp:Image ID="previewPicture" runat="server" ImageUrl='<%#@"https://localhost:44358/images/ckf/previewNews/"+"s_"+Eval("previewPicture") %>' />
                    </div>

                </td>
                <td>
                    <ul>
                        <li>
                            <asp:Label ID="date" runat="server" Text='<%#Eval("date","{0:yyyy-MM-dd}")%>'></asp:Label>
                        </li>
                        <li>
                            
                                <asp:HyperLink ID="title" runat="server" Text='<%#Eval("title")%>' NavigateUrl='<%#"News02.aspx?id="+Eval("id") %>'></asp:HyperLink>
                            
                        </li>
                        <li>
                            <asp:Label ID="previewArticle" runat="server" Text='<%#Eval("previewArticle")%>'></asp:Label>
                        </li>

                    </ul>
                </td>
                <td>

                    <asp:Button ID="edit" runat="server" Text="Edit" CommandName="edit" CommandArgument='<%# Eval("id") %>' class="btn btn-primary btn-fill"/>

                </td>
                <td>
                    <asp:Button ID="delete" runat="server" Text="Delete" CommandName="delete" CommandArgument='<%# Eval("id") %>' class="btn btn-danger btn-fill" OnClientClick="javascript:if(!window.confirm('確定要刪除?')) window.event.returnValue = false;" />

                </td>
            </tr>

        </ItemTemplate>

        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <uc1:Pagination runat="server" ID="Pagination" />
</asp:Content>
