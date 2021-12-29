var dataTable;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $("#tblState").DataTable(
        {
            "ajax": {
                "url": "/Admin/State/GetAllStates",
                "type": "GET",
                "dataType": "json",
            },
            "columns": [
                { "data": "stateName", "width": "15%" },
                { "data": "stateDescription", "width": "15%" },
                { "data": "country.countryName", "width": "15%" },
                { "data": "country.countryDescription", "width": "15%" },
                { "data": "country.isdCode", "width": "15%" },
                {
                    "data": "stateId",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href="State/Edit/${data}" class="btn btn-success text-white"
                                style='cursor:pointer:'><i class='far fa-edit'></i></a>
                            &nbsp;
                        <a onclick=Delete("State/DeleteStates/${data}") class="btn btn-danger text-white"
                                style='cursor:pointer:'><i class='far fa-trash-alt'></i></a>
                            </div>
                            `;
                    },
                    "width": "30%"
                }
            ]
        }
    );
}

function Delete(url) {
    swal({
        title: "Are your sure you want to delete?",
        text: "You will not be able to restore the data!",
        icon: "warning",
        buttons: true,
        dangerousMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        //toastr.success(data.message);
                        //dataTable.ajax.reload();
                        window.location.href = '/Admin/State/Index';
                    }
                    else {
                        //toastr.error(data.message);
                    }
                }
            });
        }
    });
}

