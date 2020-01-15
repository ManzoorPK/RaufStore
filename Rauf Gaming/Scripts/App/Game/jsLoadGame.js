$(document).ready(function () {
    var Id = getUrlVars()["id"];
    var type = getUrlVars()["t"];
    //BindDropDownList("TagsList", '/Admin/GetTagsdrp', true, "Select Tag", null);
    if (type != null) {
        $("#Type").val(type);
    }

    if (Id != null) {
        AjaxCall('/Admin/ProductEdit', JSON.stringify({ "Id": Id }), LoadGameInfo, null);
    }
   
});
function LoadGameInfo(data) {
    $("#ProductId").val(data.ProductId);
    $("#Title").val(data.Title);
    $("#Description").val(data.Description);
    $("#ActualPrice").val(data.ActualPrice);
    $("#Genre").val(data.Genre);
    $("#Publishers").val(data.Publishers);
    $("#Platform").val(data.Platform);
    $("#Rating").val(data.Rating);
    $("#Condition").val(data.Condition);
    $("#Category").val(data.Category);

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