<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for Updating a bill for a customer and viewing the updated bill>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Akansh> Tata Consultancy Services
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

<%@ Page Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="UpdateBill.aspx.cs" Inherits="WebApplication1.UpdateBill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <meta name="viewport" content="width=device-width,initial-scale=1 maximum-scale = 1.0, user-scalable = no"" />
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="Javascript/bootstrap.min.js"></script>
    <script src="Javascript/jquery-1.8.2.js"></script>
<%--    <link rel ="stylesheet" href="CSS/footable-0.1.css" />
    <script src="Javascript/footable.js"></script>--%>
</asp:Content>
<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div style="text-align: center">
        <asp:Label ID="LabelHeader" CssClass="Three-Dee" runat="server" Text="Update list"></asp:Label>
        <div class="table-responsive">
            <asp:GridView ID="UpdateGrid" CssClass="table table-bordered table-condensed" runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#99ffcc" ForeColor="Black" HeaderStyle-ForeColor="#003300" OnSelectedIndexChanged="UpdateGrid_SelectedIndexChanged" CellPadding="4" GridLines="Vertical" AllowPaging="True" OnPageIndexChanging="UpdateGrid_PageIndexChanging" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" PageSize="10">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField HeaderText="Bill ID" DataField="BillId" />
                    <asp:BoundField HeaderText="Customer ID" DataField="CustomerId" />
                    <asp:BoundField HeaderText="Connection ID" DataField="ConnectionId" />
                    <asp:BoundField HeaderText="Amount" DataField="Amount" />
                    <asp:BoundField HeaderText="Generatedate" DataField="Generatedate" DataFormatString="{0:MM/dd/yyyy}" />
                    <asp:BoundField HeaderText="Year" DataField="Year" />
                    <asp:BoundField HeaderText="Month" DataField="Month" />
                    <asp:BoundField HeaderText="Arrears" DataField="Arrears" />
                    <asp:BoundField HeaderText="Advanced Payment" DataField="AdvancedPayment" />
                    <asp:BoundField HeaderText="Discount" DataField="Discount" />
                    <asp:BoundField HeaderText="Total" DataField="Total" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSelect" runat="server" Text="Update" CommandName="Select" CssClass="btn-info"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" ForeColor="White" Font-Bold="True" />
                <PagerStyle BackColor="#6B696B" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </div>
    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
  <%--  <center>
  <asp:button id="BtnUpdatedView" CssClass="button-green" runat="server" Enabled="false" text="View Updated Bill" OnClick="BtnUpdatedView_Click" />
   </center>
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
    <ajax:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
        targetcontrolid="BtnUpdatedView" popupcontrolid="UpdatedGrid" CancelControlID="BtnCancel" BackgroundCssClass="modalBackground">
    </ajax:ModalPopupExtender>

    <div class="table-responsive">
        <asp:GridView ID="UpdatedGrid" CssClass="table-bordered table-condensed table-hover" runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#99ffcc" ForeColor="#333333" HeaderStyle-ForeColor="#003300" CellPadding="4" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Bill ID" DataField="BillId" />
                <asp:BoundField HeaderText="Customer ID" DataField="CustomerId" />
                <asp:BoundField HeaderText="Connection ID" DataField="ConnectionId" />
                <asp:BoundField HeaderText="Amount" DataField="Amount" />
                <asp:BoundField HeaderText="Generatedate" DataField="GenerateDate" DataFormatString="{0:MM/dd/yyyy}" />
                <asp:BoundField HeaderText="Year" DataField="Year" />
                <asp:BoundField HeaderText="Month" DataField="Month" />
                <asp:BoundField HeaderText="Arrears" DataField="Arrears" />
                <asp:BoundField HeaderText="Advanced Payment" DataField="AdvancedPayment" />
                <asp:BoundField HeaderText="Discount" DataField="Discount" />
                <asp:BoundField HeaderText="Total" DataField="Total" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        </div>
       <center> 
       <input id="BtnCancel" type="button" value="Cancel" class="btn" style="margin-left:auto;margin-right:auto;width:7%" />
   </center>--%>
    
 <%--    <script>
         $(document).ready(function () {
             $(function () {
                 $('#<%=UpdateGrid.ClientID %>').footable({
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
