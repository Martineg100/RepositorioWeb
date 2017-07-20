$(document).ready(function () {
    Venta.setupAutoComplete();
    Cliente.setupAutoComplete();
    $("#btn-guardar").click(Venta.Guardar);
})

var Venta = function () {
    this.Nombre = "javier";
}

Venta.Guardar = function () {

    var registros = $("#tbody-venta").find("tr");

    var productos = [];

    $.each(registros, function (i, tr) {
        var precio = $(this).find("td.columna-precio").text();
        var id = $(this).attr("id");
        var producto = { IdProducto: id, Precio: precio, Cantidad: 1 };
        productos.push(producto);
    })

    $.ajax({
        url: "/Ventas/Guardar",
        type: "POST",
        data: { DetalleVenta: productos, IdCliente: Cliente.Id},
        success: function (data) {
            alert('Se registró la venta')
            window.location("/Ventas/Listar");
        }
    });
}

Venta.setupAutoComplete = function () {
    $.ajax({
        url: "/Productos/ObtenerNombreProductos",
        success: function (data) {
            var parametro = {
                source: data,
                focus: Venta.setupAutoComplete.Focus,
                select: Venta.setupAutoComplete.Select
            };
            $("#txt-producto").autocomplete(parametro);
        }
    });
}

Venta.setupAutoComplete.Focus = function (event, ui) {
    $("#txt-producto").val(ui.item.label)
    return false;
}

Venta.setupAutoComplete.Select = function (event, ui) {
    var parametro = {
        url: "/Productos/ObtenerDetalle/" + ui.item.value,
        type: "POST",
        success: function (data) {

            var tr = $("<tr>", { id: data.Id });
            var tdNombre = $("<td>", { text: data.Nombre, class: "columna-nombre" });
            var tdPrecio = $("<td>", { text: data.Precio, class: "columna-precio" });

            tr.append(tdNombre, tdPrecio);

            $("#tbody-venta").append(tr);
        }
    }
    $.ajax(parametro)

    //$("#tbody-venta").append(
    //    $("<tr>").load("/Productos/ObtenerVistaDetalle/", { id: ui.item.value }));


    $("#txt-producto").val("")
    return false;
}



//=====================Cliente=====================

var Cliente = function () {
}

Cliente.setupAutoComplete = function () {
    $.ajax({
        url: "/Clientes/ObtenerClientes",
        success: function (data) {
            var parametro = {
                source: data,
                focus: Cliente.setupAutoComplete.Focus,
                select: Cliente.setupAutoComplete.Select
            };
            $("#txt-cliente").autocomplete(parametro);
        }
    });
}

Cliente.setupAutoComplete.Focus = function (event, ui) {
    $("#txt-cliente").val(ui.item.label)
    return false;
}

Cliente.setupAutoComplete.Select = function (event, ui) {
    Cliente.Id = ui.item.value;
    return false;
}


