<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="news02.aspx.cs" Inherits="tayanaBackend.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('.slideshow').cycle({
                fx: 'fade' // choose your transition type, ex: fade, scrollUp, shuffle, etc...
            });
        });
    </script>


    <link href="css/homestyle.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--遮罩-->
    <div class="bannermasks">
        <img src="images/banner02_masks.png" alt="&quot;&quot;" />
    </div>
    <!--遮罩結束-->

    <!--<div id="buttom01"><a href="#"><img src="images/buttom01.gif" alt="next" /></a></div>-->

    <!--小圖開始-->
    <!--<div class="bannerimg">
<ul>
<li> <a href="#"><div class="on"><p class="bannerimg_p"><img  src="images/pit003.jpg" alt="&quot;&quot;" /></p></div></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" width="300" /></p>
</a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>

<ul>
<li> <a class="on" href="#"><p class="bannerimg_p"><img  src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <p class="bannerimg_p"><a href="#"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
<li> <a href="#"><p class="bannerimg_p"><img src="images/pit003.jpg" alt="&quot;&quot;" /></p></a></li>
</ul>


</div>-->
    <!--小圖結束-->


    <!--<div id="buttom02"> <a href="#"><img src="images/buttom02.gif" alt="next" /></a></div>-->

    <!--------------------------------換圖開始---------------------------------------------------->

    <div class="banner">
        <ul>
            <li>
                <img src="images/newbanner.jpg" alt="Tayana Yachts" /></li>
        </ul>

    </div>
    <!--------------------------------換圖結束---------------------------------------------------->

    <div class="conbg">
        <!--------------------------------左邊選單開始---------------------------------------------------->
        <div class="left">

            <div class="left1">
                <p><span>NEWS</span></p>
                <ul>
                    <li><a href="news01.aspx">News & Events</a></li>

                </ul>



            </div>




        </div>







        <!--------------------------------左邊選單結束---------------------------------------------------->

        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb"><a href="#">Home</a> >> <a href="#">News </a>>> <a href="#"><span class="on1">News & Events</span></a></div>
        <div class="right">
            <div class="right1">
                <div class="title"><span>News & Events</span></div>

                <!--------------------------------內容開始---------------------------------------------------->
                <%--                <div class="box3">
                    <h4>The Luxury Tayana 48 Pilothouse Lavish Woodwork Is Among</h4>
                    <p>
                        <img src="images/pit009.jpg" alt="&quot;&quot;" /></p>
                    On Display at the Seattle Boats Afloat Show, Lake Union, January 25 - February 3, 2007
The luxury Tayana 48 Pilothouse is the perfect boat for the Northwest Cruiser or, for that matter, anywhere in the world. Designed for minimal exterior maintenance, and equipped for maximun creature comforts and ease of sailing. Enjoy aft cockpit sailing with comfortable seating for nice weather cruising or duck inside and sail from the inside steering station when it is gnarly out. Large salon windows with a pair of overhead hatches give the skipper plenty of visibility to see all around as well as up to check sail shape and trim.
                </div>--%>
                <!--------------------------------以上原code---------------------------------------------------->
                <div class="box3">
                    <h4>
                        <asp:Label ID="title" runat="server" Text="Label"></asp:Label>
                    </h4>
                    <asp:Literal ID="article" runat="server"></asp:Literal>
                    
                </div>
                <!--------------------------------內容結束---------------------------------------------------->


                <!--下載開始-->
<%--                <div class="downloads">
                    <p>
                        <img src="images/downloads.gif" alt="&quot;&quot;" />
                    </p>
                    <ul>
                        <li><a href="#">Downloads 001</a></li>
                        <li><a href="#">Downloads 001</a></li>
                        <li><a href="#">Downloads 001</a></li>
                        <li><a href="#">Downloads 001</a></li>
                        <li><a href="#">Downloads 001</a></li>
                    </ul>
                </div>--%>
                <!--下載結束-->

                <div class="buttom001">
                    <a href="news01.aspx">
                        <img src="images/back.gif" alt="&quot;&quot;" width="55" height="28" /></a>
                </div>

                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>

</asp:Content>
