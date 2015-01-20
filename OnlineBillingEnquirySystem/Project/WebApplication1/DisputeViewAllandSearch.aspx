<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for view all disputes and search a perticular dispute by admin >
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Jayram,Shekhar> Tata Consultancy Services
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="DisputeViewAllandSearch.aspx.cs" Inherits="WebApplication1.DisputeViewAllandSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<meta name="viewport" content="width=device-width,initial-scale=1 maximum-scale = 1.0, user-scalable = no"" />--%>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="Javascript/bootstrap.min.js"></script>
    <script src="Javascript/jquery-1.8.2.js"></script>
    <link rel="stylesheet" href="CSS/footable-0.1.css" />
    <script src="Javascript/footable.js"></script>
    <link href="CSS/bootstrap-responsive1.min.css" rel="stylesheet" />
    <link href="CSS/bootstrap-responsive%20min.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="table-responsive">
                    <table class="table table-bordered table-condensed restable cent" style="width: 45%">
                        <tr>
                            <td colspan="2" style="width: 570px">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" CssClass="textox" Width="492px">
                                    <asp:ListItem>View All</asp:ListItem>
                                    <asp:ListItem>Search for perticular detail</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </table>
                </div>


                <div id="sa" runat="server" visible="false">
                    <div class="table-responsive">
                        <table class="table table-bordered table-condensed restable cent" style="width: 50%">
                            <tr>
                                <td style="width: 570px">

                                    <asp:Label ID="lDisputeId" runat="server" Text="Dispute Id"></asp:Label>
                                </td>
                                <td style="width: 570px">
                                    <asp:TextBox ID="txtDisputeId" runat="server" pattern="^[0-9]*$" title="Please enter numbers only" CssClass="textox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lCustomerId" runat="server" Text="Customer Id"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCustomerId" runat="server" CssClass="textox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>

                                <td colspan="2">

                                    <asp:Button ID="Button2" CssClass="button-red" Width="160px" runat="server" Text="Reset" OnClick="Button2_Click" CausesValidation="False" formnovalidate="formnovalidate" />
                                    <asp:Button ID="Button1" CssClass="button-green" Width="160px" runat="server" Text="Submit" OnClick="Button1_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <br />

                <div class="table-responsive">
                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed" runat="server" HeaderStyle-BackColor="#99ffcc" AutoGenerateColumns="false" ForeColor="#333333" HeaderStyle-ForeColor="#003300" CellPadding="4" GridLines="None" OnRowDataBound="GridView1_RowDataBound1" RowStyle-Wrap="false" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="Dispute_Id" DataField="Dispute_Id" />
                            <asp:BoundField HeaderText="Bill_Id" DataField="Bill_Id" />
                            <asp:BoundField HeaderText="Customer_Id" DataField="Customer_Id" ItemStyle-CssClass="hidden-phone" HeaderStyle-CssClass="hidden-phone" />
                            <asp:BoundField HeaderText="ConnectionNo" DataField="ConnectionNo" ItemStyle-CssClass="hidden-phone" HeaderStyle-CssClass="hidden-phone" />

                            <asp:BoundField HeaderText="_Status" DataField="Status" />
                            <asp:BoundField HeaderText="Comment" DataField="Comment" />
                            <asp:BoundField HeaderText="Problem" DataField="Problem" />
                            <asp:BoundField HeaderText="Dateofraise" DataField="DateOfRaise" DataFormatString="{0:MM/dd/yyyy}" />
                            <asp:BoundField HeaderText="Dateofresolve" DataField="DateOfResolve" DataFormatString="{0:MM/dd/yyyy}" />
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
    </div>
<%--    <script>
        $(document).ready(function () {
            $(function () {
                $('#<%=GridView1.ClientID %>').footable({
                    breakpoints: {
                        phone: 300,
                        tablet: 740,
                        screen: 1024
                    }
                });
            });
        });
    </script>--%>
</asp:Content>
