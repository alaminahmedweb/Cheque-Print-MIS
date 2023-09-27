<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PartyInformation.aspx.cs" Inherits="CheckPrintMIS.UI.PartyInformationUI" %>

<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=1.0.20229.24049, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">
        <ajax:ToolkitScriptManager ID="toolkit1" runat="server"></ajax:ToolkitScriptManager>
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
        <script src="../Scripts/jquery.tablePagination.0.1.js"></script>
        <script type="text/javascript">
            $(document).ready(
            function () {
                $('table').tablePagination({});
            });
        </script>

        <link href="../bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />
        <script src="../bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
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
                    Party Information
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label1" runat="server" Text="Code"></asp:Label>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="codeTextBox" runat="server" CssClass="col-md-7 form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="getPartyButton" runat="server" Text="Get Party" CssClass="btn btn-success" OnClick="getPartyButton_Click" />
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label2" runat="server" Text="Name"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="nameTextBox" runat="server" CssClass="col-md-9 form-control input-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="addressTextBox" TextMode="multiline" runat="server" CssClass="col-md-9 form-control input-sm"></asp:TextBox>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label4" runat="server" Text="Contact No"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="contactNoTextBox" runat="server" CssClass="col-md-9 form-control input-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label5" runat="server" Text="Contact Name"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="contactNameTextBox" runat="server" CssClass="col-md-9 form-control input-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label6" runat="server" Text="Status"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:DropDownList ID="statusDropDownList" runat="server" CssClass="col-md-6 form-control input-sm">
                                <asp:ListItem>Domestic</asp:ListItem>
                                <asp:ListItem>Foreign</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                <div class="panel-footer">
                    <div class="row">
                        <div class="btn-group col-md-12">
                            <asp:Button ID="printButton" runat="server" Text="Print" CssClass="btn btn-primary col-md-4" OnClick="printButton_Click" />
                            <asp:Button ID="updateButton" runat="server" OnClientClick="return userValid()" type="submit" Text="Update" CssClass="btn btn-primary col-md-4" OnClick="updateButton_Click" />
                            <asp:Button ID="saveButton" type="submit" OnClientClick="return userValid()" runat="server" Text="Save" CssClass="btn btn-primary col-md-4" OnClick="saveButton_Click" CausesValidation="False" />
                            <asp:Button ID="homeButton" runat="server" Text="Home" CssClass="btn btn-primary col-md-1" Visible="False" OnClick="homeButton_Click" />
                        </div>
                        <div class="col-md-2">
                        </div>
                    </div>
                </div>
            </div>

            <div class="well" style="width: 686px; text-align: center; font-size: 16px;">List of Party</div>
            <asp:GridView ID="outputGridView" runat="server" AutoGenerateColumns="False"
                PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" PageSize="5"
                RowStyle-CssClass="rows" AllowPaging="True" CssClass="mydatagrid" onprerender="outputGridView_PreRender" OnPageIndexChanging="outputGridView_PageIndexChanging">
                <Columns>

                    <asp:TemplateField HeaderText="SL#">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Party Id">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPartyId"><%# Eval("PartyId") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Party Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="PartyName"><%# Eval("PartyName") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Address">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Address"><%# Eval("Address") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contact No">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ContactNo"><%# Eval("ContactNo") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </form>

    <script>
        function userValid() {
            var code, name, address, contactNo, contactName;
            code = document.getElementById("codeTextBox").value;
            name = document.getElementById("nameTextBox").value;
            address = document.getElementById("addressTextBox").value;
            contactNo = document.getElementById("contactNoTextBox").value;
            contactName = document.getElementById("contactNameTextBox").value;

            if (code == '') {
                document.getElementById("messageLabel").textContent = "Enter Code";
                return false;

            }
            else if (name == '') {
                document.getElementById("messageLabel").textContent = "Enter Name";
                return false;
            }

            else if (address == '') {
                document.getElementById("messageLabel").textContent = "Enter Address";
                return false;

            }
            else if (contactNo == '') {
                document.getElementById("messageLabel").textContent = "Enter Contact No";
                return false;

            }
            else if (contactName == '') {
                document.getElementById("messageLabel").textContent = "Enter Contact Name";
                return false;

            }
            else {
                return true;
            }
        }
    </script>

    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../bootstrap-3.3.4-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Design/CSS/PartyInformation.css" rel="stylesheet" />
    <script src="../Scripts/jquery-2.2.0.min.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/Pager.js"></script>
</body>
</html>
