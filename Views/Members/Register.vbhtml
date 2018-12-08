@ModelType HomeDesginProject.RegisterView

@Using (Html.BeginForm("Register", "Members"))
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
        If (Model.Kind = 2) Then
    End Code
         @Html.HiddenFor(Function(model) model.Kind, 2)
         <div class="form-group">
             @Html.LabelFor(Function(model) model.CourseId, htmlAttributes:=New With {.class = "control-label col-md-2"})
             <div class="col-md-10">
                 @*@Html.DropDownListFor(Function(model) model.CourseId, CType(ViewData("Courses"), List(Of SelectListItem)), "Select One", New With {.htmlAttributes = New With {.class = "form-control"}})*@
                 @Html.DropDownListFor(Function(model) model.CourseId, DirectCast(ViewData("Courses"), IEnumerable(Of SelectListItem)), New With {.class = "form-control"})
                 @Html.ValidationMessageFor(Function(model) model.CourseId, "", New With {.class = "text-danger"})
             </div>
         </div>  
    @Code
        Else
    End Code
         @Html.HiddenFor(Function(model) model.Kind, 1)
         @Html.HiddenFor(Function(model) model.CourseId, 0))
    @Code
        End If
    End Code

        

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
