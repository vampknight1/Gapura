﻿//<script>
$(document).ready(function () {
    $('#myTable').DataTable({
        "ajax": {
            //"url": "@Url.Action("LoadData", "Products")",
            url: '/Products/LoadData',
        "type": "GET",
        "datatype": "json",
    },
        "columns": [
             {
                 //"data": null,
                 //"className": "center",
                 "data": "ProductID", "width": "4%", "render": function (data) {
                     return '<a class="btn btn-info" href="/Products/Edit/' + data + '"><i class="halflings-icon white edit"></i></a>' +
                             '<a class="btn btn-danger" href="/Products/Delete/' + data + '"><i class="halflings-icon white trash"></i></a>' +
                             '<a class="btn btn-success" href="/Products/Details/' + data + '"><i class="halflings-icon white zoom-in"></i></a>'
                 }
             },
            { "data": "ProductCode", "width": "10%" },
            { "data": "CategoryName", "width": "10%" },
            { "data": "ProductName", "width": "20%" },
            { "data": "CompanyName", "width": "10%" },
            { "data": "QuantityPerUnit", "width": "5%" },
            { "data": "UnitPrice", "width": "7%", "render": $.fn.dataTable.render.number(',', '.', 0, '') },
            { "data": "UnitName", "width": "4%" },
            { "data": "Specs", "width": "15%" },
            { "data": "ReorderLevel", "width": "3%" },
            { "data": "Discontinued", "width": "4%" },
            { "data": "FirstInputDate", "width": "12%" }
        ],
    //"pagingType": "simple_numbers",
        "pagingType": "full_numbers",
        "info": true,
        "sScrollCollapse": true,
        "sScrollX": true,
        "sScrollY": "55vh",
        "sScrollCollapse": true,
        "bSort": true,
        "dom": "frtip",
        "width": "100%"
});
dataTable.table.on('draw', function () {
    $('button[data-type="delete"]').click(function () {
        var $button = $(this);
    });

    $('button[data-type="edit"]').click(function () {
    });
});
})
//</script>