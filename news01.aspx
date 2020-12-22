<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="news01.aspx.cs" Inherits="tayanaBackend.WebForm6" %>

<%@ Register Src="~/Usercontrol/Pagination.ascx" TagPrefix="uc1" TagName="Pagination" %>


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

                <%--                <div class="box2_list">
                    <ul>

                        <li>
                            <div class="list01">
                                <ul>
                                    <li>
                                        <div>
                                            <p>
                                                <img src="images/pit006.jpg" alt="&quot;&quot;" />
                                            </p>
                                        </div>
                                    </li>
                                    <li><span>2012-01-28</span><br />
                                        Tayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are available</li>
                                    <li>availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are availableTayana 58 CE Certificates are available</li>
                                </ul>
                            </div>
                        </li>

                        <li>
                            <div class="list01">
                                <ul>
                                    <li>
                                        <div>
                                            <p>
                                                <img src="images/pit007.jpg" alt="&quot;&quot;" />
                                            </p>
                                        </div>
                                    </li>
                                    <li><span>2012-01-28</span><br />
                                        Tayana 58 CE Certificates are available</li>
                                </ul>
                            </div>
                        </li>

                        <li>
                            <div class="list01">
                                <ul>
                                    <li>
                                        <div>
                                            <p>
                                                <img src="images/pit008.jpg" alt="&quot;&quot;" />
                                            </p>
                                        </div>
                                    </li>
                                    <li><span>2012-01-28</span><br />
                                        Tayana 58 CE Certificates are available</li>
                                </ul>
                            </div>
                        </li>

                        <li>
                            <div class="list01">
                                <ul>
                                    <li>
                                        <div>
                                            <p>
                                                <img src="images/pit006.jpg" alt="&quot;&quot;" width="300" />
                                            </p>
                                        </div>
                                    </li>
                                    <li><span>2012-01-28</span><br />
                                        Tayana 58 CE Certificates are available</li>
                                </ul>
                            </div>
                        </li>

                        <li>
                            <div class="list01">
                                <ul>
                                    <li>
                                        <div>
                                            <p>
                                                <img src="images/pit006.jpg" alt="&quot;&quot;" width="300" />
                                            </p>
                                        </div>
                                    </li>
                                    <li><span>2012-01-28</span><br />
                                        Tayana 58 CE Certificates are available</li>
                                </ul>
                            </div>
                        </li>
                    </ul>

                    <div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
                    <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>


                </div>--%>
                <!-----------------------------以上原code------------------------------------------------------------->
                <asp:Repeater ID="Repeater1" runat="server">
                    <HeaderTemplate>
                        <div class="box2_list">
                            <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <div class="list01">
                                <ul>
                                    <li>
                                        <div>
                                            <p>
                                                <asp:Image ID="previewPicture" runat="server" ImageUrl='<%#@"https://localhost:44358/images/ckf/previewNews/"+Eval("previewPicture") %>' />
                                            </p>
                                        </div>
                                    </li>
                                    <li>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("date","{0:yyyy-MM-dd}")%>'></asp:Label>
                                        <br />
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"news02.aspx?id="+Eval("id") %>'>
                                            <asp:Literal ID="Literal2" runat="server" Text='<%#Eval("title")%>'></asp:Literal>
                                        </asp:HyperLink>
                                        <br/>
                                    </li>
                                    <li>
                                        <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("previewArticle")%>'></asp:Literal>

                                    </li>

                                </ul>
                            </div>
                        </li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </div>
                    </FooterTemplate>
                </asp:Repeater>
                <uc1:Pagination runat="server" ID="Pagination" />
                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->
    </div>

</asp:Content>
