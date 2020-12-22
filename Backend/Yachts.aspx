<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="Yachts.aspx.cs" Inherits="tayanaBackend.Backend.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>船隻總表</h2>
    <asp:Button ID="Add" runat="server" Text="新增型號" OnClick="Add_OnClick" Height="37px" class="btn btn-primary btn-fill"/>
    <asp:Button ID="Button1" runat="server" Text="修改刪除型號" OnClick="Button1_Click" class="btn btn-primary btn-fill"/>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <table class="table table-hover table-striped">
               
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="Name" runat="server" Text='<%#Eval("type") %>'></asp:Label>

                </td>
                <td>
                    <asp:Label ID="Type" runat="server" Text='<%#Eval("serial") %>'></asp:Label>

                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" ImageUrl='<%#@"~\images\yachts\"+"s_"+Eval("photo") %>'/>
                </td>
                <td>
                    <asp:Label ID="Newest" runat="server" Text='<%#Eval("status") %>'></asp:Label>

                </td>
                <td>
                    <asp:Button ID="Button4" runat="server" Text="編輯" 
                                CommandName="edit" CommandArgument='<%# Eval("detailID") %>' class="btn btn-primary btn-fill"/>
                </td>
                <td>
                    <asp:Button ID="Button3" runat="server" Text="相簿" 
                                CommandName="photo" CommandArgument='<%# Eval("detailID") %>' class="btn btn-secondary btn-fill"/>
                </td>
                <td>
                    <asp:Button ID="Button2" runat="server" Text="刪除" 
                                CommandName="delete" CommandArgument='<%# Eval("detailID") %>' 
                                OnClientClick="javascript:if(!window.confirm('確定要刪除?')) window.event.returnValue = false;" class="btn btn-danger btn-fill"/>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
