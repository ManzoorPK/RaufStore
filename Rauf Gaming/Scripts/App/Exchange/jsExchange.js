$(document).ready(function () {
    var Id = getUrlVars()["Id"];
    if (Id != null)
        AjaxCall('/Admin/ExchangeEdit', JSON.stringify({ "Id": Id }), LoadExchange, null);
});
function LoadExchange(data) {
    $("#ExchangeId").val(data.ExchangeId);
    $("#Title").val(data.Title);
    $("#StorePrice").val(data.StorePrice);
    $("#BuyingPrice").val(data.BuyingPrice);
    $("#Platform").val(data.Platform);
}
function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}