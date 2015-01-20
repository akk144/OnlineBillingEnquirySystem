<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for Viewing all the payments of all the customers and searching for a specific payment by customer id and connection id>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Snehal,Subnum> Tata Consultancy Services
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="ViewAllandSearchPayment.aspx.cs" Inherits="WebApplication1.ViewAllandSearchPayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <%-- <meta name="viewport" content="width=device-width,initial-scale=1 maximum-scale = 1.0, user-scalable = no"" />--%>
<%--    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="Javascript/bootstrap.min.js"></script>--%>
      <meta name="viewport" content="width=device-width,initial-scale=1 maximum-scale = 1.0, user-scalable = no"" />
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
        <script src="Javascript/jquery-1.9.1.min.js"></script>
    <script src="Javascript/bootstrap.min.js"></script>

<%--    <link rel ="stylesheet" href="CSS/footable-0.1.css" />
    <script src="Javascript/footable.js"></script>--%>
    <script>
        function check() {
            var a = document.getElementById("TextBox1").value;
            var b = document.getElementById("TextBox2").value;
            if (a == "" && b == "") {
                alert('Please enter Customer id or Connection number');
                return false;
            }
            else if (isNaN(b)) {
                alert('Enter Digits only.');
                return false;
            }
        }
        function validate()
        {
            document.getElementById("TextBox1").value="";
            document.getElementById("TextBox2").value="";
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <br />
    <br />
    <asp:ToolkitScriptManager runat="server"></asp:ToolkitScriptManager>

    <asp:Panel ID="Panel1" runat="server" Height="29px" Width="300px" BackColor="#636258">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem Value="View All Payments"> View All Payments</asp:ListItem>
            <asp:ListItem Value="Search Payment"> Search Payment</asp:ListItem>
        </asp:RadioButtonList></asp:Panel>
        <br />
        <div class="container">
            <fieldset style="width: 60%; margin-left: 15%;">
                <div class="table-responsive">
                    <div id="tab1" runat="server">
                        <table class="table table-bordered table-condensed restable cent" style="width:100%">
                            <tr>

                                <td colspan="2">
                                    <asp:Label ID="Label4" runat="server" Text="Search PaymentDetails By Customer id/Connection number" Font-Bold="true" CssClass="form-control"></asp:Label></td>
                            </tr>

                            <tr>
                                <td style="width:850px">
                                    <asp:Label ID="Label1" runat="server" Text="Customer Id" Width="150px" CssClass="form-control"></asp:Label></td>
                                <td style="width:850px">
                                    <asp:TextBox ID="TextBox1" runat="server" ClientIDMode="Static" placeholder="Customer Id" CssClass="textox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Connection Number" Width="170px" CssClass="form-control"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" ClientIDMode="Static" placeholder="Connection Number" CssClass="textox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2">

                                    <asp:Button ID="Button2" runat="server" CssClass="button-red" Text="Reset" OnClick="Button2_Click" OnClientClick="javascript:return validate();" Width="108px" />

                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" CssClass="button-green" Text="Search" OnClick="Button1_Click" Width="108px" OnClientClick="javascript:return check();" />
                                </td>
                            </tr>

                        </table>

                    </div>
                </div>
            </fieldset>
        </div>
        <br />
        <br />
<%--    <asp:UpdatePanel runat="server">
        <ContentTemplate>--%>
        
        <asp:Label ID="Label2" runat="server" Width="250px" Text="Payment Details" ForeColor="White" Font-Bold="True" Font-Size="X-Large" Style="margin-left: 40px"></asp:Label>

        <br />
        <br />
        
                <div class="table-responsive">
                <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed"   runat="server" HeaderStyle-BackColor="#99ffcc" AutoGenerateColumns="False" ForeColor="#333333" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" HeaderStyle-ForeColor="#003300" CellPadding="4" GridLines="None" PageSize="10" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

                    <Columns>
                        <asp:BoundField HeaderText="Payment Id" DataField="Payment_Id" />
                        <asp:BoundField HeaderText="Customer Id" DataField="Customer_Id" />
                        <asp:BoundField HeaderText="Customer Name" DataField="Customer_Name" />
                        <asp:BoundField HeaderText="Connection Number" DataField="Connection_Id" />
                        <asp:BoundField HeaderText="Bill Id" DataField="Bill_Id" />
                        <asp:BoundField HeaderText="Bill Amount (INR)" DataField="Bill_Amount" />
                        <asp:BoundField HeaderText="Amount Paid (INR)" DataField="Payable_Amount" />
                        <asp:BoundField HeaderText="Advance Amount (INR)" DataField="Advance_Amount" />
                        <asp:BoundField HeaderText="Arrears (INR)" DataField="Arrears" />
                        <asp:BoundField HeaderText="Payment Date(mm/dd/yyyy)" DataField="Date" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton CssClass="btn-info" ID="lnkSelect" runat="server" Text="View" HeaderText="Action" CommandName="Select" ForeColor="#5D7B9D"></asp:LinkButton>
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

  <%--       <script>
             $(document).ready(function () {
                 $(function () {
                     $('#<%=GridView1.ClientID %>').footable({
                         breakpoints: {
                             phone: 480,
                             tablet: 728,
                             screen: 1024
                         }
                     });
                 });
             });
     </script> --%> 

    <asp:DropShadowExtender ID="Panel1_DropShadowExtender" runat="server"
        Enabled="True" TargetControlID="Panel1" Opacity="1"
        Width="5">
    </asp:DropShadowExtender>
      <%--      </ContentTemplate>
</asp:UpdatePanel>--%>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <%--<asp:Button Text="" ID="btnShow" runat="server" />--%>

    <%--<asp:ModalPopupExtender BackgroundCssClass="modalBackground" ID="ModalPopupExtender1" runat="server" TargetControlID="RadioButtonList1"  DropShadow="true" PopupControlID="panelView" CancelControlID="btnClose"></asp:ModalPopupExtender>--%>
<%--    <script>
        //$(document).ready(function () {
            $(function () {
                $('#<%=GridView1.ClientID %>').footable({
                    breakpoints: {
                        phone: 480,
                        tablet: 728                        
                    }
                });
            });
        //});
    </script>--%>
</asp:Content>
