$(document).ready(function () {
    $("#Name").on("focusout", OnFocusout);
    $("input[type='submit']").on("click", OnClick);
});

function OnFocusout(e) {
    $.ajax(
        {
            url: "/Courses/UniqueCourseName",
            type: "post",
            dataType: "json",
            data:
            {
                DataName: this.id,
                Text: this.value
            },
            context: this,
            success: function (data) {
                if (data !== null && data.length > 0) {
                    $("#TextErrorMessage").removeClass("hidden");
                    $("#TextErrorMessage").addClass("has-error");
                }
                else {
                    $("#TextErrorMessage").addClass("hidden");
                    $("#TextErrorMessage").removeClass("has-error");
                }
            },
            error: function (data) {
                $("#TextErrorMessage").addClass("hidden");
                $("#TextErrorMessage").removeClass("has-error");
            }
        });
}
function OnClick(e) {
    if ($("#TextErrorMessage").hasClass("has-error")) {
        e.preventdefault()();
    }
}