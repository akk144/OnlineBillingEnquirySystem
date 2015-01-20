<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for displaying the bill items for a specific bill to the admin>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="ViewBillItembyAdmin.aspx.cs" Inherits="WebApplication1.ViewBillItembyAdmin" %>



<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width,initial-scale=1 maximum-scale = 1.0, user-scalable = no"" />
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="Javascript/jquery-1.8.2.js"></script>
    <script src="Javascript/bootstrap.min.js"></script>
<%--    <link rel ="stylesheet" href="CSS/footable-0.1.css" />
    <script src="Javascript/footable.js"></script>--%>
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
                <asp:Label ID="LabelHeader" style="color: #0f4b94; font-size: medium" runat="server" Text="Call Details"></asp:Label>
                    <div class="table-responsive">
                    <asp:GridView ID="BillItemGrid" CssClass="table table-bordered table-condensed"  runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#99ffcc" HeaderStyle-ForeColor="#003300" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="true" OnPageIndexChanging="BillItemGrid_PageIndexChanging" PageSize="10">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField HeaderText="BillItem ID" DataField="BillItemId" />
                            <asp:BoundField HeaderText="Connection ID" DataField="ConnectionId" />
                            <asp:BoundField HeaderText="Date of call" DataField="DateOfCall" DataFormatString="{0:MM/dd/yyyy}" />
                            <asp:BoundField HeaderText="Call Duration" DataField="Duration" />
                            <asp:BoundField HeaderText="Number called" DataField="NumberCalled" />
                            <asp:BoundField HeaderText="Call type" DataField="CallType" />
                            <asp:BoundField HeaderText="Pulse rate" DataField="PulseRate" />
                            <asp:BoundField HeaderText="Call cost(INR)" DataField="CallCost" />

                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#636258" ForeColor="White" Font-Bold="True" />
                        <HeaderStyle BackColor="#636258" ForeColor="White" Font-Bold="True" />
                        <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
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
            <center>
        <div style="text-align: center;">
                    <asp:Button ID="Back" OnClick="Back_Click" CssClass="button-red" runat="server" Text="Back" />
                </div>
                </center>
        </div>
   <%--    <script>
           $(document).ready(function () {
               $(function () {
                   $('#<%=BillItemGrid.ClientID %>').footable({
                      breakpoints: {
                          phone: 300,
                          tablet: 540,
                          screen: 728
                      }
                  });
              });
          });
     </script>--%>
</asp:Content>
