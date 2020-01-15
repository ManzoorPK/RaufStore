$(document).ready(function () {
    BindGrid("ExchangeList", "ExchangeList", '/Admin/GetExchangeList');
});
function OnGridEdit(e) {

    var table = $('#GridExchangeList').DataTable();
    var data = table.row(e.parentNode).data();
    location.href = '/Admin/Exchange?Id=' + data.ExchangeId;
}
function OnGridDelete(e) {
    var data, GetDeleteStatus;
    var table = $('#GridExchangeList').DataTable();
    data = table.row(e.parentNode).data();
    if (confirm("Are you sure to proceed?")) {
        AjaxCall('/Admin/ExchangeDelete', JSON.stringify({ "ID": data.ExchangeId }), GetDeleteStatus, null);
        BindGrid("ExchangeList", "ExchangeList", '/Admin/GetExchangeList');
    }
}
