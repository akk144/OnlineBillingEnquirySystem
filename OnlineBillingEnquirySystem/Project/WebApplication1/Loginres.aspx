<%@ Page Title="" Language="C#" MasterPageFile="~/Login1.Master" AutoEventWireup="true" CodeBehind="Loginres.aspx.cs" Inherits="WebApplication1.Loginres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Login</title>

    <!-- Bootstrap Core CSS -->
    <link href="CSS/bootstrap.min.css" rel="stylesheet" />
   <%-- <link rel="stylesheet" href="CSS/grayscale.css" />--%>
    <!-- Custom CSS -->
    <link href="CSS/agency.css" rel="stylesheet" />
    <link rel="stylesheet" href="MasterStyleSheet.css" />
    <!-- Custom Fonts -->
    <link href="font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Kaushan+Script' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Droid+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700' rel='stylesheet' type='text/css' />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

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
                <a class="navbar-brand page-scroll" href="#page-top">Bharat Tele Services</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li class="hidden">
                        <a href="#page-top"></a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#">Home</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="Contact Us.aspx">Contact Us</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="About Us.aspx">About</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#contact">Login</a>
                    </li>

                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>

    <!-- Header -->
    <header>
        <div class="container">
            <div class="intro-text">
                <div class="intro-lead-in">Bharat Tele Services</div>
                <div class="intro-heading">Making Great Things Possible.</div>

            </div>
        </div>
    </header>

    <section id="contact">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 text-center">
                    <h2 class="service-heading" style="color:white; " >Manage Your Accounts</h2>
                    <h3 class="section-subheading text-muted"></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">                           
                                <asp:TextBox ID="TextBox3" CssClass="textox" runat="server" required="required" title="Please enter User Name" placeholder="Enter User Id" pattern="^[0-9,a-z,A-Z]*$" ></asp:TextBox>
                                <p class="help-block text-danger"></p>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox1" TextMode="Password" CssClass="textox" runat="server" required="required" title="Please enter Password" placeholder="Enter Password"></asp:TextBox>
                                <p class="help-block text-danger"></p>
                            </div>
                        </div>

                        <div class="clearfix"></div>
                        <div class="col-md-6">
                            <div id="success"></div>
                            <asp:Button ID="Button1" runat="server" Text="Login" CssClass="button-green" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server"  Text="Clear" CssClass="button-red" CausesValidation="false" OnClick="Button2_Click" formnovalidate="formnovalidate"/>
                        </div>
                    </div>


                </div>
            </div>
        </div>
    </section>

    <!-- jQuery -->
    <script src="Javascript/jquery-2.1.1.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="Javascript/bootstrap.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="http://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
    <script src="Javascript/classie.js"></script>
    <script src="Javascript/cbpAnimatedHeader.js"></script>

    <!-- Contact Form JavaScript -->
    <%--<script src="Javascript/jqBootstrapValidation.js"></script>--%>
<%--    <script src="Javascript/contact_me.js"></script>--%>

    <!-- Custom Theme JavaScript -->
    <script src="Javascript/agency.js"></script>
</asp:Content>
