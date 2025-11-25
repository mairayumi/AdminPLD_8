$(document).ready(function () {
    $(".saveBtn").click(function (event) {
        event.preventDefault();
        //var currentUrl = window.location.href;
        var rowId = $(this).data("id");
        var Actividad = $("#actividad-" + rowId)
        var rTKA_Actividad = Actividad.find(".Actividad").val();
        var rTKA_FechaSeguimiento = Actividad.find(".Datepicker").val();
        var cTAC_Id = Actividad.find("#itemIn_cTAC_Id").val();
        var cEAC_Id = Actividad.find("#itemIn_cEAC_Id").val();
        var UsrId   = Actividad.find("#itemIn_UsrId").val();

        //event.preventDefault();
        const datos = {
            "cTLS_Id": rowId.split("-")[0],
            "cTKA_Id": rowId.split("-")[1],
            "rTKA_Id": rowId.split("-")[2],
            "rTKA_Actividad": rTKA_Actividad,
            "rTKA_FechaSeguimiento": rTKA_FechaSeguimiento,
            "cTAC_Id": cTAC_Id,
            "cEAC_Id": cEAC_Id,
            "UsrId"  : UsrId
        };
        //var sAplicacion = HttpContext.Session.GetString("Aplicacion");
        //if (sAplicacion != null) {
        //    _aplicacion = _aplicacion.Deserializar(sAplicacion);
        //}
        //sAplicacion = _aplicacion.Serializar();
        //HttpContext.Session.SetString("Aplicacion", sAplicacion);


        //const formData  = new FormData();
        //formData.append("tipo", this.name);  // Parámetro de tipo cadena
        //formData.append("Valor", datos);  // Suponiendo que haya un input con id="archivo"

        // Crear un FormData y agregar los datos
        const formData = new FormData();
        formData.append('tipo', this.name);
        formData.append('ValorIn', JSON.stringify(datos)); // Enviar objeto como JSON en FormData

        //usar AJAX
        var url = '/Home/Actividad';
        fetch(url, {
            method: 'POST', // Definimos el método como POST
            //headers: {
                //'Content-Type': 'application/json', // Indicamos que los datos son de tipo JSON
            //},
            body: formData, // Convertimos los datos en formato JSON
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Error en la solicitud');
                }
                response.text().then(valorText => {
                    document.getElementById("modal-body").innerHTML = valorText;
                    $('#modalExito').modal('show')
                });
                window.location.reload();
                //return response.json();
            })
            .then(data => {
                // data.aplicacion contiene el nuevo valor
                document.getElementById("modal-body").innerHTML = "Aplicación actualizada: " + data.value.aplicacion;
                $('#modalExito').modal('show');
                window.location.reload();
            })
            .catch(error => {
                document.getElementById("modal-body").innerHTML = error.message;
                $('#modalExito').modal('show');
            });
        //window.location.reload();
        //window.location.href = currentUrl;
    });
    $('.datepicker').each(function () {
        $(this).datepicker({
            format: 'dd/mm/yyyy'
            //format: 'dd/mn/yyyy',  // Formato de fecha y hora
            //step: 30,             // Paso de minutos
            //minDate: 0,           // No permitir fechas pasadas
            //timepicker: true,     // Habilitar selección de hora
            //datepicker: true      // Habilitar selección de fecha
        });
    });

    $(".verDetalles").click(function () {
        var maestroId = $(this).data("id");
        var detallesRow = $("#detalle-" + maestroId);
        if (detallesRow != null) {
            if (detallesRow.is(":visible")) {
                detallesRow.hide();
            } else {
                detallesRow.show();
            }
        }
    });
    $(".verOficioDetalles").click(function () {
        var maestroId = $(this).data("id");
        var detallesRow = $("#detalle-" + maestroId);
        if (detallesRow != null) {
            if (detallesRow.is(":visible")) {
                detallesRow.hide();
            } else {
                detallesRow.show();
            }
        }
    });

});