$(window).load(function () {
    $('table').ready(function () {  //функция, отвечающая за доступность кнопок
        var action = $('#curent_action').val();
        switch (action) {
            case '0':
                $('button').removeAttr('disabled');
                break;
            default:
                $('button').prop('disabled', 'true');
                var row = $('[type = text]').parents('tr');
                row.find('button').removeAttr('disabled');
                break;
        }

    });
});