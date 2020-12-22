<%@ Page Title="" Language="C#" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="tayanaBackend.Backend.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>經銷商總表</h2>
    <asp:Button ID="Add" runat="server" Text="新增" OnClick="Add_Click" class="btn btn-primary btn-fill"/>&nbsp;<asp:Button ID="Edit" runat="server" Text="修改" OnClick="Edit_Click" class="btn btn-primary btn-fill"/>
    <ul runat="server" id="ListArea">
        <li>
            <asp:DropDownList ID="CountryList" runat="server" OnInit="CountryList_Init" OnSelectedIndexChanged="CountryList_SelectedIndexChanged" Width="230px" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Button ID="DeleteCountry" runat="server" Text="移除國家" OnClick="DeleteCountry_Click" OnClientClick="javascript:if(!window.confirm('確定要移除此國家?')) window.event.returnValue = false;" class="btn btn-danger btn-fill"/>
            <br/>
        </li>
        <li>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="AreaList" runat="server" Width="230px" OnSelectedIndexChanged="AreaList_SelectedIndexChanged">
                        <asp:ListItem Value="0">請先選擇國家</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="DeleteArea" runat="server" Text="移除地區" OnClick="DeleteArea_Click" OnClientClick="javascript:if(!window.confirm('確定要移除此地區?')) window.event.returnValue = false;" class="btn btn-danger btn-fill"/>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="CountryList" EventName="SelectedIndexChanged" />
                    <%--+了這個不會閃--%>
                </Triggers>
            </asp:UpdatePanel>
        </li>
        <li>
            <asp:Button ID="Button1" runat="server" Text="show Dealer" OnClick="Button1_Click" class="btn btn-defult btn-fill"/>
        </li>
    </ul>
        <ul>
        <li>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table class="table table-hover table-striped">
                        
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Image ID="dealerPhoto" runat="server" ImageUrl='<%#@"https://localhost:44358/images/dealers/"+Eval("photo") %>' />

                        </td>
                        <td>
                            <asp:Label ID="infoHead" runat="server" Text='<%#Eval("area") %>'></asp:Label>
                            <br/>
                            <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("dealer") %>'></asp:Literal>
                           

                        </td>
                        <td>
                            <asp:Button ID="DeleteDealer" runat="server" Text="移除經銷商" CommandName="delete" CommandArgument='<%#Eval("dealerID") %>' OnClientClick="javascript:if(!window.confirm('確定要移除此經銷商?')) window.event.returnValue = false;" class="btn btn-danger btn-fill"/>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </li>
    </ul>
</asp:Content>
