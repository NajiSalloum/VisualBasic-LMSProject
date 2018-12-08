@ModelType IEnumerable(Of HomeDesginProject.Modulee)

<p>
    @*' New {id = Url.RequestContext.RouteData.Values["id"]}*@
    @Html.ActionLink("Create New Modulee", "Create", "Modulees", New With {.id = Url.RequestContext.RouteData.Values("id")}, Nothing)
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StartDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EndDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.CourseId)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StartDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EndDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.CourseId)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Activities", "ModuleeActivities", "Modulees", New With {.id = item.Id}, Nothing) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
