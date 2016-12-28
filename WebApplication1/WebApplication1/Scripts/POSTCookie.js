$(document).ready(function () {
    var ulEmployees = $('#ulEmployees');
    $('#btn').click(function () {
        $.ajax({
            type: 'GET',
            url: "http://localhost:82/api/API",
            dataType: 'json',
            success: function (data) {
                ulEmployees.empty();
                $.each(data, function (index, val) {
                    var fullName = val.nombrePais;
                    ulEmployees.append('<li>' + fullName + '</li>');
                });
            }
        });
    });
    $('#btnClear').click(function () {
        ulEmployees.empty();
    });
});