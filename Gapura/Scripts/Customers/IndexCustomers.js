//<script>
$(document).ready(function () {
    //var item;
    $('a.editor_create').on('click', function (e) {
        e.preventDefault();

        editor.create({
            title: 'Create new record',
            buttons: 'Add'
        });
    });
    // Edit record
    $('#myTable').on('click', 'a.editor_edit', function (e) {
        e.preventDefault();

        editor.edit($(this).closest('tr'), {
            title: 'Edit record',
            buttons: 'Update'
        });
    });
    // Delete a record
    $('#myTable').on('click', 'a.editor_remove', function (e) {
        e.preventDefault();

        editor.remove($(this).closest('tr'), {
            title: 'Delete record',
            message: 'Are you sure you wish to remove this record?',
            buttons: 'Delete'
        });
    });

    $('#myTable').DataTable({
        "ajax": {
            //"url": "@Url.Action("LoadData", "Customers")",
            url: '/Customers/LoadData',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "CompanyName", "width": "20%" },
            { "data": "ContactName", "width": "15%" },
            { "data": "ContactTitle", "width": "10%" },
            { "data": "Address", "width": "10%" },
            //{ "data": "City", "autoWidth": true },
            //{ "data": "Region", "autoWidth": true },
            //{ "data": "PostalCode", "autoWidth": true },
            //{ "data": "Country", "autoWidth": true },
            { "data": "Phone", "width": "10%" },
            { "data": "Fax", "width": "10%" },
            {
                //"data": null,
                //"className": "center",
                "data": "CustomerID", "width": "12%", "render": function (data) {
                    return '<a class="btn btn-info" href="/Customers/Edit/' + data + '"><i class="halflings-icon white edit"></i></a>' +
                            '<a class="btn btn-danger" href="/Customers/Delete/' + data + '"><i class="halflings-icon white trash"></i></a>' +
                            '<a class="btn btn-success" href="/Customers/Details/' + data + '"><i class="halflings-icon white zoom-in"></i></a>'
                }
            }
        ],
        "pagingType": "full_numbers",
        "info": true,
        "scrollCollapse": true,
        "sScrollX": true,
        "sScrollY": "55vh",
        "sScrollCollapse": true,
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