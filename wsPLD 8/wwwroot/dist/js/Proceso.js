$(function () {
    //Date picker
    $('#cTKA_FechaCreado').datetimepicker({ icons: { time: 'far fa-clock' } });
    $('#cTKA_FechaSolucion').datetimepicker({
        format: 'L'
    });
    $('#cTKA_FechaSolucionReal').datetimepicker({
        format: 'L'
    });
    $('#cTKA_FechaPruebas').datetimepicker({
        format: 'L'
    });
    $('#cTKA_FechaDespliegue').datetimepicker({
        format: 'L'
    });
    $('#cTKA_FechaPruebasProd').datetimepicker({
        format: 'L'
    });
    $('#cTKA_FechaSeguimiento').datetimepicker({
        format: 'L'
    });
    ////Date and time picker
    //$('#cTKA_FechaCreado').datetimepicker({ icons: { time: 'far fa-clock' } });

    //$(document).ready(function () {
    //    $("#miTarjeta *").prop("disabled", "disabled"); // Deshabilitar todos los elementos dentro de la tarjeta
    //});
})