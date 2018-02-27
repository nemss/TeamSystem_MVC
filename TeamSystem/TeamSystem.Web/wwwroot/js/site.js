// Write your JavaScript code.
$(".dropdown").hover(
    function () {
        if ($(window).width() > 768) {
            $(".dropdown-menu").stop(true, false, true).slideToggle("fast")
        }
    }
);