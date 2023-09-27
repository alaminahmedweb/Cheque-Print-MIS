<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportUI.aspx.cs" Inherits="CheckPrintMIS.UI.ReportUI" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script src="../Scripts/jquery.searchabledropdown-1.0.8.min.js"></script>
        <link href="../Design/CSS/Reports.css" rel="stylesheet" />
        <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
        <link href="../bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />
        <script src="../bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
        <div>
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
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Reports
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Label ID="Label1" runat="server" Text="Bank Code"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="bankDropDownList" runat="server" CssClass="col-md-2 form-control input-sm"></asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <asp:Label ID="Label2" runat="server" Text="Date From"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="chequeDateFromTextBox" runat="server" />
                                <ajax:CalendarExtender ID="CalendarExtender1" TargetControlID="chequeDateFromTextBox" Format="yyyy/MM/dd" runat="server"></ajax:CalendarExtender>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="Label3" runat="server" Text="Date To"></asp:Label>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="chequeDateToTextBox" runat="server" />
                                <ajax:CalendarExtender ID="CalendarExtender2" TargetControlID="chequeDateToTextBox" Format="yyyy/MM/dd" runat="server"></ajax:CalendarExtender>
                            </div>
                        </div>

                        <div class="row" id="party_row">
                            <div class="col-md-2">
                                <asp:Label ID="Label4" runat="server" Text="Party Name"></asp:Label>
                            </div>
                            <div class="col-md-9">
                                <asp:DropDownList ID="partyDropdownList" Width="384px" runat="server" CssClass="col-md-9  input-sm"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div>
                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </div>

                    <div class="row" id="btn_row">
                        <div class="col-md-4">
                            <asp:Button ID="partyInfoButtonButton" runat="server" Text="Party Inforamtion" CssClass="btn btn-primary" OnClick="partyInfoButton_Click" Width="373px" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="bankInfoButtonButton" runat="server" Text="Bank Information" CssClass="btn btn-primary" OnClick="bankInfoButtonButton_Click" Width="373px" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="checkInfoButton" runat="server" Text="Daily Check Information (Cheque Date Wise)" CssClass="btn btn-primary" OnClick="checkInfoButton_Click" Width="353px" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        <%--<ajaxToolkit:ListSearchExtender ID="LSE" runat="server"
            TargetControlID="partyDropdownList"
            PromptText="Type to search"
            PromptCssClass="ListSearchExtenderPrompt"
            PromptPosition="Top"
            IsSorted="true" />--%>
    </form>
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
    <style type="text/css">
        /*Calendar Control CSS*/
        .cal_Theme1 .ajax__calendar_container {
            background-color: #DEF1F4;
            border: solid 1px #77D5F7;
        }

        .cal_Theme1 .ajax__calendar_header {
            background-color: #ffffff;
            margin-bottom: 4px;
        }

        .cal_Theme1 .ajax__calendar_title,
        .cal_Theme1 .ajax__calendar_next,
        .cal_Theme1 .ajax__calendar_prev {
            color: #004080;
            padding-top: 3px;
        }

        .cal_Theme1 .ajax__calendar_body {
            background-color: #ffffff;
            border: solid 1px #77D5F7;
        }

        .cal_Theme1 .ajax__calendar_dayname {
            text-align: center;
            font-weight: bold;
            margin-bottom: 4px;
            margin-top: 2px;
            color: #004080;
        }

        .cal_Theme1 .ajax__calendar_day {
            color: #004080;
            text-align: center;
        }

        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year,
        .cal_Theme1 .ajax__calendar_active {
            color: #004080;
            font-weight: bold;
            background-color: #DEF1F4;
        }

        .cal_Theme1 .ajax__calendar_today {
            font-weight: bold;
        }

        .cal_Theme1 .ajax__calendar_other,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today,
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title {
            color: #bbbbbb;
        }
    </style>

</body>
</html>
