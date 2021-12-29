var dataTable;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $("#tblCountry").DataTable(
        {
            "ajax": {
                "url": "/Admin/Country/GetAllCountries",
                "type": "GET",
                "dataType": "json",
            },
            "columns": [
                { "data": "countryName", "width": "30%" },
                { "data": "countryDescription", "width": "20%" },
                { "data": "isdCode", "width": "20%" },
                {
                    "data": "countryId",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href="Country/Edit/${data}" class="btn btn-success text-white"
                                style='cursor:pointer:'><i class='far fa-edit'></i></a>
                            &nbsp;
                        <a onclick=Delete("Country/DeleteCountries/${data}") class="btn btn-danger text-white"
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
                        window.location.href = '/Admin/Country/Index';
                    }
                    else {
                        //toastr.error(data.message);
                    }
                }
            });
        }
    });
}