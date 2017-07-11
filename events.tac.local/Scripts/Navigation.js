jQuery.noConflict();
(function ($) {
    $('li.dropdown').on('click', function () {
        var $el = $(this);
        if ($el.hasClass('open')) {
            var $a = $el.children('a.dropdown-toggle');
            if ($a.length && $a.attr('href')) {
                location.href = $a.attr('href');
            }
        }
    });
})(jQuery)
