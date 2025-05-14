// Bootstrap dropdown toggle functionality
$(document).ready(() => {
    // For Bootstrap 5
    if (typeof bootstrap !== "undefined") {
        var dropdownElementList = [].slice.call(document.querySelectorAll(".dropdown-toggle"))
        var dropdownList = dropdownElementList.map((dropdownToggleEl) => new bootstrap.Dropdown(dropdownToggleEl))
    }
    // For Bootstrap 4 and below or jQuery fallback
    else {
        $(".dropdown-toggle").click(function (e) {
            e.preventDefault()
            $(this).parent().toggleClass("open")
        })

        // Close dropdown when clicking outside
        $(document).on("click", (e) => {
            if (!$(e.target).closest(".dropdown").length) {
                $(".dropdown").removeClass("open")
            }
        })
    }
})
