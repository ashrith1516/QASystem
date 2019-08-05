<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="AnswerDetails.aspx.cs" Inherits="QASystem.Member.AnswerDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAnswerDetails" runat="server">

     <div class="login">
    	<div class="wrap">
    <h4 class="title">View Answer Details!!!</h4>

                    <table style="width: 35%;">
            <tr>
                <td>
                  
                <td>
                    <asp:Label ID="lblPostType" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="panelText" runat="server" Visible="False">
       
            <table style="width:75%;">
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
                        <strong>Text Title</strong></td>
                    <td>
                        <asp:Label ID="lblTextTitle" runat="server" Width="450px"></asp:Label>
                        <br />
                        <asp:HyperLink ID="HyperLink1" runat="server">[HyperLink1]</asp:HyperLink>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
           
        </asp:Panel>
        <br />
        <asp:Panel ID="panelPhotos" runat="server" Visible="False">
        
            <table style="width:75%;">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Table ID="Table1" runat="server">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            
        </asp:Panel>
        <br />
        <asp:Panel ID="panelVideos" runat="server" Visible="False">
       
            <table style="width:75%;">
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Table ID="Table2" runat="server">
                        </asp:Table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
           
        </asp:Panel>
        <br />
    <br />

    </div>
    </div>

    </asp:Panel>
</asp:Content>
