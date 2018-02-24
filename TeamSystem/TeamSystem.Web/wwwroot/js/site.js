// Write your JavaScript code.
$( function () {
    if ($(window).width() > 768) {
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
            ),
            $(".dropdown-menu").mouseleave(
                function () {
                    $(".dropdown-menu").stop(true, true).slideUp("fast")
                }
            )
    }
});