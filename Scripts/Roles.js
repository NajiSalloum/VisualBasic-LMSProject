$(document).ready(function () {
    $("#Kind").on("change", OnChange);
});

function OnChange() {
    var role = document.getElementById("Kind").value;
    if (role == 2) {
        $("#Courses").removeClass("hidden");
    }
    else {
        $("#Courses").addClass("hidden");
    }
    
}