<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="QASystem.Visitor.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelRegister" runat="server">
    
     <div class="login">
          	<div class="wrap">
				<div class="col_1_of_login span_1_of_login">
					<h4 class="title">New Users</h4>
					<p>New Users can get registered to the application by inputting the user details such as first name, last names, emailId, Contact Number, Occupation and Photo, during registration time user gets unqiue id and password, that can be used to get login to the application.</p>
					<div class="button1">
					   &nbsp;</div>
					 <div class="clear"></div>
				</div>
				<div class="col_1_of_login span_1_of_login">
				<div class="login-title">
	           		<h4 class="title">New User Registration</h4>
					<div id="loginbox" class="loginbox">
						
						  <fieldset class="input">
                           <p id="login-form-fname">
						      <label for="modlgn_fname">First Name</label>
                                <asp:TextBox ID="txtFName" runat="server" class="inputbox" size="18"></asp:TextBox>
						     
						       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                   ControlToValidate="txtFName" CssClass="validation" 
                                   ErrorMessage="Enter First Name" ToolTip="Enter First Name" 
                                   ValidationGroup="register"></asp:RequiredFieldValidator>
						     
						    </p>

                             <p id="login-form-lname">
						      <label for="modlgn_lname">Last Name</label>
                                <asp:TextBox ID="txtLName" runat="server" class="inputbox" size="18"></asp:TextBox>
						     
						    </p>


						    <p id="login-form-username">
						      <label for="modlgn_username">Email</label>
                                <asp:TextBox ID="txtEmailId" runat="server" class="inputbox" size="18"></asp:TextBox>
						     
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtEmailId" CssClass="validation" 
                                    ErrorMessage="Enter EmailId" ToolTip="Enter EmailId" ValidationGroup="register"></asp:RequiredFieldValidator>
						     
						    </p>
						    <p id="login-form-password">
						      <label for="modlgn_passwd">Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" class="inputbox" size="18" 
                                    TextMode="Password"></asp:TextBox>
						      
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtPassword" CssClass="validation" 
                                    ErrorMessage="Enter Password" ToolTip="Enter Password" 
                                    ValidationGroup="register"></asp:RequiredFieldValidator>
						      
						    </p>

                             <p id="login-form-address">
						      <label for="modlgn_address">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" class="inputbox" size="18"></asp:TextBox>
						      
						         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                     ControlToValidate="txtAddress" CssClass="validation" ErrorMessage="Enter Address" 
                                     ToolTip="Enter Address" ValidationGroup="register"></asp:RequiredFieldValidator>
						      
						    </p>

                              <p id="login-form-contactno">
						      <label for="modlgn_contactno">ContactNo</label>
                                <asp:TextBox ID="txtContactNo" runat="server" class="inputbox" size="18"></asp:TextBox>
						      
						         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                     ControlToValidate="txtContactNo" CssClass="validation" ErrorMessage="Enter ContactNo" 
                                     ToolTip="Enter ContactNo" ValidationGroup="register"></asp:RequiredFieldValidator>
						      
						    </p>

                              <p id="login-form-Occupation">
						      <label for="modlgn_occupation">Occupation</label>
                                <asp:TextBox ID="txtOccupation" runat="server" class="inputbox" size="18"></asp:TextBox>
						      
						         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                     ControlToValidate="txtOccupation" CssClass="validation" ErrorMessage="Enter Occupation" 
                                     ToolTip="Enter Occupation" ValidationGroup="register"></asp:RequiredFieldValidator>
						      
						    </p>

                              <p id="login-form-photo">
						      <label for="modlgn_photo">Upload Photo</label>
                                
                                  <asp:FileUpload ID="fileuploadPhoto" runat="server" />
						         <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                     ControlToValidate="fileuploadPhoto" CssClass="validation" ErrorMessage="Enter Photo" 
                                     ToolTip="Enter Photo" ValidationGroup="register"></asp:RequiredFieldValidator>
						      
						    </p>

                             

						    <div class="remember">
                                <asp:Button ID="btnRegister" runat="server" Text="Register" 
                                    onclick="btnRegister_Click" ValidationGroup="register" 
                                   />
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
