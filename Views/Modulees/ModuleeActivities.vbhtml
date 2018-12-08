@ModelType IEnumerable(Of HomeDesginProject.Activity)

<p>
    @Html.ActionLink("Create New Activity", "Create", "Activities", New With {.id = Url.RequestContext.RouteData.Values("id")}, Nothing)
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.TypeId)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.ModuleeId)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Name)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StartTime)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EndTime)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TypeId)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.ModuleeId)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Name)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StartTime)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EndTime)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
