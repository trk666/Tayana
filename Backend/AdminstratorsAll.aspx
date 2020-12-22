<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="AdminstratorsAll.aspx.cs" Inherits="tayanaBackend.Backend.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    管理員列表<asp:Button ID="Button1" runat="server" Text="新增管理員" OnClick="Button1_Click" class="btn btn-primary btn-fill"/>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="author">
                <ul>
                    <li>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%#@"https://localhost:44358/Backend/img/user/"+Eval("photo") %>' class="avatar border-gray"/>
                    </li>
                    <li>
                        <asp:Label ID="userName" runat="server" Text='<%#Eval("userName") %>'></asp:Label>
                    </li>
                    <li>
                        <asp:Label ID="mail" runat="server" Text='<%#Eval("mail") %>'></asp:Label>
                    </li>
                    <li>
                        <asp:Button ID="Button2" runat="server" Text="Edit" CommandName="edit" CommandArgument='<%#Eval("id") %>' class="btn btn-info btn-fill"/>
                        <asp:Button ID="Button3" runat="server" Text="Delete" CommandName="delete" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:if(!window.confirm('確定要移除此管理員?')) window.event.returnValue = false;" class="btn btn-danger btn-fill"/>
                    </li>
                </ul>
            </div>
            <br/>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
