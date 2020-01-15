
$(document).ready(function () {

    $("#ClientGameId").change(function () {
        var cId = $("#ClientGameId").val();
        var sId = $("#StoreGameId").val();
        if (sId != "")
            ExchangeGame(cId, sId);
      
    });
    $("#StoreGameId").change(function () {
        var cId = $("#ClientGameId").val();
        var sId = $("#StoreGameId").val();
        if (cId != "")
            ExchangeGame(cId, sId);
    });
});

function ExchangeGame(ClientId, StoreId) {
    AjaxCall('/Exchange/DoExchange', JSON.stringify({ "ClientGameId": ClientId, "StoreGameId": StoreId }), GetExchangeInfo, null);
}
function GetExchangeInfo(data) {
    $("#txtPayment1").val("");
    $("#txtPayment1").val("");
    if (data <= 0) {
        $("#txtPayment1").val(data);
        $("#txtPayment1").show();
        $("#txtPayment").hide();
    } else {
        $("#txtPayment").val(data);
        $("#txtPayment").show();
        $("#txtPayment1").hide();
        $("#txtpayment").css("boarder-color", "green");
    }
}