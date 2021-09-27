$(document).ready(function () {

    //$("#accordion").accordion({
    //    heightStyle: "content"
    //});
    $("#datefrom").datepicker();
    $("#dateto").datepicker();

    //if ($('#txtHdnCustomer').val != "") {
    //    $.getJSON("Customer/CustomerInfo", { Id: $('#txtHdnCustomer').val() })
    //        .done(function (json) {
    //            $('#txtCustomer').val(json.name);
    //        })
    //        .fail(function (jqxhr, textStatus, error) {
    //            var err = textStatus + ", " + error;
    //            console.log("Request Failed: " + err);
    //        });
    //}
    //var customerurl = "Customer/GetCustomersBySearch";
    //$("#txtCustomer").autocomplete({
    //    source: function (request, response) {
    //        $.ajax({
    //            url: customerurl,
    //            type: 'GET',
    //            cache: false,
    //            data: request,
    //            dataType: 'json',
    //            success: function (json) {
    //                response($.map(json, function (value, key) {
    //                    $('#txtHdnCustomer').val("");
    //                    return {
    //                        label: value.text,
    //                        value: value.value
    //                    }
    //                }));
    //            },
    //            error: function (XMLHttpRequest, textStatus, errorThrown) {
    //                console.log('error', textStatus, errorThrown);
    //            }
    //        });
    //    },
    //    minLength: 2,
    //    select: function (event, ui) {
    //        console.log('you have selected ' + ui.item.text + ' ID: ' + ui.item.value);
    //        $('#txtCustomer').val(ui.item.label);
    //        $('#txtHdnCustomer').val(ui.item.value);
    //        return false;
    //    }
    //});

    //var data = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(Model.customers));
    //var datavalue = @Html.Raw(Newtonsoft.Json.JsonConvert.SerializeObject(HttpContextAccessor.HttpContext.Session.GetObject<RequestResult>("ComplexObject")));
    //var authHeaders = {};
    //authHeaders.Authorization = 'Bearer ' + datavalue.Data.accessToken;
    //$("#txtCustomer").autocomplete({
    //    source: function (request, response) {
    //        $.ajax({
    //            url: 'https://localhost:44323/api/Customer/GetCustomersBySearch',
    //            type: 'GET',
    //            cache: false,
    //            data: request,
    //            dataType: 'json',
    //            headers: authHeaders,
    //            success: function (json) {
    //                // call autocomplete callback method with results  
    //                var jsondata = json.Data;
    //                response($.map(json.Data, function (name, val) {
    //                    return {
    //                        label: name.Name,
    //                        value: name.Id
    //                    }
    //                }));
    //            },
    //            error: function (XMLHttpRequest, textStatus, errorThrown) {
    //                console.log('error', textStatus, errorThrown);
    //            }
    //        });
    //    },
    //    minLength: 2,
    //    select: function (event, ui) {
    //        console.log('you have selected ' + ui.item.label + ' ID: ' + ui.item.value);
    //        $('#txtCustomer').val(ui.item.label);
    //        $('#txtHdnCustomer').val(ui.item.value);
    //        return false;
    //    }
    //});

});