<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for updating a dispute status by admin after resolving call cost>
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="DisputeUpdateAdmin.aspx.cs" Inherits="WebApplication1.DisputeUpdateAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<meta name="viewport" content="width=device-width,initial-scale=1 maximum-scale = 1.0, user-scalable = no"" />--%>
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
    <script src="Javascript/bootstrap.min.js"></script>
    <script src="Javascript/jquery-1.8.2.js"></script>
    <link rel="stylesheet" href="CSS/footable-0.1.css" />
    <script src="Javascript/footable.js"></script>
    <link href="CSS/bootstrap-responsive1.min.css" rel="stylesheet" />


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <div class="cent">
            <asp:Label ID="lUpdate" runat="server" Text="Update Bill Disputes" Font-Bold="True" Font-Size="18px"></asp:Label>
        </div>
        <br />

        <div class="table-responsive">
        <asp:GridView ID="GridView1" CssClass="table table-bordered table-condensed"  runat="server" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="Dispute_Id">

                    <ItemTemplate>
                        <asp:Label ID="lDisputeId" runat="server" Text='<%# Bind("Dispute_Id") %>'></asp:Label>
                        <%--<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Dispute_Id") %>'></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bill_Id">

                    <ItemTemplate>

                        <asp:Label ID="lBillId" runat="server" Text='<%# Bind("Bill_Id") %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Customer_Id">

                    <ItemTemplate>
                        <asp:Label ID="lCustomerId" runat="server" Text='<%# Bind("Customer_Id") %>'></asp:Label>
                        <%-- <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Customer_Id") %>'></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ConnectionNo">

                    <ItemTemplate>
                        <asp:Label ID="lConnectionId" runat="server" Text='<%# Bind("ConnectionNo") %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="0">select</asp:ListItem>
                            <asp:ListItem Value="Resolve">Resolve</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lStatus" runat="server" Text='<%# Bind("Status") %>' ItemStyle-CssClass="hidden-phone" HeaderStyle-CssClass="hidden-phone"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Comment">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtComment" CssClass="textox" runat="server" Text='<%# Bind("Comment") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="txtComment" ForeColor="red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lComment" runat="server" Text='<%# Bind("Comment") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Problem">

                    <ItemTemplate>
                        <asp:Label ID="lProblem" runat="server" Text='<%# Bind("Problem") %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DateOfRaise">

                    <ItemTemplate>
                        <asp:Label ID="lDateOfRaise" runat="server" Text='<%# Bind("DateOfRaise") %>'></asp:Label>

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DateOfResolve">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDateOfResolve" CssClass="textox" runat="server" Enabled="false" Text='<%# System.DateTime.Now.ToShortDateString() %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lDateOfResolve" runat="server" Text='<%# Bind("DateOfResolve") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkBtnUpdate" CssClass="btn-info" runat="server" CausesValidation="True" CommandName="Update" Text="Resolve"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkBtnCancel" CssClass="btn-info" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkBtnEdit" CssClass="btn-info" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
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
        <br />



    </div>
    <div style="height: 420px"></div>

 <%--   <script>
        $(document).ready(function () {
            $(function () {
                $('#<%=GridView1.ClientID %>').footable({
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
