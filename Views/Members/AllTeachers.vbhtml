@ModelType IEnumerable(Of HomeDesginProject.AllTeachersView)

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<div class="navbar-right">
    @Using (Html.BeginForm("AllTeachers", "Members", FormMethod.Get))
        @<div class="form-inline">
            <ul class="nav navbar">
                <li>@Html.TextBox("SearchName")</li>
                <li><input type="submit" value="Search" /></li>
            </ul>
        </div>
    End Using
</div>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.FirstName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LastName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FirstName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LastName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Email)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
Next

</table>
