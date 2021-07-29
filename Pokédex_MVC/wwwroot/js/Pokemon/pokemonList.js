let datatable

$(document).ready(() => {
    loadData()
})

function loadData() {
    datatable = $('#Datatable').DataTable({
        ajax: {
            url: '/pokemon/getall',
            type: 'GET',
            datatype: 'json'
        },
        columns: [
            { data: 'name', 'width': '20%' },
            { data: 'gender', 'width': '20%' },
            { data: 'type', 'width': '20%' },
            {
                data: 'pokemonId',
                render: (data) => {
                    return `<div class="text-center">
                                <a href='/Pokemon/Detail?id=${data}' class='btn btn-success btn-sm'>
                                    Detail
                                </a>
                                &nbsp;
                                <a href='/Pokemon/Create?id=${data}' class='btn btn-warning btn-sm'>
                                    Edit
                                </a>
                                &nbsp;
                                <a class='btn btn-danger btn-sm text-white' onclick=Delete('/pokemon/Delete?id='+${data})>
                                    Delete
                                </a>
                            </div>`

                },
                width: '40%'
            }
        ],
        language: {
            emptyTable: 'No data available yet.'
        },
        width: '100%'
    })
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message)
                        datatable.ajax.reload()
                    }
                    else toastr.error(data.message)
                }
            })
        }
    })

    //Swal.fire({
    //    title: "Are you sure?",
    //    icon: "warning",
    //    dangerMode: true,
    //    showCancelButton: true
    //}).then((willDelete) => {
    //    if (willDelete) {
    //        $.ajax({
    //            type: 'DELETE',
    //            url: url,
    //            success: function (data) {
    //                if (data.success) {
    //                    toastr.success(data.message)
    //                    datatable.ajax.reload()
    //                }
    //                else toastr.error(data.message)
    //            }
    //        })
    //    }
    //})

}