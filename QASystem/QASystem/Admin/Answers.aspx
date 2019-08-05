<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Answers.aspx.cs" Inherits="QASystem.Admin.Answers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAnswers" runat="server">

        	
    <div class="login">
          	<div class="wrap">

			

    <h4 class="title">QA Module (Answers)</h4>


     <asp:Label ID="lblQuestion" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
     <br />

      <table style="width: 60%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Select Status</td>
                    <td>
                        <asp:DropDownList ID="DropDownListStatus" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DropDownListStatus_SelectedIndexChanged" Width="400px">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>Deactive</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>


                    <div id="popup">
                         <div style="height:800px; width:auto; overflow:auto">


                     <asp:Table ID="tableAnswers" runat="server">
                     </asp:Table>
                     </div>
                     </div>

   
    </div>
    </div>

    </asp:Panel>



</asp:Content>
