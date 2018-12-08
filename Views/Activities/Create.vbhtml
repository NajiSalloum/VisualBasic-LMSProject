@ModelType HomeDesginProject.Activity

@Using (Html.BeginForm()) 
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
        <h4>Activity</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With { .class = "text-danger" })
         <div class="form-group">
             @Html.LabelFor(Function(model) model.TypeId, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @*@Html.DropDownListFor(Function(model) model.CourseId, CType(ViewData("Courses"), List(Of SelectListItem)), "Select One", New With {.htmlAttributes = New With {.class = "form-control"}})*@
                 @Html.DropDownListFor(Function(model) model.TypeId, DirectCast(ViewData("Types"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.TypeId, "", New With {.class = "text-danger"})
             </div>
         </div>

        @*<div class="form-group">
            @Html.LabelFor(Function(model) model.ModuleeId, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.ModuleeId, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.ModuleeId, "", New With { .class = "text-danger" })
            </div>
        </div>*@

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Name, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Name, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Name, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.Description, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.Description, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.Description, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.StartTime, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.StartTime, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.StartTime, "", New With { .class = "text-danger" })
            </div>
        </div>

        <div class="form-group">
            @Html.LabelFor(Function(model) model.EndTime, htmlAttributes:= New With { .class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.EndTime, New With { .htmlAttributes = New With { .class = "form-control" } })
                @Html.ValidationMessageFor(Function(model) model.EndTime, "", New With { .class = "text-danger" })
            </div>
        </div>
         <div class="form-group">
             @Html.LabelFor(Function(model) model.ModuleeId, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @*@Html.DropDownListFor(Function(model) model.CourseId, CType(ViewData("Courses"), List(Of SelectListItem)), "Select One", New With {.htmlAttributes = New With {.class = "form-control"}})*@
                 @Html.DropDownListFor(Function(model) model.ModuleeId, DirectCast(ViewData("Modulees"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.ModuleeId, "", New With {.class = "text-danger"})
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
End Section
