@ModelType IEnumerable(Of HomeDesginProject.AllStudentsView)

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<div class="navbar-right">
    @Using (Html.BeginForm("AllStudents", "Members", FormMethod.Get))
        @<div class="form-inline">
            <ul class="nav navbar">
                <li>@Html.TextBox("SearchName")</li>
                <li><input type="submit"  value="Search"/></li>
            </ul>
        </div>
    End Using
</div>
<Table Class="table">
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
        <th>
            @Html.DisplayNameFor(Function(model) model.CourseId)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CourseName)
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
            @Html.DisplayFor(Function(modelItem) item.CourseId)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CourseName)
        </td>
        <td>
            @*@Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey}) |
                @Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey}) |
                @Html.ActionLink("Delete", "Delete", New With {.id = item.PrimaryKey})*@
        </td>
    </tr>
    Next

</Table>
