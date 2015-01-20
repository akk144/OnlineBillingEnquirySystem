<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for raising a dispute by customer against perticular bill>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Shekhar,Jayram> Tata Consultancy Services
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

<%@ Page Language="C#" MasterPageFile="~/BillPaymentCustomer.master" AutoEventWireup="true" CodeBehind="DisputeAdd.aspx.cs" Inherits="WebApplication1.DisputeAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <fieldset style="width: 70%; margin-left: 15%">
            <legend><b style="color: #0f4b94; font-size: medium">Customer Dispute Form</b> </legend>

            <div class="table-responsive">
                <table   class="table table-bordered table-condensed restable cent" style="width:100%">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="ldispute" runat="server" CssClass="form-control" Text="Your Dispute Id is " Visible="False" ForeColor="#32cd84"></asp:Label>
                             <asp:Label ID="ldisputeId" runat="server" CssClass="form-control" Visible="False" ForeColor="#32cd84"></asp:Label>
                        </td>
                        
                           
                       

                    </tr>

                    <tr>
                        <td style="width:850px">
                            <asp:Label ID="cusId"  runat="server"  CssClass="form-control">Customer Id</asp:Label>
                        </td>
                        <td style="text-align:left;width:850px">
                            <asp:TextBox ID="customerId" runat="server" CssClass="textox"  ></asp:TextBox>
                        </td>
                    </tr>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="connId" CssClass="form-control"  runat="server" Text="Connection Number"></asp:Label>
                                </td>
                                <td style="text-align:left">
                                    <asp:DropDownList ID="connectionId" CssClass="textox" runat="server" AutoPostBack="true" OnSelectedIndexChanged="connectionId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select a connection number" ControlToValidate="connectionId" InitialValue="0" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </ContentTemplate>

                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="bill" CssClass="form-control"  runat="server" Text="Bill Id"></asp:Label>
                                </td>
                                <td style="text-align:left">
                                    <asp:DropDownList ID="billId" AutoPostBack="true" CssClass="textox" OnSelectedIndexChanged="billId_SelectedIndexChanged"  runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please select a bill id" ControlToValidate="billId" InitialValue="0" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                                </td>

                            </tr>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <tr>
                        <td>
                            <asp:Label ID="stat" CssClass="form-control" runat="server"  Text="Status"></asp:Label>
                        </td>
                        <td style="text-align:left">
                            <asp:TextBox ID="stats" runat="server" CssClass="textox" ></asp:TextBox>
                        </td>

                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="date" runat="server" CssClass="form-control" Text="Date of Raise of Dispute"></asp:Label>
                        </td>
                        <td style="text-align:left">
                            <asp:TextBox ID="disputeDate" runat="server" CssClass="textox" ToolTip="Dispute Raise Date."></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="prob"  runat="server" CssClass="form-control" Text="Problem Details"></asp:Label>
                        </td>
                        <td style="text-align:left">
                            <asp:TextBox ID="problem" runat="server" CssClass="textox"  TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please fill the ptoblem details" ControlToValidate="problem" ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        </td>

                    </tr>
                    <tr>
                        <td> </td>
                        <td style="text-align:left">
                            <asp:Button ID="submit" runat="server"  CssClass="button-green" OnClick="submit_Click" Text="Submit" />
                           
                            <asp:Button ID="clear" runat="server" CssClass="button-red" CausesValidation="False" Text="Clear" OnClick="clear_Click" />
                        </td>

                    </tr>
                </table>
            </div>
        </fieldset>
    </div>
</asp:Content>
