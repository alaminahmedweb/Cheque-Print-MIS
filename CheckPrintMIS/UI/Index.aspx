<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CheckPrintMIS.UI.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Design/Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../Design/Bootstrap/js/bootstrap.min.js"></script>
    <script src="../Scripts/jquery-ui-1.8.20.min.js"></script>
    <script src="../Scripts/jquery-2.2.0.min.js"></script>
    <script src="../Design/Ajax.js"></script>
    <script src="../Design/ajax.jquery.min.js"></script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">

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
            <button type="button" class="btn btn-info" data-toggle="collapse" data-target="#demo">Company Profile</button>
            <div id="demo" class="collapse in">
                With 25 years of experience, Medicon Pharmaceuticals Ltd. is one of the fastest growing and ISO 9001: 2008 certified companies in Bangladesh started its journey since 1984. It is engaged in manufacturing and marketing of a wide range of therapeutic drugs with various dosage form including Tablet, Capsule, Syrup, Suspension Emulsion, Cream, Ointment, Oral gel etc and animal health products to satisfy the unmet medical needs home & abroad and improve peoples’ quality of life. The company achieved enviable reputation & respect since then & the total number of manufactured. Products now stand at about 140.

                        Relentlessly pursuing scientific knowledge, building the strength and developing the vision required to compete with the best in the future MPL, equipped with the most advanced and modern machineries and state-of –the-art technology, earned a very prestigious GMP certification which paved its way to be a global player. The company has already stepped into global market and exporting its products to different countries with its quality products produced with strict adherence to cGMP. We believe through our quality products and value-added services we can be your dependable partner to meet healthcare needs and build a long term relationship.

                        Professionally trained and experienced technical personnel (Pharmacist, Biochemist, Microbiologist Chemist, and Engineer). Duty The quality & technical requirements are not compromised. MPL operates on the concept that scientific development & technical skill add margin to our contribution. It is therefore possible to carry out a high profile job at a very competitive price. There are more than 500 skilled professionals working in MPL inclusive of Sales & Marketing Force. The distribution network is spread all over Bangladesh with a professional team of distributions personnel. We launch new products to meet local market demand.
                        We are truly a professional organization and believe in the strength of people who makes the difference. We offer you an excellent business environment, corporate values and cohesive team dynamics as the opportunity of your faster career growth.

                        The company has its membership with the following authority.

                        Bangladesh Drug Administration – BDA Federation of Bangladesh Chamber of Commerce & Industry – FBCCI Dhaka Chamber of Commerce & Industry – DCCI Bangladesh association of pharmaceutical industry. 
            </div>
        </div>
    </form>
</body>
</html>
