﻿$(window).load(function () {
    $('[name = id_faculty]').change(function () {     //функция отвечающая за перечень кафедр в зависимости от выбранного факультета
        var id = $(this).val();
        $('[name = id_department]').prop('disabled', 'true');
        $('[class $= btn-primary]').filter('[value = u]').prop('disabled', 'true');
        $('[class $= btn-primary]').filter('[value = s]').prop('disabled', 'true');
        $.ajax({
            type: 'GET',
            data: { id_faculty: id },
            url: $('#department_list_getter').val(),
            success: function (data) {
                $('[name = id_department]').empty();
                $('[name = id_department]').append(data);
                $('[name = id_department]').removeAttr('disabled');
                $('[class $= btn-primary]').filter('[value = u]').removeAttr('disabled');
                $('[class $= btn-primary]').filter('[value = s]').removeAttr('disabled');
            }
        });
    });

    $('[name = id_faculty]').ready(function () {
        $('[name = id_faculty] :selected').change();
    });
});