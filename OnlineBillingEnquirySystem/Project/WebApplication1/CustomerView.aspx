<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for view payment details by customer for perticular number>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Subnum,Snehal> Tata Consultancy Services
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentCustomer.master" AutoEventWireup="true" CodeBehind="CustomerView.aspx.cs" Inherits="WebApplication1.CustomerView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <meta name="viewport" content="width=device-width,initial-scale=1 maximum-scale = 1.0, user-scalable = no"" />--%>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="Javascript/bootstrap.min.js"></script>
    <script src="Javascript/jquery-1.9.1.min.js"></script>
    <link rel="stylesheet" href="CSS/footable-0.1.css" />
    <link rel="stylesheet" href="CSS/bootstrap-responsive1.min.css" />

    <script src="Javascript/footable.js"></script>
    <link href="CSS/bootstrap-responsive1.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <ajax:ToolkitScriptManager runat="server"></ajax:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="table-responsive">
                    <table class="table table-bordered table-condensed restable cent" style="width:100%">
                        <tr>
                            <td style="width:850px">
                                <asp:Label ID="Lblcustid" CssClass="form-control"  runat="server" Text="Customer Id"></asp:Label></td>
                            <td style="width:850px">
                                <asp:TextBox ID="custid" CssClass="textox" runat="server" ForeColor="Black" class="textox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lblconnum" CssClass="form-control" runat="server" Text="Connection Number"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="connectionList1" ForeColor="Black" CssClass="textox" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <td colspan="2">
                            <asp:Button ID="Button1" CssClass="button-green" runat="server" Text="Submit" OnClick="Button1_Click" Width="108px" /></td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select connection number" ControlToValidate="connectionList1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </table>
                </div>





                <br />
                <br />
                <br />
                <br />
                <div class="table-responsive" style="margin-left: 12%; text-align: center">
                    <asp:GridView ID="GridViewPaymentDetails1" CssClass="table table-bordered table-condensed"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridViewPaymentDetails1_SelectedIndexChanged" HeaderStyle-BackColor="#99ffcc" ForeColor="#333333" HeaderStyle-ForeColor="#003300" CellPadding="4" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Payment Id" DataField="Payment_Id" />
                            <asp:BoundField HeaderText="Customer Id" DataField="Customer_Id" ItemStyle-CssClass="hidden-phone" HeaderStyle-CssClass="hidden-phone" />
                            <asp:BoundField HeaderText="Customer Name" DataField="Customer_Name" ItemStyle-CssClass="hidden-phone" HeaderStyle-CssClass="hidden-phone" />
                            <asp:BoundField HeaderText="Connection Number" DataField="Connection_Id" ItemStyle-CssClass="hidden-phone" HeaderStyle-CssClass="hidden-phone" />
                            <asp:BoundField HeaderText="Bill Id" DataField="Bill_Id" ItemStyle-CssClass="hidden-phone" HeaderStyle-CssClass="hidden-phone" />
                            <asp:BoundField HeaderText="Bill Amount (INR)" DataField="Bill_Amount" />
                            <asp:BoundField HeaderText=" Amount Paid (INR)" DataField="Payable_Amount" />
                            <asp:BoundField HeaderText="Advance Amount (INR)" DataField="Advance_Amount" />
                            <asp:BoundField HeaderText="Arrears (INR)" DataField="Arrears" />
                            <asp:BoundField HeaderText="Payment Date(mm/dd/yyyy)" DataField="Date" DataFormatString="{0:MM/dd/yyyy}" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelect" CssClass="btn-info" runat="server" Text="View" CommandName="Select" ForeColor="#5D7B9D"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#636258" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#636258" ForeColor="White" Font-Bold="True" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
  

</asp:Content>
