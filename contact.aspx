<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="contact.aspx.cs" Inherits="tayanaBackend.contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="Scripts/jquery.min.js"></script>

    <!--[if lt IE 7]>
        <script type="text/javascript" src="javascript/iepngfix_tilebg.js"></script>
    <![endif]-->
    <link rel="shortcut icon" href="favicon.ico" /><link href="css/homestyle.css" rel="stylesheet" type="text/css" /><link href="css/reset.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $('.topbuttom').click(function () {
                $('html, body').scrollTop(0);

            });

        });
    </script>
    
    <script type="text/javascript" src="/manage/javascript/jquery.validate.js"></script>
    <script type="text/javascript" src="/manage/javascript/jquery.metadata.js"></script>
    <link href="/manage/css_styles/components/jquery_validate.css"
          rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("form").validate({ meta: "validate" });
                
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!--------------------------------選單開始結束---------------------------------------------------->
        
    <!--遮罩-->
<div class="bannermasks"><img src="images/contact.jpg" alt="&quot;&quot;" width="967" height="371" /></div>
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
<li><img src="images/newbanner.jpg" alt="Tayana Yachts" /></li>
</ul>

</div> 
<!--------------------------------換圖結束----------------------------------------------------> 




<div class="conbg"> 
<!--------------------------------左邊選單開始----------------------------------------------------> 
<div class="left"> 

<div class="left1">
<p><span>CONTACT</span></p>
<ul>
<li><a href="#">contacts</a></li>
</ul>



</div>




</div>







<!--------------------------------左邊選單結束----------------------------------------------------> 

<!--------------------------------右邊選單開始----------------------------------------------------> 
<div id="crumb"><a href="index.aspx">Home</a> >> <a href="#"><span class="on1">Contact</span></a></div>
<div class="right"> 
<div class="right1">
  <div class="title"> <span>Contact</span></div>
  
<!--------------------------------內容開始----------------------------------------------------> 
<!--表單-->
<div class="from01"><p> Please Enter your contact information<span class="span01">*Required</span>
</p><br />
  <table>
    <tr>
      <td class="from01td01">Name :</td>
      <td><span>*</span><input runat="server" name="ctl00$ContentPlaceHolder1$Name" type="text" id="txtName" class="{validate:{required:true, messages:{required:'Required'}}}" style="width:250px;" /> </td>
    </tr>
    <tr>
      <td class="from01td01">Email :</td>
      <td><span>*</span><input runat="server" name="ctl00$ContentPlaceHolder1$Email" type="text" id="txtEmail" class="{validate:{required:true, email:true, messages:{required:'Required', email:'Please check the E-mail format is correct'}}}" style="width:250px;" /></td>
    </tr>
    <tr>
      <td class="from01td01">Phone :</td>
      <td><span>*</span><input runat="server" name="ctl00$ContentPlaceHolder1$Phone" type="text" id="txtPhone" class="{validate:{required:true, messages:{required:'Required'}}}" style="width:250px;" /></td>
    </tr>
    <tr>
      <td class="from01td01">Country :</td>
      <td><span>*</span>
          <asp:DropDownList ID="CountryList" runat="server"></asp:DropDownList>                
<%--          <select name="ctl00$ContentPlaceHolder1$Country" id="ctl00_ContentPlaceHolder1_Country">
	<option value="USA">USA</option>
	<option value="ASIA">ASIA</option>
	<option value="EUROPE">EUROPE</option>
	<option value="NORTH AMERICA">NORTH AMERICA</option>
	<option value="CENTRAL AMERICA">CENTRAL AMERICA</option>
	<option value="SOUTH AMERICA">SOUTH AMERICA</option>
	<option value="AFRICA">AFRICA</option>
	<option value="OCEANIA">OCEANIA</option>

</select>--%>
                                            </td>
    </tr>
    <tr>
      <td colspan="2" ><span>*</span>Brochure of interest  *Which Brochure would you like to view?</td>
      </tr>
    <tr>
      <td class="from01td01">&nbsp;</td>
      <td>
          <asp:DropDownList ID="YachtsList" runat="server"></asp:DropDownList>
<%--          <select name="ctl00$ContentPlaceHolder1$Yachts" id="ctl00_ContentPlaceHolder1_Yachts">
	<option value="Tayana 37">Tayana 37</option>
	<option value="Tayana 46">Tayana 46</option>
	<option value="Tayana 48">Tayana 48</option>
	<option value="Tayana 54   (New Building)">Tayana 54   (New Building)</option>
	<option value="Tayana 58">Tayana 58</option>
	<option value="Tayana 64">Tayana 64</option>
	<option value="ISARA 50">ISARA 50</option>

</select>--%>
                   </td>
    </tr>
    <tr>
      <td class="from01td01">Comments:</td>
      <td><textarea runat="server" name="ctl00$ContentPlaceHolder1$Comments" rows="2" cols="20" id="txtComments" style="height:150px;width:330px;"></textarea></td>
    </tr>
<%--    <tr>
      <td class="from01td01">&nbsp;</td>
      <td class="f_right">
          <img src="JpegImage.ashx" id="ctl00_ContentPlaceHolder1_imgMVcode" style="padding-right:8px" align="middle" alt="Please enter the verification code" border="0" title="Please enter the verification code" /><input name="ctl00$ContentPlaceHolder1$txtVCode" type="text" value="Please enter the verification code" id="ctl00_ContentPlaceHolder1_txtVCode" onblur="javascript: if(this.value=='')  this.value='Please enter the verification code';" onfocus="javascript: if(this.value=='Please enter the verification code') this.value='';" style="background-color:White;width:250px;" />
      </td>
    </tr>--%>
    <tr>
      <td class="from01td01">&nbsp;</td>
      <td class="f_right">
          <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="images/buttom03.gif"/>
      </td>
    </tr>
  </table>  
</div>

<!--表單-->

<div class="box1">
<span class="span02">Contact with us</span><br />
Thanks for your enjoying our web site as an introduction to the Tayana world and our range of yachts.
As all the designs in our range are semi-custom built, we are glad to offer a personal service to all our potential customers. 
If you have any questions about our yachts or would like to take your interest a stage further, please feel free to contact us.
</div>

<div class="list03">
<p><span>TAYANA HEAD OFFICE</span><br />
NO.60 Haichien Rd. Chungmen Village Linyuan Kaohsiung Hsien 832 Taiwan R.O.C<br />
  tel. +886(7)641 2422<br />
  fax. +886(7)642 3193<br />
 </p>
</div>

<div class="box4">
<h4>Location</h4>
<p>
  <iframe width="695" height="518" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" 
          src="https://www.google.com/maps/embed?pb=!1m28!1m12!1m3!1d58960.082026066295!2d120.32268299182137!3d22.541480710763725!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m13!3e3!4m5!1s0x346e1cce3ff6bb99%3A0x1ceaaec46945d129!2z6auY6ZuE5ZyL6Zqb6Iiq56m656uZIDgxMumrmOmbhOW4guWwj-a4r-WNgOS4reWxseWbm-i3rw!3m2!1d22.574628999999998!2d120.3448068!4m5!1s0x3471e297f292ef73%3A0x99f03ba7afab5cec!2zODMy5p6X5ZyS5Y2A5rW35aKY6LevNjDomZ_lpKfmtIvpgYroiYfkvIHmpa3ogqHku73mnInpmZDlhazlj7g!3m2!1d22.5084025!2d120.36647749999999!5e0!3m2!1szh-TW!2stw!4v1595223702942!5m2!1szh-TW!2stw"></iframe>
</p>

  </div>
    



<!--------------------------------內容結束------------------------------------------------------> 
    
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
</div>

</asp:Content>
