<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentCustomer.master" AutoEventWireup="true" CodeBehind="CustomerHome.aspx.cs" Inherits="WebApplication1.CustomerHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table class="auto-style1" style="text-align: right; margin-left:800px">
        <tr style="text-align: right; color: black">
            <td style="text-align: right; color: black;">
              
                <asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Login Time:"></asp:Label>
                <asp:Label ID="Label3" runat="server" ForeColor="White" ></asp:Label>
                <asp:Label ID="Label4" runat="server" ForeColor="White" ></asp:Label>
                <asp:Label ID="Label5" runat="server" ForeColor="White" ></asp:Label>&nbsp;&nbsp;&nbsp;
                <img  src="img/logos/Admin.jpg" alt="Image Not found"/>
           </td>
        </tr>
    </table>
    <br />
    <div class="container">
    <div style="float:left;" >
    <div class="canvastag1 box1">
         <div style="height:63px;"></div>
        <a href="ViewBill.aspx">
        <p class="pstyle">View Bill</p></a>
    </div>
    <div class="canvastag1 box2 ">
         <div style="height:63px;"></div>
        <a href="MakePayment.aspx">
        <p class="pstyle">Make Payment</p></a>
    </div>
       
       
    <div class="canvastag1 box3 ">
         <div style="height:63px;"></div>
        <a href="CustomerView.aspx">
        <p class="pstyle">View Payment</p></a>
        </div>
         </div>
         <div style="float:left;">
    <div class="canvastag1 box1 ">
         <div style="height:63px;"></div>
        <a href="DisputeViewCustomer.aspx">
        <p class="pstyle">View Dispute</p></a>
    </div>
  
    <div class="canvastag1 box4 ">
         <div style="height:63px;"></div>
        <a href="DisputeAdd.aspx">
        <p class="pstyle">Add Dispute</p></a>
    </div>
</div>
        </div>
   <%-- <div class="canvastag1 box5 spin">
        <a href="DisputeUpdateAdmin.aspx">
        <p style=" margin-top: 63px;">Dispute Update Admin</p></a>
        </div>
    </div>
   <img src="Images/new3.jpg" />--%>
</asp:Content>
