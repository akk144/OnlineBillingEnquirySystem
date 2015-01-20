<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for displaying the a particular bill item by its id to the admin>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Saikat,Akansh> Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :N/A
// Change Description# : N/A
// Changed By  : N/A
// Date Modified  : N/A
// Change Description# : N/A
// Changed By  : N/A
// Date Modified  : N/A
//
///////////////////////////////////////////////////////////////////////////////////////////////--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="ViewOneBillItem.aspx.cs" Inherits="WebApplication1.ViewOneBillItem" %>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset style="width: 60%; margin-left: 20%;">
                    <div class="table-responsive">
                     <table  class="table table-bordered table-condensed restable cent" style="width:100%">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="LabelHeader" runat="server" Text="Item Details" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:850px">
                            <asp:Label ID="lbillitemid" runat="server" CssClass="form-control">BillItem Id:</asp:Label>
                        </td>
                        <td style="width:850px">
                            <asp:Label ID="billitemid" runat="server" Text="" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="lconnectionnumber" runat="server" CssClass="form-control">Connection Number:</asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="connectionnumber" runat="server" Text="" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="ldateofcall" runat="server" CssClass="form-control">Date Of Call:</asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="dateofcall" runat="server" Text="" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="lduration" runat="server" CssClass="form-control">Duration:</asp:Label>
                        </td>
                        <td >

                            <asp:Label ID="duration" runat="server" Text="" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="lnumbercalled" runat="server" CssClass="form-control">Number Called:</asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="numbercalled" runat="server" Text="" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>

                    <tr>
                        <td >
                            <asp:Label ID="ltype" runat="server" CssClass="form-control">Type Of Call:</asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="type" runat="server" Text="" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="lpulse" runat="server" CssClass="form-control">Pulse Rate:</asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="pulse" runat="server" Text="" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="lcost" runat="server" CssClass="form-control">Cost of call:</asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="cost" runat="server" Text="" CssClass="form-control"></asp:Label>
                        </td>
                    </tr>

                </table>
                        </div>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
