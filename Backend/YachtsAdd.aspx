<%@ Page Title="" Language="C#" ValidateRequest="False" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="YachtsAdd.aspx.cs" Inherits="tayanaBackend.Backend.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>船隻新增</h2>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <ul>
        <li>
            <asp:DropDownList ID="TypeList" runat="server" OnInit="TypeList_Init" OnSelectedIndexChanged="TypeList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </li>
        <li>
            <asp:TextBox ID="TypeEdit" runat="server"></asp:TextBox>
            <asp:Button ID="SubmitType" runat="server" Text="新增船型" OnClick="SubmitType_Click" class="btn btn-info btn-fill"/>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </li>
        <li>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="SerialList" runat="server" AutoPostBack="True" >
                        <asp:ListItem Value="0">請先選擇船型</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="TypeList" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </li>
        <li>

            <asp:TextBox ID="SerialEdit" runat="server"></asp:TextBox>
            <asp:Button ID="SubmitSerial" runat="server" Text="新增型號" OnClick="SubmitSerial_Click" class="btn btn-info btn-fill"/>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>

        </li>
        <li>
            <h3>是否為最新型</h3>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" >
                <asp:ListItem Value="1">是</asp:ListItem>
                <asp:ListItem Value="0">否</asp:ListItem>
            </asp:RadioButtonList>
        </li>
        <li>
            <h3>封面圖片</h3>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </li>

    </ul>


</asp:Content>
