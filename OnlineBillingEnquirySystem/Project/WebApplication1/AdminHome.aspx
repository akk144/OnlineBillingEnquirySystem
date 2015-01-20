<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentAdmin.master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="WebApplication1.AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        

        
    </style>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
        <%--<img src="Images/2012_antenna_0060 (1).jpg" />--%>
    
    <table class="auto-style1" style="text-align: right">
        <tr style="text-align: right; color: black">
            <td style="text-align: right; color: black">
                 <asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" ForeColor="White" Text="Login Time:"></asp:Label>
                 <asp:Label ID="Label3" runat="server" ForeColor="White" ></asp:Label>
                <asp:Label ID="Label4" runat="server" ForeColor="White" ></asp:Label>&nbsp;&nbsp;&nbsp;
                <img src="img/logos/Admin.jpg" alt="Image Not found"/>
            </td>

        </tr>
    </table>
    <br />
    <%--<img src="Images/new3.jpg" />--%>
    
    <div class="container">
    <div style="float:left;" >
    <div class="canvastag1 box1">
         <div style="height:63px;"></div>
        <a href="AddBill.aspx">
        <p class="pstyle">Generate Bill</p></a>
    </div>
    <div class="canvastag1 box2 ">
        <div style="height:63px;"></div>
        <a href="ViewAllandSearchBill.aspx">
        <p class="pstyle">View All and Search Bill</p></a>
    </div>
    <div class="canvastag1 box3 ">
         <div style="height:63px;"></div>
        <a href="UpdateBill.aspx">
        <p class="pstyle">Update Bill</p></a>
        </div>
    </div>
    <div style="float:left;">
    <div class="canvastag1 box6 ">
         <div style="height:63px;"></div>
        <a href="ViewAllandSearchPayment.aspx">
        <p class="pstyle">View All and Search Payment</p></a>
    </div>
    <div class="canvastag1 box4">
         <div style="height:63px;"></div>
        <a href="DisputeViewAllandSearch.aspx">
        <p class="pstyle">Dispute View All and Search</p></a>
    </div>
    <div class="canvastag1 box5">
         <div style="height:63px;"></div>
        <a href="DisputeUpdateAdmin.aspx">
        <p class="pstyle">Update Dispute</p></a>
        </div>
    </div>
   </div>
       
</asp:Content>
