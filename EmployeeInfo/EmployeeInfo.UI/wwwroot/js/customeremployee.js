$(document).ready(function () {
    $("#ddlcustomer").on('change', '.updateevent', function (el) {
        $.ajax({
            type: 'GET',
            url: window.location.origin + "/CustomerEmployee/CustomerById",
            data: { Id: $('#ddlcustomer').val() },
            sucess: function (result) {
                if (result.success) {
                    $("#customertable").html(result);

                    $.ajax({
                        type: 'GET',
                        url: window.location.origin + "/Address/Index",
                        data: { Id: $('#ddlcustomer').val() },
                        sucess: function (result) {
                            $("#addresstable").html(result);
                        }
                    });
                }
            }
        });
    });
});