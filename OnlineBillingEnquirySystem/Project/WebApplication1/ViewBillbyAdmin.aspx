<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for displaying a particular bill for a customer to the admin>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="ViewBillbyAdmin.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset style="width: 70%;margin-left: 15%;">
                    <asp:Button ID="BtnDetail" CssClass="button-blue" Width="170px" runat="server" OnClick="BtnDetail_Click" Text="View Call Details" />
                    <br />
                    <br />
                    <div class="table-responsive">
                        <div id="vanish" runat="server">
                            <table  class="table table-bordered table-condensed restable cent" style="width:100%">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="LabelHeading" runat="server" Text="Bill Details" CssClass="form-control"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width:850px">
                                        <asp:Label ID="lbillid" runat="server" CssClass="form-control">Bill Id:</asp:Label>
                                    </td>
                                    <td style="width:850px">
                                        <asp:Label ID="billid" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lcustomerid" runat="server" CssClass="form-control">Customer Id:</asp:Label>
                                    </td>
                                    <td >
                                        <asp:Label ID="customerid" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lconnectionid" runat="server" CssClass="form-control">Connection Id:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="connectionid" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lgeneratedate" runat="server" CssClass="form-control">Date of Generation:</asp:Label>
                                    </td>
                                    <td>

                                        <asp:Label ID="generatedate" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lamount" runat="server" CssClass="form-control">Amount:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="amount" runat="server" Text="" CssClass="form-control"></asp:Label>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:Label ID="lyear" runat="server" CssClass="form-control">Year:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="yearr" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lmonth" runat="server" CssClass="form-control">Month:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="monthh" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="larrears" runat="server" CssClass="form-control">Arrears:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="arrears" runat="server" Text="" CssClass="form-control"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ladvancepayment" runat="server" CssClass="form-control">Advanced Payment:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="advancepayment" runat="server" Text="" CssClass="form-control"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ldiscount" runat="server" CssClass="form-control">Discount:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="discount" runat="server" Text="" CssClass="form-control"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ltotalamount" runat="server" CssClass="form-control">Total Amount:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="totalamount" runat="server" Text="" CssClass="form-control"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td>

                                    </td>
                                    <td>
                                        <asp:Button ID="Back" CssClass="button-red" runat="server" Text="Back"  OnClick="Back_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </fieldset>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
