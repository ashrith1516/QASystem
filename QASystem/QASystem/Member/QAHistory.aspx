<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="QAHistory.aspx.cs" Inherits="QASystem.Member.QAHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelQAModule" runat="server">

     <div class="login">
    	<div class="wrap">
    <h4 class="title">QA Module (My History)</h4>


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
