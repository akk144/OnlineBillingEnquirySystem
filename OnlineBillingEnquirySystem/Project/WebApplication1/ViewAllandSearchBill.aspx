<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for Viewing all the generated bills for all the customers and searching for a specific bill and bill item by Id>
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
<%@ Page Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="ViewAllandSearchBill.aspx.cs" Inherits="WebApplication1.ViewAllandSearchBill" %>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <meta name="viewport" content="width=device-width,initial-scale=1 maximum-scale = 1.0, user-scalable = no"" />
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="Javascript/jquery-1.8.2.js"></script>
    <script src="Javascript/bootstrap.min.js"></script>
    <link rel ="stylesheet" href="CSS/footable-0.1.css" />
    <script src="Javascript/footable.js"></script>
    <script>
        function validate()
        {
            var x = document.getElementById("TxtBillId").value;
            var y = document.getElementById("TxtBillItemId").value;
            if (x == "" && y == "")
            {
                alert("Please enter a search field");
                return false;
            }
        }

    </script>
</asp:Content>



<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
<br />
    <br />
<br />
    <div style="text-align: center">    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="table-responsive">
                <asp:TextBox ID="TxtBillId" runat="server" pattern="^[0-9]*$" title="Please enter a number" ClientIDMode="Static" placeholder="Enter Bill Id" CssClass="textox"></asp:TextBox>
                
                <asp:TextBox ID="TxtBillItemId" runat="server" ClientIDMode="Static" pattern="^[0-9]*$" title="Please enter a number" placeholder="Enter Bill Item Id" CssClass="textox textbill"></asp:TextBox>
                <asp:Button ID="BtnSearchItem" runat="server" CssClass="button-green" Height="32px" Text="Search" OnClientClick="return validate();" OnClick="BtnSearchItem_Click" />
              
                <asp:GridView ID="BillsGrid"  CssClass="table table-bordered table-condensed" runat="server"  AutoGenerateColumns="False" OnSelectedIndexChanged="BillsGrid_SelectedIndexChanged" HeaderStyle-BackColor="#99ffcc" HeaderStyle-ForeColor="#003300" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="true" OnPageIndexChanging="BillsGrid_PageIndexChanging" PageSize="10">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField HeaderText="Bill ID" DataField="BillId" />
                        <asp:BoundField HeaderText="Customer Id" DataField="CustomerId" />
                        <asp:BoundField HeaderText="Connection Id" DataField="ConnectionId" />
                        <asp:BoundField HeaderText="Amount (INR)" DataField="Amount" />
                        <asp:BoundField HeaderText="Date of Generation" DataField="GenerateDate" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField HeaderText="Year" DataField="Year" />
                        <asp:BoundField HeaderText="Month" DataField="Month" />
                        <asp:BoundField HeaderText="Arrears (INR)" DataField="Arrears" />
                        <asp:BoundField HeaderText="Advanced Payment (INR)" DataField="AdvancedPayment" />
                        <asp:BoundField DataField="Discount" HeaderText="Discount (INR)" />
                        <asp:BoundField HeaderText="Total Amount(INR)" DataField="Total" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSelect"  runat="server" Text="Select" CommandName="Select" CssClass="btn-info"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
<%--    <script>
        
            $(function () {
                $('#<%=BillsGrid.ClientID %>').footable({
                    breakpoints: {
                        phone: 480,
                        tablet: 1024
                    }
                });
            });
        
     </script>--%>
</asp:Content>
