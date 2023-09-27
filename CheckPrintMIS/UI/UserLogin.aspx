<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="CheckPrintMIS.UI.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Design/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../Design/Bootstrap/js/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>

    <style>
        .login_form .panel-heading .panel-title {
            text-align: center;
            font-size: 20px;
            font-weight: 600;
            color: #333;
        }

        .controls {
            text-align: center;
        }

            .controls a {
                text-align: center;
                width: 100%;
            }
    </style>
    <title>User Login</title>
</head>
<body>
    <form id="loginform" class="form-horizontal" role="form" runat="server">
        <div class="container">
            <div id="loginbox" style="margin-top: 50px;" class="mainbox col-md-4 col-md-offset-4 col-sm-8 col-sm-offset-2">
                <div class="panel panel-info login_form">
                    <div class="panel-heading">
                        <div class="panel-title">Sign In</div>
                    </div>

                    <div style="padding-top: 30px" class="panel-body">

                        <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12"></div>
                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                            <asp:TextBox ID="username" class="form-control" runat="server" placeholder="User Name"></asp:TextBox>
                        </div>

                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                            <asp:TextBox ID="password" runat="server" type="password" class="form-control" placeholder="Password"></asp:TextBox>
                        </div>

                        <div style="margin-bottom: 25px ;color:red" class="input-group" >
                            <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                        </div>

                        <div style="margin-top: 10px" class="form-group">
                            <div class="col-sm-12 controls">
                                <asp:Button ID="cmdLogin" runat="server" Text="Login" Width="100%" class="btn btn-success" OnClientClick="return userValid()" OnClick="cmdLogin_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../Scripts/jquery-ui-1.8.20.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/jquery.validate.unobtrusive.js"></script>
    <script>
        function userValid() {
            var UserName, Password;
            UserName = document.getElementById("username").value;
            Password = document.getElementById("password").value;

            if (UserName == '') {
                document.getElementById("messageLabel").textContent = "Enter User Name Please"
                return false;
            }
            else if (Password == '') {
                document.getElementById("messageLabel").textContent = "Enter Password Please";
                return false;
            }
            else {
                return true;
            }
        }
    </script>

</body>
</html>
