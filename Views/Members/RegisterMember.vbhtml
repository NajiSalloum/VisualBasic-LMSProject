@ModelType HomeDesginProject.RegisterView
@Code
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>RegisterView</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Email, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Email, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Email, "", New With {.class = "text-danger"})
            </div>
        </div>


        <div class="form-group">
            @Html.LabelFor(Function(model) model.PasswordHash, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.PasswordHash, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.PasswordHash, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.FirstName, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.FirstName, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.FirstName, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.LastName, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.LastName, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.LastName, "", New With {.class = "text-danger"})
            </div>
        </div>
        @Code
            Dim roles As New List(Of SelectListItem)()
            roles.Add(New SelectListItem() With
                      {
                      .Text = "Teacher",
                      .Value = 1
                      })
            roles.Add(New SelectListItem() With
                      {
                      .Text = "Student",
                      .Value = 2
                      })

        End Code
        <div class="form-group">
            @Html.LabelFor(Function(model) model.Kind, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.Kind, roles, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.Kind, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group hidden" id="Courses">
            @Html.LabelFor(Function(model) model.CourseId, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.DropDownListFor(Function(model) model.CourseId, DirectCast(ViewData("Courses"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(model) model.CourseId, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" value="Create" class="btn btn-default" />
            </div>
        </div>
    </div>
            End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
    @Scripts.Render("~/bundles/roles")
End Section
