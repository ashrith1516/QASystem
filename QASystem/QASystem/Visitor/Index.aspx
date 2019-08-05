﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="QASystem.Visitor.Index" %>

<!--A Design by W3layouts
Author: W3layout
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>
<html>
<head>
<title>QA System</title>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="../css/style.css" rel="stylesheet" type="text/css" media="all" />
<link href="../css/form.css" rel="stylesheet" type="text/css" media="all" />
<link href='http://fonts.googleapis.com/css?family=Exo+2' rel='stylesheet' type='text/css'>
<script type="text/javascript" src="../js/jquery1.min.js"></script>
<!-- start menu -->
<link href="../css/megamenu.css" rel="stylesheet" type="text/css" media="all" />
<script type="text/javascript" src="../js/megamenu.js"></script>
<script>    $(document).ready(function () { $(".megamenu").megamenu(); });</script>
<!--start slider -->
    <link rel="stylesheet" href="../css/fwslider.css" media="all">
    <script src="../js/jquery-ui.min.js"></script>
    <script src="../js/css3-mediaqueries.js"></script>
    <script src="../js/fwslider.js"></script>
<!--end slider -->
<script src="../js/jquery.easydropdown.js"></script>
</head>
<body>
     <div class="header-top">
	   <div class="wrap"> 
			 
			 <div class="cssmenu">
				<ul>
					<li><a href="SignIn.aspx">Log In</a></li> |
					<li><a href="SignUp.aspx">Sign Up</a></li>|
                    
					<li><a href="AdminSignIn.aspx">Admin Log In</a></li>
				</ul>
			</div>
			<div class="clear"></div>
 		</div>
	</div>
	<div class="header-bottom">
	    <div class="wrap">
			<div class="header-bottom-left">
				<div class="logo">
					<a href="Index.aspx"><img src="../images/logo.png" alt=""/></a>
				</div>
				<div class="menu">
	            <ul class="megamenu skyblue">
			<li class="active grid"><a href="Index.aspx">Home</a></li>
			<%--<li><a class="color4" href="Trending.aspx">Trending</a>--%>
				
				</li>				
				<li><a class="color5" href="Services.aspx">Services</a>
                <li><a href="ContactUs.aspx">Contact Us</a></li> 
				
				</li>
			
			</ul>
			</div>
		</div>
	   <div class="header-bottom-right">
        
	  
    </div>
     <div class="clear"></div>
     </div>
	</div>
  
  <!-- start slider -->
    <div id="fwslider">
        <div class="slider_container">
            <div class="slide"> 
                <!-- Slide image -->
                    <img src="../images/QAbanner2.png" alt=""/>
                <!-- /Slide image -->
                <!-- Texts container -->
                <div class="slide_content">
                    <div class="slide_content_wrap">
                        <!-- Text title -->
                        <h4 class="title">QA System</h4>
                        <!-- /Text title -->
                        
                        <!-- Text description -->
                        <p class="description">Post Queries and Get Answers</p>
                        <!-- /Text description -->
                    </div>
                </div>
                 <!-- /Texts container -->
            </div>
            <!-- /Duplicate to create more slides -->
            <div class="slide">
                <img src="../images/QAbanner1.png" alt=""/>
                <div class="slide_content">
                    <div class="slide_content_wrap">
                        <h4 class="title">Predicting Next Question </h4>
                        <p class="description">Data Mining</p>
                    </div>
                </div>
            </div>
            <!--/slide -->
        </div>
        <div class="timers"></div>
        <div class="slidePrev"><span></span></div>
        <div class="slideNext"><span></span></div>
    </div>
    <!--/slider -->

   <div class="footer">
		
		
		 <div class="footer">
		
		<div class="footer-bottom">
			<div class="wrap">
	             <div class="copy">
			        <p>© 2016 All Rights Reserved<a href="#" target="_blank"></a></p>
		         </div>
				<div class="f-list2">
				 <ul>
					<li class="active"><a href="Index.aspx">Home</a></li> |
					<li><a href="Trending.aspx">Trending QA</a></li> |
					<li><a href="Services.aspx">Services</a></li> |
					<li><a href="ContactUs.aspx">Contact Us</a></li> 
				 </ul>
			    </div>
			    <div class="clear"></div>
		      </div>
	     </div>
	</div>
	</div>
</body>
</html>