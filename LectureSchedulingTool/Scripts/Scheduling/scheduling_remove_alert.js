$(window).load(function () {

    $('body').on('click', '[class $= btn-danger]',  //сообщение, всплывающее после нажатия на кнопку удалить
        function () {
            if (confirm('Вы уверенны, что хотите удалить запись?')) {
                $(this).parent('form').submit();
            }
            else {
                return false;
            }
        });
});