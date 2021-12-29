var dataTable;
$(document).ready(function () {
    LoadDataTable();
});

function LoadDataTable() {
    dataTable = $("#tblState").DataTable(
        {
            "ajax": {
                "url": "/Admin/City/GetAllCities",
                "type": "GET",
                "dataType": "json",
            },
            "columns": [
                { "data": "cityName", "width": "12%" },
                { "data": "cityDescription", "width": "12%" },
                { "data": "state.stateName", "width": "12%" },
                { "data": "state.stateDescription", "width": "12%" },
                { "data": "state.country.countryName", "width": "12%" },
                { "data": "state.country.countryDescription", "width": "12%" },
                { "data": "state.country.isdCode", "width": "12%" },
                {
                    "data": "cityId",
                    "render": function (data) {
                        return `<div class="text-center">
                            <a href="City/Edit/${data}" class="btn btn-success text-white"
                                style='cursor:pointer:'><i class='far fa-edit'></i></a>
                            &nbsp;
                        <a onclick=Delete("City/DeleteCities/${data}") class="btn btn-danger text-white"
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
                        window.location.href = '/Admin/City/Index';
                    }
                    else {
                        //toastr.error(data.message);
                    }
                }
            });
        }
    });
}


