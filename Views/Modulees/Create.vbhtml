@ModelType HomeDesginProject.Modulee
@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>
@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    @<div class=" form-horizontal">
        <h4>Create</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <div class="form-group ">
            @Html.LabelFor(Function(model) model.Name, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div>
                @Html.EditorFor(Function(model) model.Name, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Name, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group ">
            @Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div>
                @Html.EditorFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.StartDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.StartDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.StartDate, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.EndDate, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.EndDate, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.EndDate, "", New With {.class = "text-danger"})
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.CourseId, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @*@Html.DropDownListFor(Function(model) model.CourseId, CType(ViewData("Courses"), List(Of SelectListItem)), "Select One", New With {.htmlAttributes = New With {.class = "form-control"}})*@
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
    @Html.ActionLink("Back To List", "Index")
</div>
@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section



