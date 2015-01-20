<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="CSS/bootstrap.min.css" />
    <link rel="stylesheet" href="CSS/bootstrap.css" />
    <script src="Javascript/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div>
                    <asp:Label ID="ldispute" runat="server" Text="Your Dispute Id is"></asp:Label></div>
            </div>
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div>
                    <asp:Label ID="ldisputeId" runat="server"></asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div id="bill" class=".col-xs-6 .col-sm-3">Bill Id</div>
            </div>
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div>
                    <asp:TextBox ID="billId" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div id="cusId">Customer Id</div>
            </div>
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div>
                    <asp:TextBox ID="customerId" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div id="connId">Connection Id</div>
            </div>
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div>
                    <asp:TextBox ID="connectionId" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div id="stat">Status</div>
            </div>
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div>
                    <asp:TextBox ID="stats" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div id="date">Date of Raise of Dispute</div>
            </div>
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div>
                    <asp:TextBox ID="disputeDate" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div id="prob">Problem Details</div>
            </div>
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div>
                    <asp:TextBox ID="problem" runat="server" required="required"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-3 col-md-6 col-lg-4">
            </div>
            <div class="col-sm-3 col-md-6 col-lg-4">
                <div >
                    <asp:Button ID="submit1" CssClass="btn-success" runat="server" Text="Submit" OnClick="submit1_Click"/>
                    <asp:Button ID="clear" runat="server" CssClass="btn-warning" Text="Clear" OnClick="clear_Click" />
                </div>

            </div>
        </div>

    </div>


</asp:Content>
