<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="QASystem.Visitor.SignIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Panel ID="panelLogin" runat="server">


     <div class="login">
          	<div class="wrap">


				<div class="col_1_of_login span_1_of_login">
					<h4 class="title">New Users</h4>
					<p>This is the user login page where user specifies emailid and password to get login to the application.</p>
					<div class="button1">
					    &nbsp;</div>
					 <div class="clear"></div>
				</div>
				<div class="col_1_of_login span_1_of_login">
				<div class="login-title">
	           		<h4 class="title">Registered Users</h4>
					<div id="loginbox" class="loginbox">
						
						  <fieldset class="input">
						    <p id="login-form-username">
						      <label for="modlgn_username">Email</label>
                                <asp:TextBox ID="txtUserId" runat="server" class="inputbox" size="18"></asp:TextBox>
						     
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtUserId" CssClass="validation" 
                                    ErrorMessage="Enter Email Id" ToolTip="Enter Email Id" ValidationGroup="login"></asp:RequiredFieldValidator>
						     
						    </p>
						    <p id="login-form-password">
						      <label for="modlgn_passwd">Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" class="inputbox" size="18" 
                                    TextMode="Password"></asp:TextBox>
						      
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtPassword" CssClass="validation" 
                                    ErrorMessage="Enter Password" ToolTip="Enter Password" ValidationGroup="login"></asp:RequiredFieldValidator>
						      
						    </p>
						    <div class="remember">
							  
                                <asp:Button ID="btnLogin" runat="server" Text="Login" 
                                    onclick="btnLogin_Click" ValidationGroup="login" />
							    <div class="clear">
                                </div>
							 </div>
						  </fieldset>
						
					</div>
			    </div>
				</div>
				<div class="clear"></div>
			</div>
		</div>


    </asp:Panel>

</asp:Content>
