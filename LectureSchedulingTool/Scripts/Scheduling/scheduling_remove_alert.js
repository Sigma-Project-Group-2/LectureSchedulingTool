$(window).load(function () {
    $('body').on('click', '[class $= btn-danger]',
        function () {
            if (confirm('Вы уверенны, что хотите удалить эти данные?')) {
                $(this).parent('form').submit();
            }
            else {
                return false;
            }
        });
});