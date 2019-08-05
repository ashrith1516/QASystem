<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QAModule.aspx.cs" Inherits="QASystem.Admin.QAModule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelQAModule" runat="server">

     <div class="login">
    	<div class="wrap">
    <h4 class="title">QA Module</h4>
            <table style="width: 60%;">
                <tr>
                    <td>
                        Select Question Type</td>
                    <td>
                        <asp:DropDownList ID="DropDownListType" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="DropDownListType_SelectedIndexChanged" Width="400px">
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
                         <div style="height:400px; width:auto; overflow:auto">

                     <asp:Table ID="tableQA" runat="server">
                     </asp:Table>
                     </div>
                     </div>

    </div>
    </div>

    </asp:Panel>
</asp:Content>
