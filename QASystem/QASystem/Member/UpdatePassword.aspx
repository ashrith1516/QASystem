<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="UpdatePassword.aspx.cs" Inherits="QASystem.Member.UpdatePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelUpdatePassword" runat="server">


     <div class="login">
          	<div class="wrap">

				<div class="col_1_of_login span_1_of_login">
				<div class="login-title">
	           		<h4 class="title">Member Change Password</h4>
					<div id="loginbox" class="loginbox">
						
						  <fieldset class="input">
						    <p id="login-form-username">
						      <label for="modlgn_username">Old Password</label>
                                <asp:TextBox ID="txtOldPassword" runat="server" class="inputbox" size="18" TextMode="Password"></asp:TextBox>
						     
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtOldPassword" CssClass="validation" 
                                    ErrorMessage="Enter Old Password" ToolTip="Enter Old Password" ValidationGroup="login"></asp:RequiredFieldValidator>
						     
						    </p>
						    <p id="login-form-password">
						      <label for="modlgn_passwd">New Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" class="inputbox" size="18" 
                                    TextMode="Password"></asp:TextBox>
						      
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtPassword" CssClass="validation" 
                                    ErrorMessage="Enter Password" ToolTip="Enter Password" ValidationGroup="login"></asp:RequiredFieldValidator>
						      
						    </p>

                             <p id="login-form-Confirmpassword">
						      <label for="modlgn_Confirmpasswd">Confirm Password</label>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" class="inputbox" size="18" 
                                    TextMode="Password"></asp:TextBox>
						      
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtConfirmPassword" CssClass="validation" 
                                    ErrorMessage="Enter Confirm Password" ToolTip="Enter Confirm Password" ValidationGroup="login"></asp:RequiredFieldValidator>
						      
						    </p>
						    <div class="remember">
							   
                                <asp:Button ID="btnSubmit" runat="server" Text="Update" 
                                    ValidationGroup="login" onclick="btnSubmit_Click" />
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
