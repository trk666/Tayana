<%@ Page Title="" Language="C#" ValidateRequest="False" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="YachtEdit.aspx.cs" Inherits="tayanaBackend.Backend.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/js/core/jquery.3.2.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var ckEditor01 = CKEDITOR.replace('ContentPlaceHolder1_Overview');

            ckEditor01.on("change", function (event) {
                event.editor.updateElement();
            });
            var ckEditor02 = CKEDITOR.replace('ContentPlaceHolder1_Layout');

            ckEditor02.on("change", function (event) {
                event.editor.updateElement();
            });
            var ckEditor03 = CKEDITOR.replace('ContentPlaceHolder1_Specification');

            ckEditor03.on("change", function (event) {
                event.editor.updateElement();
            });


        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>船隻編輯</h2>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <div id="Area01" runat="server">
    <ul>
        <li>
            <asp:DropDownList ID="TypeList" runat="server" OnInit="TypeList_Init" OnSelectedIndexChanged="TypeList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
        </li>
        <li>

            <asp:TextBox ID="TypeEdit" runat="server" ></asp:TextBox>
            <asp:Button ID="SubmitType" runat="server" Text="修改被選船型" OnClick="SubmitType_Click" class="btn btn-info btn-fill"/>
            <asp:Button ID="DeleteType" runat="server" Text="移除被選船型" OnClick="DeleteType_Click" OnClientClick="javascript:if(!window.confirm('此船型的所有型號都會被移除，確定移除?')) window.event.returnValue = false;" class="btn btn-danger btn-fill"/>

        </li>
        <li>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </li>
        <li>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="SerialList" runat="server" >
                        <asp:ListItem>請先選擇船型</asp:ListItem>
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
            <asp:Button ID="SubmitSerial" runat="server" Text="修改被選型號" OnClick="SubmitSerial_Click" class="btn btn-info btn-fill"/>
            <asp:Button ID="DeleteSerial" runat="server" Text="移除被選型號" OnClick="DeleteSerial_Click" OnClientClick="javascript:if(!window.confirm('確定要移除此型號?')) window.event.returnValue = false;" class="btn btn-danger btn-fill"/>

        </li>
        <li>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </li>
    </ul>

    <asp:Button ID="Button1" runat="server" Text="顯示更多內容" OnClick="Button1_Click" />
    <asp:Label ID="NoSelectAlert" runat="server" Text="Label"></asp:Label>
    </div>
    
    <div runat="server" id="EditAREA" Visible="False">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="SelectSerial" runat="server" />
            <ul >
                <li>
                    <h2>
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        <asp:Literal ID="Literal2" runat="server"></asp:Literal> :
                    </h2>
                </li>
                <li>
                    <h3>是否為最新型</h3>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:RadioButtonList>
                </li>
                <li></li>
                <li>
                    <h3>概觀:</h3>
                    <asp:TextBox ID="Overview" runat="server" TextMode="MultiLine">
                        
                    </asp:TextBox>
                </li>
                <li>
                    <h3>布局&甲板設計:</h3>
                    <asp:TextBox ID="Layout" runat="server" TextMode="MultiLine"></asp:TextBox>
                </li>
                <li>
                    <h3>規格諸元:</h3>
                    <asp:TextBox ID="Specification" runat="server" TextMode="MultiLine"></asp:TextBox>
                </li>
               
            </ul>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="SerialList" EventName="SelectedIndexChanged" />
        </Triggers>

    </asp:UpdatePanel>
        <ul>
            <li>
                <h3>上傳PDF</h3>
                <asp:FileUpload ID="PDFupload" runat="server" />
            </li>
            <li>
                <asp:Button ID="EditPhoto" runat="server" Text="編輯相簿" OnClick="EditPhoto_Click" class="btn btn-warning btn-fill"/>
            </li>
            <li>
                <asp:Button ID="Submit" runat="server" Text="送出修改" OnClick="Submit_OnClick" class="btn btn-info btn-fill"/>
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                <asp:Button ID="Rest" runat="server" Text="取消修改" OnClick="Rest_OnClick" class="btn btn-defult btn-fill"/>
            </li>
        </ul>
    </div>
</asp:Content>
