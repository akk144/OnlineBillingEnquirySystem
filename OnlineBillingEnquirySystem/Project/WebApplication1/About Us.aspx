<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="About Us.aspx.cs" Inherits="WebApplication1.About_Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
         .aboutus {
             box-shadow: 10px 10px 10pc rgb(255, 255, 255);
             font-size:19px;
         }
         .auto-style1 {
             box-shadow: 10px 10px 10pc rgb(255, 255, 255);
             font-size: 19px;
             text-align: justify;
         }
     </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <nav class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand page-scroll" href="#page-top">Online Telecom Bill Enquiry System</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li class="hidden">
                        <a href="#page-top"></a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Loginres.aspx">Home</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Contact Us.aspx">Contact Us</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="About Us.aspx">About</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Loginres.aspx">Logout</a>
                    </li>

                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>
    <div >
    <p class="auto-style1">
        &nbsp; &nbsp;Bharat Telecom Services Ltd is the largest provider of fixed phone, mobile and broadband services. 

We offer products for the home and individual users as well as corporate solutions to corporate clients (PABX, dedicated lines), international (long distance) calling services, calling cards, pay phones, credit card calling services. 

Our vision is “To be the #1 Telco under the Pacific Sun”. 

To achieve this we aim to have a workforce that is skilled and knowledgeable about all aspects of telecommunications and that is focused on meeting the everyday needs of our customers.

In return, our staff enjoy a range of benefits as well as the opportunity to be supported to obtain experience and qualifications in their chosen field of expertise.
    </p>
    </div>
    </asp:Content>