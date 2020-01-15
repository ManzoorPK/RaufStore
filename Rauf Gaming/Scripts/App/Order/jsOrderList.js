$(document).ready(function () {
    BindGrid("OrderList", "OrderList", '/Admin/GetOrderList');
});
function OnGridEdit(e) {
    var table = $('#GridOrderList').DataTable();
    var data = table.row(e.parentNode).data();
    location.href = '/Admin/Order?Id=' + data.OrderId;//form page
}
function OnGridDelete(e) {
    var data, GetDeleteStatus;
    var table = $('#GridOrderList').DataTable();
    data = table.row(e.parentNode).data();
    if (confirm("Are you sure to proceed?")) {
        AjaxCall('/Admin/OrderDelete', JSON.stringify({ "ID": data.OrderId }), GetDeleteStatus, null);
        BindGrid("OrderList", "OrderList", '/Admin/GetOrderList');
    }
}