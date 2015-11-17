$(window).load(function () {
    
    $('table').ready(function () {  //функция, отвечающая за доступность кнопок
        var action = $('#ActionName').val();
        switch (action)
        {
            case '0':
                $('button').removeAttr('disabled');
                break;
            default:
                $('button').prop('disabled','true');
                var row = $('[type = text]').parents('tr');
                row.find('button').removeAttr('disabled');
                break;
        }

    });

    $('[name = id_faculty]').change(function () {     //функция отвечающая за перечень кафедр в зависимости от выбранного факультета
        var id = $(this).val();
        $('[name = id_department]').empty();
        $('[name = id_department]').append('<option>Ждите</option>');
        $('[class $= btn-primary]').filter('[value = u]').prop('disabled','true');
        $.ajax({
            type: 'GET',
            data: { id_faculty: id },
            url: $('#DepListGetter').val(),
            success: function (data) {
                $('[name = id_department]').empty();
                $('[name = id_department]').append(data);
                $('[class $= btn-primary]').filter('[value = u]').removeAttr('disabled');
            }
        });
    });

$('body').on('click', '[class $= btn-danger]',  //сообщение, всплывающее после нажатия на кнопку удалить
    function () {
        if (confirm('Вы уверенны, что хотите удалить запись?')) {
            $(this).parent('form').submit();
        }
        else {
            return false;
        }
    });

$('[name = id_faculty]').ready(function () {
    $('[name = id_faculty] :selected').change();
});

});