<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for displaying a particular bill for a customer to the customer>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Saikat,Shekhar> Tata Consultancy Services
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

<%@ Page Language="C#" MasterPageFile="~/BillPaymentCustomer.master" AutoEventWireup="true" CodeBehind="ViewBill.aspx.cs" Inherits="WebApplication1.ViewBill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="content" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajax:ToolkitScriptManager runat="server"></ajax:ToolkitScriptManager>

    <br />
    <br />
    <br />
    <br />


    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <fieldset style="width: 70%; margin-left: 15%;">
                    <div class="col-sm-6">
                        <asp:Label ID="LabelConnection" runat="server" CssClass="form-control">       Select Connection Number:<font style="color:red">*</font></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownListConnection" runat="server" CssClass="textox"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorConnection" runat="server" ErrorMessage="Please Select a Connection" ControlToValidate="DropDownListConnection" InitialValue="0" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6">
                        <asp:Label ID="LabelMonth" runat="server" CssClass="form-control">            Select Month:<font style="color:red">*</font></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownListMonth" runat="server" CssClass="textox"></asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidatorMonth" runat="server" ErrorMessage="Please Select a Month" ControlToValidate="DropDownListMonth" InitialValue="0" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Button ID="BtnViewBill" CssClass="button-green" runat="server" OnClick="BtnViewBill_Click"  Text="Submit" CausesValidation="true" />


                    
                        <asp:Button ID="BtnViewBillDetails" CssClass="button-blue" Width="160px" runat="server" OnClick="BtnViewBillDetails_Click" Text="ViewBillDetails" CausesValidation="true" />
                        
                        <br />
                        <br />
                        <div class="table-responsive">
                            <div id="vanish" runat="server">
                                <table class="table table-bordered table-condensed restable cent" style="width: 100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="LabelHeading" runat="server" Text="Bill Details" CssClass="form-control"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 850px">
                                            <asp:Label ID="lbillid" runat="server" CssClass="form-control">Bill Id:</asp:Label>
                                        </td>
                                        <td style="width: 850px">
                                            <asp:Label ID="billid" runat="server" Text="" CssClass="form-control"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lcustomerid" runat="server" CssClass="form-control">Customer Id:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="customerid" runat="server" Text="" CssClass="form-control"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lconnectionid" runat="server" CssClass="form-control">Connection Numbers:</asp:Label>
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
