function ChangeDepend(mainSel, depSel)
{
    var id = $('[name = ' + mainSel + ']').val();
    var partView;
    switch(depSel)
    {
        case "id_department":
            partView = "GetDepartments";
            break;
        case "id_teacher":
            partView = "GetTeachers";
            break;
        case "id_subject":
            partView = "GetSubjects";
            break;
    }
    $('[class $= btn-primary]').filter('[value = u]').prop('disabled', 'true');
    $('[class $= btn-primary]').filter('[value = s]').prop('disabled', 'true');
    $('[name = ' + depSel + ']').prop('disabled', 'true'); 


    $.ajax({
        type: 'GET',
        data: mainSel + "=" + id,
        url: "/Scheduling/" + partView,
        success: function (data) {
            $('[name = ' + depSel + ']').empty();
            $('[name = ' + depSel + ']').append(data);
        }
    });

    $('[name = ' + depSel + ']').removeAttr('disabled');
    $('[class $= btn-primary]').filter('[value = u]').removeAttr('disabled');
    $('[class $= btn-primary]').filter('[value = s]').removeAttr('disabled');
}

$(window).load(function () {
    
    $('[name = id_department]').change(function () {
        ChangeDepend('id_department', 'id_teacher');
        
        ChangeDepend('id_department', 'id_subject');
    });

    $('[name = id_faculty]').change(function () {
        ChangeDepend('id_faculty', 'id_department');
        //$('[name = id_department] :first').change();
    });

    //$('[name = id_faculty]').ready(function () {
    //    $('[name = id_faculty] :selected').change();
    //});
});