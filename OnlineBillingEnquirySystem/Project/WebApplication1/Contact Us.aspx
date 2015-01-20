<%@ Page Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Contact Us.aspx.cs" Inherits="WebApplication1.Contact_Us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
    <section class="mainsection">
        <table>
            <tr>
                <td>
                    <label>
                        Address: TCS,Technopark Campus Trivandrum,
                                     Technopark, Trivandrum - 695581</label>
                </td>

            </tr>
            <tr>
                <td>
                    <label>Contact Number: 0471-6629400/6629400</label>
                </td>
            </tr>
            <tr>
                <td>
                    <label style="margin-left: 10%">
                        <iframe width="425" height="350" src="https://maps.google.com/maps?f=q&amp;source=s_q&amp;hl=en&amp;geocode=&amp;q=TCS+Technopark+Campus+Trivandrum,+Technopark,+Trivandrum+-+695581&amp;aq=&amp;sll=42.536892,-101.425781&amp;sspn=9.46841,21.643066&amp;ie=UTF8&amp;hq=&amp;hnear=TCS+Peepul+Park,+Technopark+Campus,+Kazhakkoottam,+Thiruvananthapuram,+Kerala+695581,+India&amp;ll=8.552525,76.879843&amp;spn=0.006207,0.010568&amp;t=m&amp;z=14&amp;output=embed"></iframe>
                        <br />
                        <small><a href="https://maps.google.com/maps?f=q&amp;source=embed&amp;hl=en&amp;geocode=&amp;q=TCS+Technopark+Campus+Trivandrum,+Technopark,+Trivandrum+-+695581&amp;aq=&amp;sll=42.536892,-101.425781&amp;sspn=9.46841,21.643066&amp;ie=UTF8&amp;hq=&amp;hnear=TCS+Peepul+Park,+Technopark+Campus,+Kazhakkoottam,+Thiruvananthapuram,+Kerala+695581,+India&amp;ll=8.552525,76.879843&amp;spn=0.006207,0.010568&amp;t=m&amp;z=14" style="color: #0000FF; text-align: center">View Larger Map</a></small></label>
                </td>
            </tr>
        </table>
    </section>
</asp:Content>

