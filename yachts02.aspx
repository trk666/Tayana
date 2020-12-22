<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="yachts02.aspx.cs" Inherits="tayanaBackend.WebForm9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="css/jquery.ad-gallery.css">
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery.ad-gallery.js"></script>
    <script type="text/javascript">
        $(function () {

            var galleries = $('.ad-gallery').adGallery();
            galleries[0].settings.effect = 'slide-hori';



        });
    </script>

    <link href="css/homestyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $('.topbuttom').click(function () {
                $('html, body').scrollTop(0);

            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--遮罩-->
    <div class="bannermasks">
        <img src="images/banner01_masks.png" alt="&quot;&quot;" />
    </div>
    <!--遮罩結束-->

    <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <div class="banner">
            <div id="gallery" class="ad-gallery">
            <div class="ad-image-wrapper">
            </div>
            <div class="ad-controls" style="display: none">
            </div>
            <div class="ad-nav">
            <div class="ad-thumbs">
            <ul class="ad-thumb-list">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href='<%#@"images\yachts\"+Eval("img") %>'>
                    <img src='<%#@"images\yachts\"+"s_"+Eval("img") %>'>
                </a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
        </ul>
        </div>
        </div>
        </div>
        </div>
        </FooterTemplate>
    </asp:Repeater>

    <!--------------------------------換圖結束---------------------------------------------------->




    <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <%--<div class="left">

            <div class="left1">
                <p><span>YACHTS</span></p>
                <ul>
                    <li><a href="#">Dynasty 72</a></li>
                    <li><a href="#">Tayana 64</a></li>
                    <li><a href="#">Tayana 58</a></li>
                    <li><a href="#">Tayana 55</a></li>
                </ul>



            </div>




        </div>--%>
        <!----------------------------------以上原code-------------------------------------------------->

        <asp:Repeater ID="LeftList" runat="server">
            <HeaderTemplate>
                <div class="left">
                    <div class="left1">
                        <p><span>YACHTS</span></p>
                        <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <a href="yachts01.aspx?id=<%#Eval("detailID") %>">
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("type") %>'></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("serial") %>'></asp:Label>
                    </a>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </div>
            </div>
            </FooterTemplate>
        </asp:Repeater>
        <!--------------------------------左邊選單結束---------------------------------------------------->



        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb"><a href="#">Home</a> >> <a href="#">Yachts</a> >> <a href="#"><span class="on1">
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></span></a></div>
        <div class="right">
            <div class="right1">
                <div class="title">
                    <span>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </span>
                </div>

                <!--------------------------------內容開始---------------------------------------------------->
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <!--次選單-->
<%--                <div class="menu_y">
                    <ul>
                        <li class="menu_y00">YACHTS</li>
                        <li><a class="menu_yli01" href="#">Interior</a></li>
                        <li><a class="menu_yli02" href="#">Layout & deck pla</a>n</li>
                        <li><a class="menu_yli03" href="#">Specification</a></li>
                    </ul>
                </div>--%>
                <!-------------------------------->
                <div class="menu_y">
                    <ul>
                        <li class="menu_y00">YACHTS</li>
                        <li>
                            <a id="Y01" class="menu_yli01" href="" runat="server" >Interior</a>
                        </li>
                        <li>
                            <a id="Y02" class="menu_yli02" href="" runat="server" >Layout & deck plan</a>
                        </li>
                        <li>
                            <a id="Y03" class="menu_yli03" href="" runat="server" >Specification</a>
                        </li>
                    </ul>
                </div>
                <!--次選單-->

                <%--<div class="box6">
                    <p>Layout & deck plan</p>
                    <ul>
                        <li>
                            <img src="images/deckplan01.jpg" alt="&quot;&quot;" /></li>
                        <li>
                            <img src="images/deckplan01.jpg" alt="&quot;&quot;" /></li>
                    </ul>
                </div>


                <div class="clear"></div>--%>
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                <p class="topbuttom">
                    <img src="images/top.gif" alt="top" />
                </p>
                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>

</asp:Content>
