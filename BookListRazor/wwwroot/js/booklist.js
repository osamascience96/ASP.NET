var dataTable;

$(document).ready(function () {
    // load the table with the data
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                        <a href="/BookList/Edit?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:70px;">Edit</a>
                        &nbsp;
                        <a class="btn btn-danger text-white" style="cursor:pointer; width:70px;" onclick="Delete('/api/book?id=${data}')">Delete</a>
                    </div>`;
                },
                "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "No Data Found"
        },
        "width":"100%",
    });
}

function Delete(url) {
    // display the sweet alert
    swal({
        title: "Are you sure",
        text: "Once deleted, you'll not be able to recover",
        icon: "warning",
        buttons:true,
        dangerMode: true,
    }).then(willdelete => {
        if (willdelete) {
            // if the user selects to delete,
            // call to the api controller
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}