$(document).ready(function () {
    $("#dateofbirth").datepicker();
    $("#dateofjoining").datepicker();
    $("#locationid").change(function () {
        var locationvalue = $(this).val();
        $.ajax({
            method: "POST",
            url: window.location.origin + "/Employee/BankDetails",
            data: { id: locationvalue },
            complete: function (result) {
                console.log(result.responseText);
                $("#bankdetailscomponent").html(result.responseText);
            }
        });
    });
});

function addcustomer() {
    $("#dialog").dialog({
        autoOpen: false,
        modal: true,
        title: "View Details"
    });

    $.ajax({
        type: 'GET',
        url: window.location.origin + "/CustomerEmployee/CustomersNotWithEmployee",
        data: { Id: $('#employeeid').val() },
        sucess: function (result) {
            $('#dialog').html(result);
            $('#dialog').dialog('open');
        }
    });
}