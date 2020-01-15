$(document).ready(function () {
    BindGrid("GameList", "GameList", '/Admin/GetGameList');
});
function OnGridEdit(e) {

    var table = $('#GridGameList').DataTable();
    var data = table.row(e.parentNode).data();
    location.href = '/Admin/Game?id=' + data.ProductId;//form page
}
function OnGridDelete(e) {
    var data, GetDeleteStatus;
    var table = $('#GridGameList').DataTable();
    data = table.row(e.parentNode).data();
    if (confirm("Are you sure to proceed?")) {
        AjaxCall('/Admin/ProductDelete', JSON.stringify({ "ID": data.ProductId }), GetDeleteStatus, null);
        BindGrid("GameList", "GameList", '/Admin/GetGameList');
    }
}
function ShowImages(e) {
    var data, GetDeleteStatus;
    var table = $('#GridGameList').DataTable();
    data = table.row(e.parentNode).data();
    location.href = '/Admin/Images?id=' + data.ProductId + "&t=Acc";//form page
}