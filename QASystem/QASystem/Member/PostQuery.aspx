<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="PostQuery.aspx.cs" Inherits="QASystem.Member.PostQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 733px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelQuery" runat="server">

     <div class="login">
    	<div class="wrap">
    <h4 class="title">Post Query</h4>
            <table style="width: 90%;">
                <tr>
                    <td>
                        <strong>Input Query</strong></td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="600px" Height="30px"></asp:TextBox>
                       
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                       
&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="TextBox1" CssClass="validation" ErrorMessage="Enter Query" 
                            ToolTip="Enter Query" ValidationGroup="a"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" Height="30px" 
                            ValidationGroup="a" Width="150px" onclick="btnSubmit_Click" />
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>


                    <br />
            <table style="width:100%;">
                <tr>
                    <td class="style1">
                        <div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">

                             <br />

                             <asp:Label ID="lblType" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                             <br />
                             <br />

                     <asp:Table ID="tableQA" runat="server">
                     </asp:Table>
                     </div>
                     </div></td>
                    <td align="left" valign="top">

                     
                        <asp:Table ID="tblRecc" runat="server">
                        </asp:Table>

                     
                    </td>
                </tr>
            </table>
            <br />

            

            <br />

            <asp:Panel ID="Panel2" runat="server" Height="400px" 
            Width="721px" Visible="False">
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
            <br />
                   

    </div>
    </div>

    </asp:Panel>

</asp:Content>
