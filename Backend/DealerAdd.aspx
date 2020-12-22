<%@ Page Title="" Language="C#" ValidateRequest="False" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="DealerAdd.aspx.cs" Inherits="tayanaBackend.Backend.WebForm13" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>新增經銷商</h3>
    <asp:Button ID="golist" runat="server" Text="回總表" OnClick="golist_Click" class="btn btn-primary btn-fill"/>
    <asp:Button ID="goedit" runat="server" Text="修改" OnClick="goedit_Click" class="btn btn-primary btn-fill"/>
    <asp:HiddenField ID="HiddenCountry" runat="server" />
    <asp:HiddenField ID="HiddenArea" runat="server" />
    <ul runat="server" id="ListArea">
        <li>
            <asp:DropDownList ID="CountryList" runat="server" OnInit="CountryList_Init" OnSelectedIndexChanged="CountryList_SelectedIndexChanged" Width="230px" AutoPostBack="True">
            </asp:DropDownList>
        </li>
        <li>
            <asp:TextBox ID="NewCountry" runat="server"></asp:TextBox>
            <asp:Button ID="AddCountry" runat="server" Text="新增國家" OnClick="AddCountry_Click" class="btn btn-info btn-fill"/>
            <asp:Label ID="CountryEmpty" runat="server" Text="Label" Visible="False"></asp:Label>
        </li>
        <li>
            <asp:Label ID="CountryAlert" runat="server" Text="已有同樣國家名稱" Visible="False"></asp:Label>
        </li>
        <li>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="AreaList" runat="server" Width="230px">
                        <asp:ListItem Value="0">請先選擇國家</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <br />
                    <asp:TextBox ID="NewArea" runat="server"></asp:TextBox>
                    <asp:Button ID="AddArea" runat="server" Text="新增地區" OnClick="AddArea_Click" class="btn btn-info btn-fill"/>
                    <asp:Label ID="NoChooseCountry" runat="server" Text="Label" Visible="False"></asp:Label>
                    <asp:Label ID="AreaEmpty" runat="server" Text="Label" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="AreaAlert" runat="server" Text="所選國家已有同樣區域名稱" Visible="False"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="CountryList" EventName="SelectedIndexChanged" />
                    <%--+了這個不會閃--%>
                </Triggers>
            </asp:UpdatePanel>
        </li>
        <li>
            <asp:Button ID="Button1" runat="server" Text="增加經銷商至此地區" OnClick="Button1_Click" class="btn btn-primary btn-fill"/><asp:Label ID="NoChoose" runat="server" Text="未指定國家或地區" Visible="False"></asp:Label>
        </li>
        </ul>

                <ul runat="server" Visible="False"  id="ShowADD">
                    <h3>新增經銷商至
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                    </h3>
                    <li>
                        經銷商圖:<asp:FileUpload ID="DealerPhoto" runat="server" />
                    </li>
                    <li>
                        <asp:TextBox ID="DealerInfo" runat="server" TextMode="MultiLine" Class="ckeditor"></asp:TextBox>
                    </li>
                    <li>
                        <asp:Button ID="Submit" runat="server" Text="新增經銷商" OnClick="Submit_Click" class="btn btn-info btn-fill"/><asp:Label ID="SubmitAlert" runat="server" Text="未指定區域" Visible="False"></asp:Label>
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="重新選擇國家地區" class="btn btn-defult btn-fill"/>
                    </li>
                </ul>

</asp:Content>
