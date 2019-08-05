<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="QASystem.Admin.AdminHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Panel ID="panelAdminHome" runat="server">

     <div class="login">
    	<div class="wrap">
    <h4 class="title">View Registered Users</h4>

                    <div id="popup">
                         <div style="height:400px; width:auto; overflow:auto">

                     <asp:Table ID="tableMembers" runat="server">
                     </asp:Table>
                     </div>
                     </div>

    </div>
    </div>

    </asp:Panel>

</asp:Content>
