<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="yachts03.aspx.cs" Inherits="tayanaBackend.WebForm10" %>

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
    <!--[if lt IE 7]>
<script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
<![endif]-->
    <link href="css/homestyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/jquery.ad-gallery.css">
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
    <!------換圖--------------------------->

<%--    <div class="banner">
        <div id="gallery" class="ad-gallery">
            <div class="ad-image-wrapper">
            </div>
            <div class="ad-controls" style="display: none">
            </div>
            <div class="ad-nav">
                <div class="ad-thumbs">
                    <ul class="ad-thumb-list">
                        <li>
                            <a href="images/test1.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                        <li>
                            <a href="images/test002.jpg">
                                <img src="images/pit003.jpg">
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>--%>
    <!------------以上原code-------------------------->
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
    <!-------換圖-------------------------------------------->

    <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <%--        <div class="left">

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
        <div id="crumb">
            <a href="#">Home</a> >> <a href="#">Yachts</a> >> <a href="#"><span class="on1">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label><asp:Label ID="Label6" runat="server" Text="Label"></asp:Label></span></a>
        </div>
        <div class="right">
            <div class="right1">
                <div class="title">
                    <span>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </span>
                </div>

                <!--------------------------------內容開始---------------------------------------------------->

                <!--次選單-->
                <%--                <div class="menu_y">
                    <ul>
                        <li class="menu_y00">YACHTS</li>
                        <li><a class="menu_yli01" href="#">Interior</a></li>
                        <li><a class="menu_yli02" href="#">Layout & deck pla</a>n</li>
                        <li><a class="menu_yli03" href="#">Specification</a></li>
                    </ul>
                </div>--%>
                <!-------------------------------------------->
                <div class="menu_y">
                    <ul>
                        <li class="menu_y00">YACHTS</li>
                        <li>
                            <a id="Y01" class="menu_yli01" href="" runat="server">Interior</a>
                        </li>
                        <li>
                            <a id="Y02" class="menu_yli02" href="" runat="server">Layout & deck plan</a>
                        </li>
                        <li>
                            <a id="Y03" class="menu_yli03" href="" runat="server">Specification</a>
                        </li>
                    </ul>
                </div>
                <!--次選單-->

                <asp:HiddenField ID="HiddenField1" runat="server" />
                <%--                <div class="box5">
                    <h4>DETAIL SPECIFICATION</h4>

                    <p>HULL STRUCTURE & DECKS</p>
                    <ul>
                        <li>Yanmar 4LHA-HTP 160HP (or equal)</li>
                        <li>White formica counters in hgalley. Teak veneer ctt</li>
                        <li>White formica counters in hgalley. Teak veneer c</li>
                        <li>White formica counters in hgalley. Teak veneer c</li>
                        <li>WTeak veneer ctte table 0005</li>
                        <li>WTeak veneer ctte table 0005</li>
                    </ul>

                    <p>HULL STRUCTURE & DECKS</p>
                    <ul>
                        <li>Yanmar 4LHA-HTP 160HP (or equal)</li>
                        <li>White formica counters in hgalley. Teak veneer ctt</li>
                        <li>White formica counters in hgalley. Teak veneer c</li>
                        <li>White formica counters in hgalley. Teak veneer c</li>
                        <li>WTeak veneer ctte table 0005</li>
                        <li>WTeak veneer ctte table 0005</li>
                    </ul>


                </div>--%>

                <!-------------------------------------------------------------------------------------->
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
