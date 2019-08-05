<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="Answers.aspx.cs" Inherits="QASystem.Member.Answers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAnswers" runat="server">

        	
    <div class="login">
          	<div class="wrap">

			

    <h4 class="title">QA Module (Answers)</h4>


     <asp:Label ID="lblQuestion" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <br />
                <table style="width:100%;">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnAnswer" runat="server" Height="30px" 
                                onclick="btnAnswer_Click" Text="Click here to Post Answer" Width="250px" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td align="right">
                            &nbsp;</td>
                    </tr>
                </table>
     <br />
      <br />


                    <div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">


                     <asp:Table ID="tableAnswers" runat="server">
                     </asp:Table>
                     </div>
                     </div>

   
    </div>
    </div>

    </asp:Panel>

</asp:Content>
