<%@ Page Title="" Language="C#" MasterPageFile="~/Member/Member.Master" AutoEventWireup="true" CodeBehind="PostAnswer.aspx.cs" Inherits="QASystem.Member.PostAnswer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelQAModule" runat="server">

     <div class="login">
    	<div class="wrap">
    <h4 class="title">Post Answer</h4>
         <br />

          <table style="width: 65%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <table style="width:100%;">
                        <tr>
                            <td>
                                <asp:RadioButton ID="rbtnText" runat="server" AutoPostBack="True" 
                                    Font-Bold="True" GroupName="a" Text="Text Message" ToolTip="Text" 
                                    oncheckedchanged="rbtnText_CheckedChanged" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rbtnPhotos" runat="server" AutoPostBack="True" 
                                    Font-Bold="True" GroupName="a" Text="Photos" ToolTip="Photos" 
                                    oncheckedchanged="rbtnPhotos_CheckedChanged" />
                            </td>
                            <td>
                                <asp:RadioButton ID="rbtnVideos" runat="server" AutoPostBack="True" 
                                    Font-Bold="True" GroupName="a" Text="Videos" ToolTip="Videos" 
                                    oncheckedchanged="rbtnVideos_CheckedChanged" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Panel ID="PanelText" runat="server" Visible="False">
       
            <table style="width:75%;">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Enter Answer</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtTextTitle" runat="server" Width="450px" Height="150px" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtTextTitle" CssClass="validation" 
                            ErrorMessage="Enter Answer" ToolTip="Enter Answer" 
                            ValidationGroup="text"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnText" runat="server" Text="Post Answer" 
                            ValidationGroup="text" Width="150px" onclick="btnText_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
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
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            
        </asp:Panel>
        <br />
        <asp:Panel ID="PanelPhotos" runat="server" Visible="False">
       
            <table style="width:75%;">
              
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Enter Description</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtPhotoDescription" runat="server" Height="120px" 
                            TextMode="MultiLine" Width="450px"></asp:TextBox>
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtPhotoDescription" CssClass="validation" 
                            ErrorMessage="Enter Description" ToolTip="Enter Description" 
                            ValidationGroup="photo"></asp:RequiredFieldValidator>
                    </td>
                    <td class="style1">
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Select Number of Photos</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:DropDownList ID="DropDownListPhotoNumber" runat="server" 
                            AutoPostBack="True" 
                            onselectedindexchanged="DropDownListPhotoNumber_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToValidate="DropDownListPhotoNumber" CssClass="validation" 
                            ErrorMessage="Select Number Of Photos" Operator="NotEqual" 
                            ToolTip="Select Number Of Photos" ValidationGroup="photo" 
                            ValueToCompare="Select"></asp:CompareValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Upload Photos</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Table ID="Table1" runat="server">
                        </asp:Table>
                    </td>
                    <td>
                        &nbsp;</td>
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
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnUploadPhotos" runat="server" Text="Upload Photos" 
                            ValidationGroup="photo" Width="150px" onclick="btnUploadPhotos_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
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
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
           
        </asp:Panel>
       
        <asp:Panel ID="PanelVideos" runat="server" Visible="False">
      
      
            <table style="width:75%;">
              
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Enter Description</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtVideoDescription" runat="server" Height="120px" 
                            TextMode="MultiLine" Width="450px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtVideoDescription" CssClass="validation" 
                            ErrorMessage="Enter Video Description" ToolTip="Enter Video Description" 
                            ValidationGroup="video"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Upload Videos</strong></td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="SerialNo">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="CheckBox1_CheckedChanged" Text='<%# Eval("SerialNo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Video URL">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="350px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        &nbsp;</td>
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
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="btnUploadVideos" runat="server" Text="Upload Videos" 
                            ValidationGroup="video" Width="150px" onclick="btnUploadVideos_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
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
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
            
        </asp:Panel>

         <br />

    </div>
    </div>

    </asp:Panel>


</asp:Content>
