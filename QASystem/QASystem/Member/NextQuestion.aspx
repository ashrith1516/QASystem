<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="NextQuestion.aspx.cs" Inherits="QASystem.Member.NextQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelQuery" runat="server">

     <div class="login">
    	<div class="wrap">
    <h4 class="title">Next question prediction</h4>


                    <div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">

                     <asp:Table ID="tableQA" runat="server">
                     </asp:Table>
                     </div>
                     </div>

                     <asp:Panel ID="Panel2" runat="server" Height="400px" 
            Width="721px">
                      <br />
            <table style="width: 75%;">
                <tr>
                    <td style="width: 351px" valign="top">
                        <strong>Distinct Keywords</strong></td>
                    <td>
                        <strong>Question Keywords Results</strong></td>
                </tr>
                <tr>
                    <td style="width: 351px" valign="top">
                        <asp:ListBox ID="lv_Items" runat="server" Height="175px" Width="211px">
                        </asp:ListBox>
                    </td>
                    <td style="width: 151px">
                        <asp:ListBox ID="lv_Transactions" runat="server" Height="175px" Width="324px">
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
            <table style="width: 75%;">
                <tr>
                    <td>
                        <strong>Frequent Item Set (L)</strong></td>
                    <td>
                        <strong>Final Output [displaying patterns]</strong></td>
                </tr>
                <tr>
                    <td>
                        <asp:ListBox ID="ListBox1" runat="server" Height="161px" Width="211px">
                        </asp:ListBox>
                    </td>
                    <td>
                        <asp:ListBox ID="ListBox2" runat="server" Height="161px" Width="324px">
                        </asp:ListBox>
                    </td>
                </tr>
            </table>
            <br />
        </asp:Panel>

    </div>
    </div>

    </asp:Panel>

</asp:Content>
