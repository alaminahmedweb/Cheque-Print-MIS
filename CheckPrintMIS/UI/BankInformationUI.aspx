<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankInformationUI.aspx.cs" Inherits="CheckPrintMIS.UI.BankInformationUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Design/CSS/BankInformation.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server" class="form-horizontal">

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
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
            <div class="panel panel-default" >
                <div class="panel-heading">
                    Bank Information
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label1" runat="server" Text="Bank Code"></asp:Label>
                        </div>
                        <div class="col-md-7">
                            <asp:TextBox ID="codeTextBox" runat="server" CssClass="col-md-7 form-control input-sm"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <asp:Button ID="getBankButton" runat="server" Text="Get Party" CssClass="btn btn-success" OnClick="getBankButton_Click" />
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
                            <asp:Label ID="Label3" runat="server" Text="Branch Name"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="branchTextBox" runat="server" CssClass="col-md-9 form-control input-sm"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label4" runat="server" Text="Account No"></asp:Label>
                        </div>
                        <div class="col-md-9">
                            <asp:TextBox ID="accountNoTextBox" runat="server" CssClass="col-md-9 form-control input-sm"></asp:TextBox>
                        </div>
                    </div>
                    <div>
                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="printButton" runat="server" Text="Print" CssClass="btn btn-primary col-md-4" OnClick="printButton_Click" />
                            <asp:Button ID="updateButton" runat="server" OnClientClick="return userValid()" type="submit" Text="Update" CssClass="btn btn-primary col-md-4" OnClick="updateButton_Click" />
                            <asp:Button ID="saveButton" type="submit" OnClientClick="return userValid()" runat="server" Text="Save" CssClass="btn btn-primary col-md-4" OnClick="saveButton_Click" />
                            <asp:Button ID="homeButton" runat="server" Text="Home" CssClass="btn btn-primary" Visible="False" />
                        </div>
                    </div>
                </div>
            </div>



            <asp:GridView ID="outputGridView" runat="server" AutoGenerateColumns="False" 
                OnSelectedIndexChanged="outputGridView_SelectedIndexChanged"
                 PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" PageSize="5"
                RowStyle-CssClass="rows" AllowPaging="True" CssClass="mydatagrid" OnPageIndexChanging="outputGridView_PageIndexChanging">
               
                 <Columns>

                    <asp:TemplateField HeaderText="SL#">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bank Code">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblPartyId"><%# Eval("BankCode") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Bank Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="PartyName"><%# Eval("BankName") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Branch Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Address"><%# Eval("BranchName") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Account No">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="ContactNo"><%# Eval("AccountNo") %></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                   <%-- <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Select">Edit</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
            </asp:GridView>
        </div>
    </form>

    <script>
        function userValid() {
            var code, name, branch, AccNo;
            code = document.getElementById("codeTextBox").value;
            name = document.getElementById("nameTextBox").value;
            branch = document.getElementById("branchTextBox").value;
            AccNo = document.getElementById("accountNoTextBox").value;


            if (code == '') {
                document.getElementById("messageLabel").textContent = "Enter Code";
                return false;

            }
            else if (name == '') {
                document.getElementById("messageLabel").textContent = "Enter Name";
                return false;
            }

            else if (branch == '') {
                document.getElementById("messageLabel").textContent = "Enter Address";
                return false;

            }
            else if (AccNo == '') {
                document.getElementById("messageLabel").textContent = "Enter Contact No";
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
    <script src="../Scripts/jquery.validate.js"></script>
</body>
</html>
