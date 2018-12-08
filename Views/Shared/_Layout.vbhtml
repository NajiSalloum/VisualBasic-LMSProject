<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Scripts.Render("~/bundles/modernizr")

</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Application name", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})

            </div>
            @Code
                If (Context.User.IsInRole("Teacher")) Then
            End Code

            <ul class="nav navbar-nav navbar-right">
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Dropdown <span class="caret"></span></a>
                    <ul class="dropdown-menu">
                        <li><a runat="server" href="~/Members/RegisterMember">Register Member</a></li>
                        <li><a runat="server" href="~/Members/Register?k=2">Register Student</a></li>
                        <li><a runat="server" href="~/Members/Register?k=1">Register Teacher</a></li>
                        <li>
                            <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" />
                        </li>
                    </ul>
                </li>
            </ul>
            @Code
                Else
            End Code
            <ul class="nav navbar-nav navbar-right">
               
                <li><a runat="server" href="~/Account/Manage" title="Manage your account">Hello,</a></li>
            </ul>
            @Code
                End If
            End Code


            <div class="navbar-collapse collapse">
                <ul Class="nav navbar-nav"></ul>
            </div>
        </div>
    </div>

    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @RenderSection("scripts", required:=False)
</body>
</html>
