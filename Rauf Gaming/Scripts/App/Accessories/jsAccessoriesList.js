$(document).ready(function () {
    BindGrid("AccessoriesList", "AccessoriesList", '/Admin/GetAccessoriesList');
});
function OnGridEdit(e) {

    var table = $('#GridAccessoriesList').DataTable();
    var data = table.row(e.parentNode).data();
    location.href = '/Admin/Product?id=' + data.ProductId + "&t=Acc";//form page
}
function OnGridDelete(e) {
    var data, GetDeleteStatus;
    var table = $('#GridAccessoriesList').DataTable();
    data = table.row(e.parentNode).data();
    if (confirm("Are you sure to proceed?")) {
        AjaxCall('/Admin/ProductDelete', JSON.stringify({ "ID": data.ProductId }), GetDeleteStatus, null);
        BindGrid("AccessoriesList", "AccessoriesList", '/Admin/GetAccessoriesList');
    }
}
function ShowImages(e) {
    var data, GetDeleteStatus;
    var table = $('#GridAccessoriesList').DataTable();
    data = table.row(e.parentNode).data();
    location.href = '/Admin/Images?id=' + data.ProductId + "&t=Acc";//form page
}