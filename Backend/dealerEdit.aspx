<%@ Page Title="" Language="C#" ValidateRequest="False" MasterPageFile="~/Backend/Bmaster.Master" AutoEventWireup="true" CodeBehind="DealerEdit.aspx.cs" Inherits="tayanaBackend.Backend.dealerEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>編輯現有國家,地區,經銷商</h3>
    <asp:Button ID="golist" runat="server" Text="回總表" OnClick="golist_Click" class="btn btn-primary btn-fill"/>
    <asp:Button ID="goadd" runat="server" Text="去新增" OnClick="goadd_Click" class="btn btn-primary btn-fill"/>
    
    <asp:HiddenField ID="HiddenCountry" runat="server" />
    <asp:HiddenField ID="HiddenArea" runat="server" />
    <ul runat="server" id="ListArea">
        <li>
            <asp:DropDownList ID="CountryList" runat="server" OnInit="CountryList_Init" OnSelectedIndexChanged="CountryList_SelectedIndexChanged" Width="230px" AutoPostBack="True">
            </asp:DropDownList>
        </li>
        <li>
            <asp:TextBox ID="CountryEdit" runat="server"></asp:TextBox>
            <asp:Button ID="EditCountry" runat="server" Text="修改國家名稱" OnClick="EditCountry_Click" class="btn btn-info btn-fill"/>
        </li>
        <li>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="AreaList" runat="server" Width="230px" OnSelectedIndexChanged="AreaList_SelectedIndexChanged">
                        <asp:ListItem Value="0">請先選擇國家</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <br />
                    <asp:TextBox ID="AreaEdit" runat="server"></asp:TextBox>
                    <asp:Button ID="EditArea" runat="server" Text="修改區域名稱" OnClick="EditArea_Click" class="btn btn-info btn-fill"/>
                    <br />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="CountryList" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </li>
        <li>
            <asp:Button ID="Button1" runat="server" Text="show Dealers" OnClick="Button1_Click" class="btn btn-defult btn-fill"/><asp:Label ID="NoChoose" runat="server" Text="未指定國家或地區" Visible="False"></asp:Label>
        </li>
    </ul>
    
    <asp:DataList ID="DataList1" runat="server" OnCancelCommand="DataList1_CancelCommand" OnEditCommand="DataList1_EditCommand" OnUpdateCommand="DataList1_UpdateCommand" DataKeyField="dealerID">
        <ItemTemplate>
            <table class="table table-hover table-striped">
            
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
                        <asp:Button ID="Button2" runat="server" Text="我要編輯" CommandName="edit" class="btn btn-primary btn-fill"/><%--名字不能亂取--%>

                    </td>
                </tr>
            </table>
            
            

        </ItemTemplate>
      <EditItemTemplate>
          

          <div>
              <asp:Image ID="Image1" runat="server" ImageUrl='<%#@"https://localhost:44358/images/dealers/"+Eval("photo") %>' />
          </div>
          <div>
              <asp:FileUpload ID="DealerPhotoEdit" runat="server" /><br />
              <asp:Label ID="Label2" runat="server" Text="未修改則沿用舊圖"></asp:Label>
              <asp:HiddenField ID="HiddenField1" runat="server" />
          </div>
          <div>
              <asp:TextBox ID="DealerInfo" runat="server" TextMode="MultiLine" Class="ckeditor" Text='<%#Eval("dealer") %>'>></asp:TextBox>
          </div>
          <asp:Button ID="Button3" runat="server" Text="送出修改" CommandName="update" class="btn btn-info btn-fill"/><%--名字不能亂取--%>
          <asp:Button ID="Button2" runat="server" Text="放棄編輯" CommandName="cancel" class="btn btn-defult btn-fill"/><%--名字不能亂取--%>    
      </EditItemTemplate>
    </asp:DataList>

</asp:Content>
