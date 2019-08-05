<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Setkeywords.aspx.cs" Inherits="QASystem.Admin.Setkeywords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelSetKeywords" runat="server">



 
    
          	
    <div class="login">
          	<div class="wrap">

				<div class="col_1_of_login span_1_of_login">
				<div class="login-title">
	           		<h4 class="title">Set Keywords for Question Type</h4>
					<div id="loginbox" class="loginbox">
						
						  <fieldset class="input">
						    <p id="P2">
						      <label for="modlgn_username">Select Question Type</label>
                                <asp:DropDownList ID="DropDownListTypes" runat="server" 
                                                                   onselectedindexchanged="DropDownListTypes_SelectedIndexChanged" 
                                                                   Width="502px" AutoPostBack="True">
                                                               </asp:DropDownList>
						     
						      
						     
						    </p>
						    <p id="login-form-password">
						      <label for="modlgn_passwd">Set Keyword</label><br/>
                                   <asp:TextBox ID="txtKeyword" runat="server" class="inputbox" size="18"></asp:TextBox>
						      <br />
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                    ControlToValidate="txtKeyword" CssClass="validation" 
                                    ErrorMessage="Enter keyword" ToolTip="Enter Keyword" ValidationGroup="key"></asp:RequiredFieldValidator>
						      
						    </p>
						    <div class="remember">
							   
                                <asp:Button ID="btnKeyword" runat="server" Text="Submit" 
                                     ValidationGroup="key" onclick="btnKeyword_Click" />
							    <div class="clear">

                                      <br />
                                       <table style="width: 100%;">
                                           <tr>
                                               <td>
                                                   <strong>Existing Keywords</strong></td>
                                           </tr>
                                           <tr>
                                               <td align="center">
                                                   &nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   <div style="height:650px; width:auto; overflow:auto">
                                                       <asp:Table ID="tblKeywords" runat="server">
                                                       </asp:Table>
                                                   </div>
                                               </td>
                                           </tr>
                                       </table>
                                       <br />
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
