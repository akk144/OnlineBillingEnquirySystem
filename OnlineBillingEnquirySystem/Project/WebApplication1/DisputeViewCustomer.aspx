<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for viewing and deleteing a dispute by customer against perticular bill>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentCustomer.master" AutoEventWireup="true" CodeBehind="DisputeViewCustomer.aspx.cs" Inherits="WebApplication1.DisputeViewCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
       function delval() {
            if (confirm("Are you sure?")) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <br />
    <br />
    <br />
    <br />
    <br />

    <div class="container">

        
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <fieldset  style="width: 70%; margin-left: 15%">
                        <div class="table-responsive">
                            <table class="table table-bordered table-condensed restable" style="width:100%">
                                <tr>
                                    <td colspan="2">
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True" Width="615px" Height="18px">
                            <asp:ListItem>View All Dispute</asp:ListItem>
                            <asp:ListItem>View on particular Connections</asp:ListItem>
                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:850px">
                                        <asp:DropDownList ID="ConnectionnumList1" runat="server" CssClass="textox">
                            </asp:DropDownList>
                                    
                                        <asp:Button ID="submit" runat="server" CausesValidation="False" OnClick="submit_Click" OnClientClick="return dropval()" Text="Submit" CssClass="button-green" Height="35px" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </fieldset>







                    <%--<div>
                        </div>
                        <br />
                    <div>
                        <div>
                    </div>
                        <div>

                        </div>
                        <br />
                    </div>--%>
                    <br />
                    <br />
                    <br />
                    <div class="table-responsive">
                    <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="Dispute_Id" HeaderText="Dispute Id" />
                            <asp:BoundField DataField="Customer_id" HeaderText="Customer Id" />
                            <asp:BoundField DataField="ConnectionNo" HeaderText="Connection No" />
                            <asp:BoundField DataField="Bill_Id" HeaderText="Bill Id" />
                            <asp:BoundField DataField="Problem" HeaderText="Customer Problem" />
                            <asp:BoundField DataField="DateOfRaise" HeaderText="Date of Raise" />
                            <asp:BoundField DataField="Comment" HeaderText="Comment" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSelect" runat="server" OnClientClick="return delval()" Text="Delete" CommandName="Select" CssClass="btn-info"></asp:LinkButton>
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
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
</asp:Content>
