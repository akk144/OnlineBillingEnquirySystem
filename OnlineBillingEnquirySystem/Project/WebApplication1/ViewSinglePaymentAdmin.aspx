<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for view payment details by admin for perticular number>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Snehal> Tata Consultancy Services
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="ViewSinglePaymentAdmin.aspx.cs" Inherits="WebApplication1.ViewSinglePaymentAdminaspx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width,initial-scale=1 maximum-scale = 1.0, user-scalable = no"" />
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="Javascript/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <meta charset="utf-8">
    <%--  <meta name="viewport" content="width=device-width, initial-scale=1">--%>
    <%--  <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css">--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


    <asp:ToolkitScriptManager runat="server"></asp:ToolkitScriptManager>
    <div class="container"></div>
    
    <br />
    <br />
    <br />
    <fieldset style="width: 60%; margin-left: 15%">
        <div class="table-responsive">
            <table  class="table table-bordered table-condensed restable cent" style="width:100%">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="LabelHeading" runat="server" Text="Payment Details" CssClass="form-control "></asp:Label>
                    </td>

                </tr>

                <tr>
                    <td style="width:850px">
                        <asp:Label ID="Lblpayid" runat="server" Text="Payment id" CssClass="form-control"></asp:Label>

                    </td>
                    <td style="width:850px">
                        <asp:Label ID="Paymentid" runat="server" CssClass="form-control"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblcustid" runat="server" Text="Customer Id" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="CustomerId" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblcusname" runat="server" Text="Customer Name" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="CustomerName" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblconnnum" runat="server" Text="Connection Number" CssClass="form-control"></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="ConnectionNumber" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblbillid" runat="server" Text="Bill Id" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="BillId" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblbillamt" runat="server" Text="Bill Amount" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="BillAmount" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblamtpaid" runat="server" Text="Amount Paid" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="AmountPaid" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lbladvamt" runat="server" Text="Advance Amount" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="AdvanceAmount" runat="server" CssClass="form-control"></asp:Label>


                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblarrear" runat="server" Text="Arrears" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="Arrears" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblmodepay" runat="server" Text="Mode Of Payment" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="ModeOfPayment" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblpaydate" runat="server" Text="Payment Date(mm/dd/yyyy)" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="PaymentDate" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblbnkname" runat="server" Text="Bank Name" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="BankName" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Lblcardtype" runat="server" Text="Card Type" CssClass="form-control"></asp:Label>

                    </td>

                    <td>
                        <asp:Label ID="CardType" runat="server" CssClass="form-control"></asp:Label>

                    </td>
                </tr>

                <tr style="text-align: center; margin-left: 35%">
                    <td>                     
                    </td>
                    <td><asp:Button ID="Back" OnClick="Back_Click" CssClass="button-red" runat="server" Text="Back" /></td>
                </tr>



            </table>
        </div>
    </fieldset>


    <br />
    <br />





</asp:Content>
