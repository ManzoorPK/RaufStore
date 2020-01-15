$(document).ready(function () {
    BindGrid("ConsolesList", "ConsolesList", '/Admin/GetConsolesList');
});
function OnGridEdit(e) {

    var table = $('#GridConsolesList').DataTable();
    var data = table.row(e.parentNode).data();
    location.href = '/Admin/Product?id=' + data.ProductId + "&t=Console";//form page
}
function OnGridDelete(e) {
    var data, GetDeleteStatus;
    var table = $('#GridConsolesList').DataTable();
    data = table.row(e.parentNode).data();
    if (confirm("Are you sure to proceed?")) {
        AjaxCall('/Admin/ProductDelete', JSON.stringify({ "ID": data.ProductId }), GetDeleteStatus, null);
        BindGrid("ConsolesList", "ConsolesList", '/Admin/GetConsolesList');
    }
}
function ShowImages(e) {
    var data, GetDeleteStatus;
    var table = $('#GridConsolesList').DataTable();
    data = table.row(e.parentNode).data();
    location.href = '/Admin/Images?id=' + data.ProductId + "&t=Acc";//form page
}