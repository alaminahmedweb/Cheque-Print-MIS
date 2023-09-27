<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckIssue.aspx.cs" Inherits="CheckPrintMIS.UI.CheckIssueUI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../Scripts/jquery.searchabledropdown-1.0.8.min.js"></script>
    <link href="../bootstrap-3.3.4-dist/css/bootstrap.css" rel="stylesheet" />
    <script src="../bootstrap-3.3.4-dist/js/bootstrap.js"></script>
    <link href="../Design/CSS/CheckIssue.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <nav class="navbar navbar-default">
            <div class="container-fluid">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">Medicon Pharma</a>
                </div>
                <ul class="nav navbar-nav">
                    <li class="active"><a href="Index.aspx">Home</a></li>
                    <li><a href="PartyInformation.aspx">Party Information</a></li>
                    <li><a href="BankInformationUI.aspx">Bank Information</a></li>
                    <li><a href="CheckIssue.aspx">Check Issue</a></li>
                    <li><a href="ReportUI.aspx">Reports</a></li>
                    <li><a href="UserLogin.aspx">Log Out</a></li>
                </ul>
            </div>
        </nav>
        <div class="container">
            <div class="panel panel-default" width="585px">
                <div class="panel-heading">
                    Cheque Issue
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label7" runat="server" Text="Tr No"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="trNoTextBox" Width="159px" runat="server" CssClass="col-md-9 form-control input-sm" placeholder="(Auto)"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row" id="party_row">
                        <div class="col-md-3">
                            <asp:Label ID="Label1" runat="server" Text="Party Name"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:DropDownList ID="partyDropdownList" Width="384px" runat="server" CssClass="col-md-9  input-sm"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row" id="bank_row">
                        <div class="col-md-3">
                            <asp:Label ID="Label2" runat="server" Text="Bank Name"></asp:Label>
                        </div>
                        <div class="col-md-7">
                            <asp:DropDownList ID="bankDropDownList" runat="server" CssClass="col-md-7 form-control input-sm"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label3" runat="server" Text="Amount"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="amountTextBox" runat="server" Width="159px" CssClass="col-md-9 form-control input-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label4" runat="server" Text="Cheque Date"></asp:Label>
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="chequeDateToTextBox" runat="server" />

                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="chequeDateToTextBox" Format="yyyy/MM/dd" runat="server"></ajaxToolkit:CalendarExtender>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label5" runat="server" Text="Remaks"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="remarksTextBox" TextMode="multiline" runat="server" Width="384px" CssClass="col-md-9 form-control input-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label6" runat="server" Text="Status"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:DropDownList ID="statusDropDownList" runat="server" Width="384px" CssClass="col-md-9 form-control input-sm">
                                <asp:ListItem>Account Payble</asp:ListItem>
                                <asp:ListItem>Cash</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="reprintButton" runat="server" type="submit" Width="330px" Text="Re-print" CssClass="btn btn-primary col-md-3" OnClick="reprintButton_Click" />
                            <asp:Button ID="saveButton" type="submit" runat="server" Width="330px" Text="Save & Preview" OnClientClick="return userValid()" CssClass="btn btn-primary col-md-3" OnClick="saveButton_Click" />
                        </div>
                    </div>
                </div>
            </div>

            <asp:GridView ID="outputGridView" runat="server" Visible="False" AutoGenerateColumns="false" OnSelectedIndexChanged="outputGridView_SelectedIndexChanged">
            </asp:GridView>
        </div>

        <%--<ajaxToolkit:ListSearchExtender ID="LSE" runat="server"
            TargetControlID="partyDropdownList"
            PromptText="Type to search"
            PromptCssClass="ListSearchExtenderPrompt"
            PromptPosition="Top"
            IsSorted="true" />--%>
        <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server"
            TargetControlID="reprintButton"
            ConfirmText="Are you sure you want Reprint?" />
        <%--  <ajaxToolkit:ListSearchExtender ID="ListSearchExtender1" runat="server"
            TargetControlID="bankDropDownList"
            PromptText="Type to search"
            PromptCssClass="ListSearchExtenderPrompt"
            PromptPosition="Top"
            IsSorted="true" />--%>
        <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server"
            TargetControlID="amountTextBox"
            FilterType="Custom, Numbers" />
    </form>

    <script>
        function userValid() {
            var bankCode, partyId, amount, chequeDate, remarks;
            bankCode = document.getElementById("bankCodeTextBox").value;
            partyId = document.getElementById("partyCodeTextBox").value;
            amount = document.getElementById("amountTextBox").value;
            chequeDate = document.getElementById("chequeDateTextBox").value;

            if (partyId == '') {
                document.getElementById("messageLabel").textContent = "Enter Party Id";
                return false;
            }
            else if (bankCode == '') {
                document.getElementById("messageLabel").textContent = "Enter Bank Code";
                return false;
            }

            else if (amount == '') {
                document.getElementById("messageLabel").textContent = "Enter Amount";
                return false;

            }
            else if (chequeDate == '') {
                document.getElementById("messageLabel").textContent = "Enter Cheque Date";
                return false;
            }
            else {
                return true;
            }
        }
    </script>


    <script type="text/javascript">
        $(document).ready(function () {
            $("select").searchable({
                maxListSize: 200, // if list size are less than maxListSize, show them all
                maxMultiMatch: 300, // how many matching entries should be displayed
                exactMatch: false, // Exact matching on search
                wildcards: true, // Support for wildcard characters (*, ?)
                ignoreCase: true, // Ignore case sensitivity
                latency: 200, // how many millis to wait until starting search
                warnMultiMatch: 'top {0} matches ...',
                warnNoMatch: 'no matches ...',
                zIndex: 'auto'
            });
        });

    </script>
    <%--<script>
        $('.datepicker').datepicker();
    </script>
    <script src="../Scripts/jquery-2.2.0.js"></script>--%>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/jquery.validate.min.js"></script>

</body>
</html>
