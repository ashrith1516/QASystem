<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="QASystem.Member.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelProfile" runat="server">


     <div class="login">
          	<div class="wrap">

				<div class="col_1_of_login span_1_of_login">
				<div class="login-title">
	           		<h4 class="title">Member Profile Updation</h4>
					<div id="loginbox" class="loginbox">
						
						  <fieldset class="input">
						    <p id="login-form-username">
						      <label for="modlgn_username">First Name</label>
                                <asp:TextBox ID="txtFName" runat="server" class="inputbox" size="18" TextMode="SingleLine"></asp:TextBox>
						     
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtFName" CssClass="validation" 
                                    ErrorMessage="Enter FName" ToolTip="Enter FName" ValidationGroup="login"></asp:RequiredFieldValidator>
						     
						    </p>
						    <p id="login-form-LName">
						      <label for="modlgn_LName">Last Name</label>
                                <asp:TextBox ID="txtLName" runat="server" class="inputbox" size="18" 
                                    TextMode="SingleLine"></asp:TextBox>
						      
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtLName" CssClass="validation" 
                                    ErrorMessage="Enter LName" ToolTip="Enter LName" ValidationGroup="login"></asp:RequiredFieldValidator>
						      
						    </p>

                             <p id="login-form-Address">
						      <label for="modlgn_Address">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" class="inputbox" size="18" 
                                    TextMode="SingleLine"></asp:TextBox>
						      
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtAddress" CssClass="validation" 
                                    ErrorMessage="Enter Address" ToolTip="Enter Address" ValidationGroup="login"></asp:RequiredFieldValidator>
						      
						    </p>

                              <p id="login-form-ContactNo">
						      <label for="modlgn_ContactNo">Contact Number</label>
                                <asp:TextBox ID="txtCOntactNo" runat="server" class="inputbox" size="18" 
                                    TextMode="SingleLine"></asp:TextBox>
						      
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtCOntactNo" CssClass="validation" 
                                    ErrorMessage="Enter Mobile" ToolTip="Enter Mobile" ValidationGroup="login"></asp:RequiredFieldValidator>
						      
						    </p>

                              <p id="login-form-Occupation">
						      <label for="modlgn_Occupation">Occupation</label>
                                <asp:TextBox ID="txtOccupation" runat="server" class="inputbox" size="18" 
                                    TextMode="SingleLine"></asp:TextBox>
						      
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txtOccupation" CssClass="validation" 
                                    ErrorMessage="Enter Occupation" ToolTip="Enter Occupation" ValidationGroup="login"></asp:RequiredFieldValidator>
						      
						    </p>

                              <p id="login-form-date">
						      <label for="modlgn_date">Registered Date</label>
                                  <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
						      
						    </p>
						    <div class="remember">
							   
                                <asp:Button ID="btnSubmit" runat="server" Text="Edit" 
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
