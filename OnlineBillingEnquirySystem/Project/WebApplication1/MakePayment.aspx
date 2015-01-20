<%--///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : <UI for making a payment by customer for perticular bill>
// ---------------------------------------------------------------------------------
// Date Created  : <14/11/2014>
// Author   : <Subnum> Tata Consultancy Services
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

<%@ Page Title="" Language="C#" MasterPageFile="~/BillPaymentCustomer.master" AutoEventWireup="true" CodeBehind="MakePayment.aspx.cs" Inherits="WebApplication1.MakePayment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <style type="text/css">
        

    </style>
    <script type="text/javascript">

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //
        // Function Name  : <checkamount>
        // Summary  : <Check bill amount less than payable amount>
        // Input Parameters : <bill amount,payable amount>
        // Output Parameters :<True/False>
        // Return Value  : <Return True,Alert message>
        //
        ///////////////////////////////////////////////////////////////////////////////////////////////
        function checkamount() {
            var billamt = document.getElementById("billamt").value;
            var payamt = document.getElementById("payamt").value;
            if (isNaN(payamt)) {
                alert("Please enter only numbers");
                document.getElementById("payamt").value = "";
                //document.getElementById("payamt").focus();
                return false;
            }
            if (billamt - payamt > 0) {
                alert("Payable amount should be greater than or equal to billamount");
                document.getElementById("payamt").value = "";
               // document.getElementById("payamt").focus();
                return false;
            }
        }


        function checkname() {
            var name = document.getElementById("namecard").value;
            if (!isNaN(name)) {
                alert("Please enter only alphabets");
                document.getElementById("namecard").value = "";
                //document.getElementById("namecard").focus();
                return false;
            }
        }


        function checknumber() {
            var RB2 = document.getElementById("<%=RadioButtonList2.ClientID%>");
            var radio1 = RB2.getElementsByTagName("input");
            var number = document.getElementById("cardnum").value;

            //var str = "The best things in life are free";
            var american = new RegExp("3[47][0-9]{13}");
            var res = american.test(number);
            var master = new RegExp("5[1-5][0-9]{14}");
            var res1 = master.test(number);
            var visa = new RegExp("4[0-9]{12}");
            var res2 = visa.test(number);
            var visa1 = new RegExp("4[0-9]{15}");
            var res3 = visa.test(number);
            var check = document.getElementById("cardnum").value.length;

            if (isNaN(number)) {
                alert("Please enter only digits");
                document.getElementById("cardnum").value = "";
               // document.getElementById("cardnum").focus();
                return false;
            }
            else if (check < 7) {
                alert("Invalid card number");
                document.getElementById("cardnum").value = "";
               // document.getElementById("cardnum").focus();
                return false;
            }
            else if (radio1[2].checked) {
                if (res) {
                    return true;
                }
                else {
                    alert("Invalid card number");
                    document.getElementById("cardnum").value = "";
                   // document.getElementById("cardnum").focus();
                    return false;
                }
            }


            else if (radio1[0].checked) {
                if (res1) {
                    return true;
                }
                else {
                    alert("Invalid card number");
                    document.getElementById("cardnum").value = "";
                   // document.getElementById("cardnum").focus();
                    return false;
                }
            }
            else if (radio1[1].checked) {
                if (res2 || res3) {
                    return true;
                }
                else {
                    alert("Invalid card number");
                    document.getElementById("cardnum").value = "";
                    //document.getElementById("cardnum").focus();
                    return false;
                }
            }

            else {
                alert("Invalid card number");
                document.getElementById("cardnum").value = "";
               // document.getElementById("cardnum").focus();
                return false;
            }

        }


        function checkcvv() {
            var number = document.getElementById("cvvnum").value;
            var check = document.getElementById("cvvnum").value.length;
            if (isNaN(number)) {
                alert("Please enter only digits");
                document.getElementById("cvvnum").value = "";
               // document.getElementById("cvvnum").focus();
                return false;
            }

            else if (check != 3 && check != 4) {
                alert("Cvvnumber number should be of 3 or 4 digits only");
                document.getElementById("cvvnum").value = "";
                //document.getElementById("cvvnum").focus();
                return false;
            }
            else {
                return true;
            }
        }


        function confirmcheck() {
            var a = confirm('Do you want to cancel the process?');
            return a;
        }




        function checkDate() {

            var dt = document.getElementById("expdate").value;
            var res = dt.split("/");
            var dt1 = res[0] + "/" + 01 + "/" + res[1];
            var dob = new Date(dt1);
            if (res.length == 3 || res.length == 1 || res.length > 3) {
                alert("Please enter date in the specified format");
                document.getElementById("expdate").value = "";
               // document.getElementById("expdate").focus();
                return false;
            }
            var sysdate = new Date();

            if (dob.getYear() < sysdate.getYear()) {
                alert("Card is already expired");
                document.getElementById("expdate").value = "";
                //document.getElementById("expdate").focus();
                return false;
            }
            else if (res[1] == sysdate.getYear()) {
                if (res[0] < sysdate.getMonth()) {

                    alert("Card is already expired");
                    document.getElementById("expdate").value = "";
                   // document.getElementById("expdate").focus();
                    return false;
                }
                if (res[0] > 12) {
                    alert("Please enter correct month");
                    document.getElementById("expdate").value = "";
                   // document.getElementById("expdate").focus();
                    return false;
                }

            }
            else if (res[1] > sysdate.getYear()) {
                if (res[0] > 12) {
                    alert("Please enter correct month");
                    document.getElementById("expdate").value = "";
                   // document.getElementById("expdate").focus();
                    return false;
                }

            }

            else {
                return true;
            }
        }




        function confirmpayment()
        {
            //amount check
            var drop = document.getElementById("DropDownList1").value;
            if (drop == "0") {
                alert("Please enter all the required fields");
                return false;
            }

            var bill = document.getElementById("billamt").value;
            var pay = document.getElementById("payamt").value;
            if (bill == "" || pay == "") {
                alert("Please enter all the required fields");
                return false;
            }

            //check card field
            var RB1 = document.getElementById("<%=RadioButtonList1.ClientID%>");
            var radio = RB1.getElementsByTagName("input");
            var isChecked = false;
            for (var i = 0; i < radio.length; i++) {
                if (radio[0].checked) {
                    isChecked = true;
                    break;
                }
                if (radio[1].checked) {
                    isChecked = true;
                    break;
                }
                if (radio[2].checked) {
                    isChecked = true;
                    break;
                }
            }

            if (isChecked) {
                if (radio[0].checked) {

                    var h = document.getElementById("DropDownList2").value;
                    if (h == "0") {
                        alert("Please enter all the fields required for Internet Banking");
                        return false;
                    }
                }
                if (radio[1].checked) {
                    var h = document.getElementById("DropDownList2").value;
                    var RB2 = document.getElementById("<%=RadioButtonList2.ClientID%>");
                    var radio1 = RB2.getElementsByTagName("input");
                    var isChecked1 = false;
                    for (var i = 0; i < radio1.length; i++) {
                        if (radio1[0].checked) {
                            isChecked1 = true;
                            break;
                        }
                        if (radio1[1].checked) {
                            isChecked1 = true;
                            break;
                        }
                        if (radio1[2].checked) {
                            isChecked1 = true;
                            break;
                        }
                    }
                    if (!isChecked1) {
                        alert("Please enter all the fields required for card payment");
                        return false;
                    }
                    if (h == "0") {
                        alert("Please enter all the fields required for card payment");
                        return false;
                    }

                }
                if (radio[2].checked)
                {
                    var h = document.getElementById("DropDownList2").value;
                    var RB2 = document.getElementById("<%=RadioButtonList2.ClientID%>");
                    var radio1 = RB2.getElementsByTagName("input");
                    var isChecked1 = false;
                    for (var i = 0; i < radio1.length; i++) {
                        if (radio1[0].checked) {
                            isChecked1 = true;
                            break;
                        }
                        if (radio1[1].checked) {
                            isChecked1 = true;
                            break;
                        }
                        if (radio1[2].checked) {
                            isChecked1 = true;
                            break;
                        }
                    }
                    if (!isChecked1) {
                        alert("Please enter all the fields required for card payment");
                        return false;
                    }
                    if (h == "0") {
                        alert("Please enter all the fields required for card payment");
                        return false;
                    }
                }

            }
            else
            {
                alert("Please select mode of payment");
                return false;
            }
                //check cardtype
                var RB2 = document.getElementById("<%=RadioButtonList2.ClientID%>");
                var radio1 = RB2.getElementsByTagName("input");
                if (radio1[0].checked || radio1[1].checked || radio1[2].checked || radio[1].checked || radio[2].checked) {
                    var c = document.getElementById("namecard").value;
                    var d = document.getElementById("cardnum").value;
                    var e = document.getElementById("expdate").value;
                    var f = document.getElementById("cvvnum").value;

                    if (c == "" || d == "" || e == "" || f == "") {
                        alert("Please enter all the fields required for card payment");
                        return false;
                    }

                    //card number validation

                    var number = document.getElementById("cardnum").value;
                    var american = new RegExp("3[47][0-9]{13}");
                    var res = american.test(number);
                    var master = new RegExp("5[1-5][0-9]{14}");
                    var res1 = master.test(number);
                    var visa = new RegExp("4[0-9]{12}");
                    var res2 = visa.test(number);
                    var visa1 = new RegExp("4[0-9]{15}");
                    var res3 = visa.test(number);
                    if (radio1[2].checked) {
                        if (res) {
                            return true;
                        }
                        else {
                            alert("Invalid card number");
                            document.getElementById("cardnum").value = "";
                           // document.getElementById("cardnum").focus();
                            return false;
                        }
                    }
                    else if (radio1[0].checked) {
                        if (res1) {
                            return true;
                        }
                        else {
                            alert("Invalid card number");
                            document.getElementById("cardnum").value = "";
                           // document.getElementById("cardnum").focus();
                            return false;
                        }
                    }
                    else if (radio1[1].checked) {
                        if (res2 || res3) {
                            return true;
                        }
                        else {
                            alert("Invalid card number");
                            document.getElementById("cardnum").value = "";
                           // document.getElementById("cardnum").focus();
                            return false;
                        }
                    }
                    else {
                        alert("Invalid card number");
                        document.getElementById("cardnum").value = "";
                        //document.getElementById("cardnum").focus();
                        return false;
                    }
                }
            
            else {
                alert("Please enter all the required fields");
                return false;
            }
            return isChecked;
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajax:ToolkitScriptManager runat="server"></ajax:ToolkitScriptManager>
    <div class="container">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <br />
                <br />
                <br />
                <br />

                <div class="table-responsive table-bordered table-condensed restable">
                    <div style="text-align:center;color:white;">
                         <asp:Label ID="Label2" CssClass="form-control" runat="server" Text="Payment Details"></asp:Label></div>
                      <table style="margin-left:35%">
                      <%--  <tr>
                            <td colspan="3">Payment Details</td>
                        </tr>--%>
                        <br /><br /><br /><br />
                        <tr>
                            <td><asp:Label ID="Label3" CssClass="form-control" runat="server" Text="Customer Id"></asp:Label></td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="custid" runat="server" ForeColor="Black" CssClass="textox" ClientIDMode="Static"></asp:TextBox>
                                <asp:Label ID="Label1" CssClass="form-control" runat="server"></asp:Label>
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td><asp:Label ID="Label4" CssClass="form-control" runat="server" Text="Connection Number"></asp:Label></td>
                            <td></td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" CssClass="textox" runat="server" ForeColor="Black" AutoPostBack="true" ClientIDMode="Static" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter connection number" ControlToValidate="DropDownList1" ForeColor="Red" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator></td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lblbillamt" CssClass="form-control" runat="server" Text="Bill Amount"></asp:Label></td>
                            <td></td>
                            <td>
                                <asp:TextBox ID="billamt" runat="server" ForeColor="Black" CssClass="textox" ClientIDMode="Static"></asp:TextBox>
                                <asp:Label ID="Lblinr" CssClass="form-control"  runat="server" Text="INR"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lblpayamt" CssClass="form-control" runat="server" Text="Payable Amount"></asp:Label></td><td></td>
                            <td>
                                <asp:TextBox ID="payamt" runat="server" ForeColor="Black" CssClass="textox" ClientIDMode="Static" onblur="javascript:checkamount();"></asp:TextBox>
                                <asp:Label ID="Lblinr1" CssClass="form-control" runat="server" Text="INR"></asp:Label>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter payable amount" ControlToValidate="payamt" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
                            </td>
                        </tr>
                           
                        <tr>
                            <td>
                                <asp:Label ID="Lblpaymode" CssClass="form-control" runat="server" Text="Mode Of Payment"></asp:Label></td><td></td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList1" AutoPostBack="true" ClientIDMode="Static" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                    <asp:ListItem Value="Internet Banking">Internet Banking</asp:ListItem>
                                    <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                                    <asp:ListItem Value="Debit Card">Debit Card</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select mode of payment" ControlToValidate="RadioButtonList1" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lblbnkname" CssClass="form-control" runat="server" Text="Bank Name"></asp:Label></td><td></td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" CssClass="textox" ForeColor="Black" runat="server" ClientIDMode="Static">
                                    <asp:ListItem Value="0">Select Bank</asp:ListItem>
                                    <asp:ListItem Value="ALLAHABAD BANK">ALLAHABAD BANK</asp:ListItem>
                                    <asp:ListItem Value="AXIS BANK">AXIS BANK</asp:ListItem>
                                    <asp:ListItem Value="BANK OF BARODA">BANK OF BARODA</asp:ListItem>
                                    <asp:ListItem Value="BANK OF INDIA">BANK OF INDIA</asp:ListItem>
                                    <asp:ListItem Value="CANARA BANK">CANARA BANK</asp:ListItem>
                                    <asp:ListItem Value="HDFC BANK LTD">HDFC BANK LTD</asp:ListItem>
                                    <asp:ListItem Value="ICICI BANK LTD">ICICI BANK LTD</asp:ListItem>
                                    <asp:ListItem Value="IDBI BANK LTD">IDBI BANK LTD</asp:ListItem>
                                    <asp:ListItem Value="INDIAN BANK">INDIAN BANK</asp:ListItem>
                                    <asp:ListItem Value="STATE BANK OF INDIA">STATE BANK OF INDIA</asp:ListItem>
                                    <asp:ListItem Value="SYNDICATE BANK">SYNDICATE BANK</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownList2" ErrorMessage="Please select bank name" ForeColor="Red" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                
                        <tr>
                            <td>
                                <asp:Label ID="Lblcardtype" CssClass="form-control" runat="server" Text="Card Type"></asp:Label>
                            </td><td></td>
                            <td>
                                <asp:RadioButtonList ID="RadioButtonList2" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" ClientIDMode="Static" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="Master Card">Master Card</asp:ListItem>
                                    <asp:ListItem Value="Visa Card">Visa Card</asp:ListItem>
                                    <asp:ListItem Value="American Express">American Express</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                
                        <tr>
                            <td>
                                <asp:Label ID="Lblcardnum" CssClass="form-control" runat="server" Text="Card Number" /></td><td></td>
                            <td>
                                <asp:TextBox ID="cardnum" ForeColor="Black" runat="server" CssClass="textox" ClientIDMode="Static" onblur="javascript:checknumber();"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" TargetControlID="cardnum" Enabled="true" FilterType="Numbers" runat="server"></ajax:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lblnamecard" CssClass="form-control" runat="server" Text="Name On Card" /></td><td></td>
                            <td>
                                <asp:TextBox ID="namecard" ForeColor="Black" CssClass="textox" runat="server" ClientIDMode="Static" onblur="javascript:checkname();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lblexpdate" CssClass="form-control" runat="server" Text="Expiry Date(mm/yyyy)" /></td><td></td>
                            <td>
                                <asp:TextBox ID="expdate" ForeColor="Black" CssClass="textox" runat="server" ClientIDMode="Static" onblur="javascript:checkDate();"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label CssClass="form-control" ID="Lblcvvnum" runat="server" Text="Cvv Number" /></td><td></td>
                            <td>
                                <asp:TextBox ID="cvvnum" ForeColor="Black" CssClass="textox" runat="server" ClientIDMode="Static" TextMode="Password" onblur="javascript:checkcvv();"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" TargetControlID="cvvnum" Enabled="true" FilterType="Numbers" runat="server"></ajax:FilteredTextBoxExtender>
                            </td>
                        </tr>
                        <tr>
                            <td></td><td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="Button1" CssClass="button-green" runat="server" Text="Pay Bill" OnClick="Button1_Click" OnClientClick="return confirmpayment();" />
                                <asp:Button ID="Button2" CssClass="button-red" runat="server" Text="Cancel" OnClick="Button2_Click" OnClientClick="return confirmcheck();" />
                            </td>
                        </tr>
                    </table>
                                      </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
