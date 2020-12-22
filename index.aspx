<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="tayanaBackend.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">


        $(function () {

            // 先取得 #abgne-block-20110111 , 必要參數及輪播間隔
            var $block = $('#abgne-block-20110111'),
                timrt, speed = 4000;


            // 幫 #abgne-block-20110111 .title ul li 加上 hover() 事件
            var $li = $('.title ul li', $block).hover(function () {
                // 當滑鼠移上時加上 .over 樣式
                $(this).addClass('over').siblings('.over').removeClass('over');
            }, function () {
                // 當滑鼠移出時移除 .over 樣式
                $(this).removeClass('over');
            }).click(function () {
                // 當滑鼠點擊時, 顯示相對應的 div.info
                // 並加上 .on 樣式

                $(this).addClass('on').siblings('.on').removeClass('on');
                var thisLi = $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().eq($(this).index());
                $('#abgne-block-20110111 .bd .banner ul:eq(0)').children().hide().eq($(this).index()).fadeIn(1000);
                if (thisLi.children('input[type=hidden]').val() == 1) {
                    thisLi.children('.new').show();
                }

            });

            // 幫 $block 加上 hover() 事件
            $block.hover(function () {
                // 當滑鼠移上時停止計時器
                clearTimeout(timer);
            }, function () {
                // 當滑鼠移出時啟動計時器
                timer = setTimeout(move, speed);
            });

            // 控制輪播
            function move() {
                var _index = $('.title ul li.on', $block).index();
                _index = (_index + 1) % $li.length;
                $li.eq(_index).click();

                timer = setTimeout(move, speed);
            }

            // 啟動計時器
            timer = setTimeout(move, speed);

            //相簿輪撥初始值設定
            $('.title ul li:eq(0)').addClass('on');
            var thisLi = $('#abgne-block-20110111 .bd .banner ul:eq(0) li:eq(0)');
            thisLi.addClass('on');
            if (thisLi.children('input[type=hidden]').val() == 1) {
                thisLi.children('.new').show();
            }

            //最新消息TOP
            $('.newstop').each(function () {
                if ($(this).nextAll('input[type=hidden]').val() == 1) {
                    $(this).show();
                }
            });
        });


    </script>

    <script type="text/javascript">

        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-30943877-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

    </script>
    <link rel="shortcut icon" href="favicon.ico" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--遮罩-->
    <div class="bannermasks">
        <img src="images/banner00_masks.png" alt="&quot;&quot;" />
    </div>
    <!--遮罩結束-->

    <!--------------------------------換圖開始---------------------------------------------------->
    <%--        <div id="abgne-block-20110111">
        <div class="bd">
            <div class="banner">

                <ul>
                    <li class="info on"><a href="#">
                        <img src="images/banner001b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>48</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>
                    <li class="info"><a href="#">
                        <img src="images/banner002b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>54</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                        <!--新船型開始  54型才出現其於隱藏 -->
                        <div class="new">
                            <img src="images/new01.png" alt="new" />
                        </div>
                        <!--新船型結束-->
                    </li>
                    <li class="info"><a href="#">
                        <img src="images/banner003b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>37</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>
                    <li class="info"><a href="#">
                        <img src="images/banner004b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>64</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>
                    <li class="info"><a href="#">
                        <img src="images/banner005b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>58</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>
                    <li class="info"><a href="#">
                        <img src="images/banner006b.jpg" /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>55</span><br />
                            <p>SPECIFICATION SHEET</p>
                        </div>
                        <!--文字結束-->
                    </li>
                </ul>


                <!--小圖開始-->
                <div class="bannerimg title">
                    <ul>
                        <li class="on">
                            <div>
                                <p class="bannerimg_p">
                                    <img src="images/i001.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="images/i002.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="images/i003.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="images/i004.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="images/i005.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src="images/i006.jpg" alt="&quot;&quot;" />
                                </p>
                            </div>
                        </li>
                    </ul>
                </div>
                <!--小圖結束-->
            </div>
        </div>
    </div>--%>
    <!--------------------------------官網版-------------------------------------------------------------->
<%--    <div id="abgne-block-20110111">
        <div class="bd">
            <div class="banner">

                <ul>

                    <li class="info"><a href='' target='_blank'>
                        <img src='upload/Images/20120402105949.jpg' /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>37</span><br />
                            <p>
                                SPECIFICATION SHEET
                            </p>
                        </div>
                        <!--文字結束-->
                        <!--新船型開始  54型才出現其於隱藏 -->
                        <div class="new" style="display: none">
                            <img src="images/new01.png" alt="new" />
                        </div>
                        <!--新船型結束-->
                        <input type="hidden" value='0' />
                    </li>

                    <li class="info"><a href='' target='_blank'>
                        <img src='upload/Images/20120402105909.jpg' /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>54</span><br />
                            <p>
                                SPECIFICATION SHEET
                            </p>
                        </div>
                        <!--文字結束-->
                        <!--新船型開始  54型才出現其於隱藏 -->
                        <div class="new" style="display: none">
                            <img src="images/new01.png" alt="new" />
                        </div>
                        <!--新船型結束-->
                        <input type="hidden" value='1' />
                    </li>

                    <li class="info"><a href='' target='_blank'>
                        <img src='upload/Images/20120402105506.jpg' /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>48</span><br />
                            <p>
                                SPECIFICATION SHEET
                            </p>
                        </div>
                        <!--文字結束-->
                        <!--新船型開始  54型才出現其於隱藏 -->
                        <div class="new" style="display: none">
                            <img src="images/new01.png" alt="new" />
                        </div>
                        <!--新船型結束-->
                        <input type="hidden" value='0' />
                    </li>

                    <li class="info"><a href='' target='_blank'>
                        <img src='upload/Images/20120402110356.jpg' /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>58</span><br />
                            <p>
                                SPECIFICATION SHEET
                            </p>
                        </div>
                        <!--文字結束-->
                        <!--新船型開始  54型才出現其於隱藏 -->
                        <div class="new" style="display: none">
                            <img src="images/new01.png" alt="new" />
                        </div>
                        <!--新船型結束-->
                        <input type="hidden" value='0' />
                    </li>

                    <li class="info"><a href='' target='_blank'>
                        <img src='upload/Images/20120402110329.jpg' /></a><!--文字開始--><div class="wordtitle">
                            TAYANA <span>64</span><br />
                            <p>
                                SPECIFICATION SHEET
                            </p>
                        </div>
                        <!--文字結束-->
                        <!--新船型開始  54型才出現其於隱藏 -->
                        <div class="new" style="display: none">
                            <img src="images/new01.png" alt="new" />
                        </div>
                        <!--新船型結束-->
                        <input type="hidden" value='0' />
                    </li>

                </ul>

                <!--小圖開始-->
                <div class="bannerimg title" style="display: none">

                    <ul>

                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src='upload/Images/s20120402105949.jpg' alt='TAYANA37SPECIFICATION SHEET' />
                                </p>
                            </div>
                        </li>

                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src='upload/Images/s20120402105909.jpg' alt='TAYANA54SPECIFICATION SHEET' />
                                </p>
                            </div>
                        </li>

                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src='upload/Images/s20120402105506.jpg' alt='TAYANA48SPECIFICATION SHEET' />
                                </p>
                            </div>
                        </li>

                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src='upload/Images/s20120402110356.jpg' alt='TAYANA58SPECIFICATION SHEET' />
                                </p>
                            </div>
                        </li>

                        <li>
                            <div>
                                <p class="bannerimg_p">
                                    <img src='upload/Images/s20120402110329.jpg' alt='TAYANA64SPECIFICATION SHEET' />
                                </p>
                            </div>
                        </li>

                    </ul>



                </div>
                <!--小圖結束-->
            </div>
        </div>
    </div>--%>
    <!--------------------------------以上原code---------------------------------------------------->
    <asp:Repeater ID="RepeaterPhoto" runat="server">
        <HeaderTemplate>
            <div id="abgne-block-20110111">
                <div class="bd">
                    <div class="banner">

                        <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li class="info"><a href='' target='_blank'>
                <img src="images/yachts/<%#Eval("photo") %>" /></a><!--文字開始--><div class="wordtitle">
                    <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("type") %>'></asp:Literal>
                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("serial") %>'></asp:Label>
                    <br />
                    <p>SPECIFICATION SHEET</p>
                </div>
                <!--文字結束-->
                <!--新船型開始  54型才出現其於隱藏 -->
                <div class="new" style="<%# New(Eval("newest"))%>">
                    <img src="images/new01.png" alt="new" />
                </div>
                <!--新船型結束-->
                <input type="hidden" value='0' />
            </li>

        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Repeater ID="RepeaterScale" runat="server">
        <HeaderTemplate>
            <div class="bannerimg title" style="display: none">

                <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <div>
                    <p class="bannerimg_p">
                        <img src="images/yachts/s_<%#Eval("photo") %>" alt='TAYANA37SPECIFICATION SHEET' />
                    </p>
                </div>
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


    <!--------------------------------最新消息---------------------------------------------------->
    <%--    <div class="news">
        <div class="newstitle">
            <p class="newstitlep1">
                <img src="images/news.gif" alt="news" />
            </p>
            <p class="newstitlep2"><a href="#">More>></a></p>
        </div>

        <ul>
            <!--TOP第一則最新消息-->
            <li>

                <div class="news01">
                    <!--TOP標籤-->
                    <div class="newstop">
                        <img src="images/new_top01.png" alt="&quot;&quot;" />
                    </div>
                    <!--TOP標籤結束-->
                    <div class="news02p1">
                        <p class="news02p1img">
                            <img src="images/pit002.jpg" alt="&quot;&quot;" />
                        </p>
                    </div>
                    <p class="news02p2"><span>Tayana 54 CE Certifica..</span> <a href="#">For Tayana 54 entering the EU, CE Certificates are AVAILABLE to ensure conformity to all applicable European ...</a></p>
                </div>
            </li>
            <!--TOP第一則最新消息結束-->

            <!--第二則-->
            <li>

                <div class="news01">
                    <!--TOP標籤-->
                    <div class="newstop">
                        <img src="images/new_top01.png" alt="&quot;&quot;" />
                    </div>
                    <!--TOP標籤結束-->
                    <div class="news02p1">
                        <p class="news02p1img">
                            <img src="images/pit001.jpg" alt="&quot;&quot;" />
                        </p>
                    </div>
                    <p class="news02p2">
                        <span>Tayana 58 CE Certifica..</span>
                        <a href="#">For Tayana 58 entering the EU, CE Certificates are AVAILABLE to ensure conformity to all applicable European ...</a>
                    </p>
                </div>
            </li>
            <!--第二則結束-->

            <li>
                <div class="news02">
                    <!--TOP標籤-->
                    <div class="newstop">
                        <img src="images/new_top01.png" alt="&quot;&quot;" />
                    </div>
                    <!--TOP標籤結束-->
                    <div class="news02p1">
                        <p class="news02p1img">
                            <img src="images/pit001.jpg" alt="&quot;&quot;" />
                        </p>
                    </div>
                    <p class="news02p2">
                        <span>Big Cruiser in a Small ..</span>
                        <a href="#">Tayana 37 is our classical product and full of skilful craftsmanship. We only plan to build TWO units in a year.</a>
                    </p>
                </div>
            </li>
        </ul>
    </div>--%>
    <!--------------------------------以上原code---------------------------------------------------->
    <asp:Repeater ID="RepeaterNews" runat="server">
        <HeaderTemplate>
            <div class="news">
                <div class="newstitle">
                    <p class="newstitlep1">
                        <img src="images/news.gif" alt="news" />
                    </p>
                    <p class="newstitlep2"><a href="news01.aspx">More>></a></p>
                </div>

                <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>

                <div class="news01">
                    <!--TOP標籤-->
                    <div class="newstop">
                        <img src="images/new_top01.png" alt="&quot;&quot;" />
                    </div>
                    <!--TOP標籤結束-->
                    <div class="news02p1">
                        <p class="news02p1img">
                            <img src="images/ckf/previewNews/<%#Eval("previewPicture") %>" alt="&quot;&quot;" />
                        </p>
                    </div>
                    <p class="news02p2">
                        <asp:Label ID="NewsTitle" runat="server" Text='<%#Eval("title") %>'></asp:Label>
                        <a href="news02.aspx?id=<%#Eval("id") %>">
                            <asp:Label ID="PreviewArticle" runat="server" Text='<%#Eval("previewArticle") %>'></asp:Label>
                        </a>
                    </p>
                </div>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <!--------------------------------最新消息結束---------------------------------------------------->
</asp:Content>
