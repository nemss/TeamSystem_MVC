// Write your JavaScript code.
$(document).ready(function () {
    $("#dropdownMenuAdminPanel").hover(
        function () {
            $(".dropdown-menu").stop(true, true).slideDown("fast")
        },
        function () {
            if ($(".dropdown-menu").is(":hover")) { }
            else {
                $(".dropdown-menu").stop(true, true).slideUp("fast")
            }
        }
    )
});
$(document).ready(function () {
    $(".dropdown-menu").mouseleave(
        function () {
            $(".dropdown-menu").stop(true, true).slideUp("fast")
        }
    )
});