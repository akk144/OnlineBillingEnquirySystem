<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for generating a bill for a customer by the admin for a month>
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

<%@ Page Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="AddBill.aspx.cs" Inherits="WebApplication1.AddBill" %>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="container">
        <div style="width: 55%; margin-left: 21%;">
        <div class="table-responsive">
            <table class="table table-bordered table-condensed restable">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="LabelHeading" runat="server" Text="Enter Details" CssClass="form-control"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 367px">
                        <asp:Label ID="LabelCustomerId" runat="server" CssClass="form-control">Customer Id:</asp:Label>
                    </td>
                    <td style="width: 280px">
                        <asp:TextBox ID="TextCustomer"  required="required" placeholder="Customer Id" pattern="^[0-9,a-z,A-Z]*$" runat="server" title="Please enter the correct customer id" Style="width: 178px" CssClass="textox" />
                        
                    </td>
                </tr>
                <tr>
                    <td style="width: 367px">
                        
                        <asp:Label ID="LabelConnectionNumber" runat="server" CssClass="form-control">Connection Number:</asp:Label>
                    </td>
                    <td style="width: 280px">
            <asp:TextBox ID="TextBox1"  required="required" placeholder="Connection Number" pattern="^[0-9,a-z,A-Z]*$" runat="server" title="Please enter the correct customer id" Style="width: 178px" CssClass="textox"  />

                    </td>
                </tr>

                <tr>
                    <td colspan="2" style="margin-left: 160px; text-align: center">
                        <asp:Button ID="btnSubmit" CssClass="button-green" Text="Generate Bill" runat="server" OnClick="btnSubmit_Click" />
                        <br />
                        <asp:Label ID="LabelSuccess" CssClass="label-info" runat="server" Text="Bill Successfuly generated. The Bill Id is "></asp:Label>
                        <asp:Label ID="LabelBillId" CssClass="label" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
            
         </div>
    </div>

</asp:Content>
