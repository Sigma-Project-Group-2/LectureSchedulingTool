$(window).load(function () {
    $('body').on('click', '[class $= btn-danger]',
        function () {
            var chance = Math.random() * (100 - 1 + 1) + 1;
            if (chance < 2) {
                document.getElementById('music_alert').pause();
                document.getElementById('music_alert').currentTime = 0;
                document.getElementById('music_alert').play();
            }
            if (confirm('Вы уверенны, что хотите удалить запись?')) {
                $(this).parent('form').submit();
            }
            else {
                return false;
            }
        });
});