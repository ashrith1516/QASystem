<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QuestionType.aspx.cs" Inherits="QASystem.Admin.QuestionType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<asp:Panel ID="panelAreaofInterest" runat="server">


    <div class="login">
          	<div class="wrap">

				<div class="col_1_of_login span_1_of_login">
				<div class="login-title">
	           		<h4 class="title">Upload Question Types</h4>
					<div id="loginbox" class="loginbox">
						  <fieldset class="input">
						    <p id="P2">
						      <label for="modlgn_username">Enter Question Type</label>
                                <asp:TextBox ID="txtType" runat="server" class="inputbox" size="18"></asp:TextBox>
						     
						        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtType" CssClass="validation" 
                                    ErrorMessage="Enter Type" ToolTip="Enter Type" ValidationGroup="type"></asp:RequiredFieldValidator>
						     
						    </p>
						    <div class="remember">
							   
                                <asp:Button ID="btnType" runat="server" Text="Submit" 
                                     ValidationGroup="type" onclick="btnType_Click" />
							    <div class="clear">

                                      <br />
                                       <table style="width: 80%;">
                                           <tr>
                                               <td>
                                                   <strong>Existing Question Types</strong></td>
                                           </tr>
                                           <tr>
                                               <td align="center">
                                                   &nbsp;</td>
                                           </tr>
                                           <tr>
                                               <td>
                                                   <div style="height:650px; width:auto; overflow:auto">
                                                       <asp:Table ID="tbTypes" runat="server">
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
                </div>
                </div>
				
				<div class="clear"></div>
			               


    </asp:Panel>


</asp:Content>
