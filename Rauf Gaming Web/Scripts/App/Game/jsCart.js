var type;
function GetProduct(Id, t) {
    if (t == null) {

        var radioValue = $("input[name='platform']:checked").val();
        if (radioValue) {
            type = radioValue;
        }
        else {
            alert("Please select for which platform you need this.");
            return true;
        }
    } else {
        type = t;
    }

    AjaxCall('/Buy/GetProduct', JSON.stringify({ "Id": Id }), GetStatus, null);
}
function DisplayBank(d) {
    if (d == 'g') {
        $("#Ziraatbank").hide();
        $("#Garantibank").show();
    }
    if (d == 'z') {
        $("#Ziraatbank").show();
        $("#Garantibank").hide();
    }
}
function GetStatus(data) {
    var product = new Object();
    product.Id = data.ProductId;
    product.Name = data.Title;
    product.Photo = data.ImagePath;
    product.Price = data.ActualPrice;
    product.Quantity = 1;
    product.Type = type;
    $("#btnP_" + data.ProductId).html("In Cart");
    $("#btnP_" + data.ProductId).attr("disabled", true);
    AjaxCall('/Buy/AddItemToCart', JSON.stringify(product), GetCart, null);
}
function GetCart(data) {
    if (data != "false") {
        //location.href = '/Buy/MyCart';
        if (data != "0") {
            $("#ShowCartIcon").html(data);
            $("#ShowCartIcon").show();
        }
    }
    else {
        alert("An error occured while adding item to your cart.");
    }
}
function RemoveProduct(Id) {
    AjaxCall('/Buy/RemoveProduct', JSON.stringify({ "Id": Id }), GetAfterRemove, null);
}
function GetAfterRemove(data) {
    if (data == "Ok") {
        location.href = '/Buy/MyCart';
    }
}
function AddQuantity(Id) {
    var IdNumber = $(Id).attr('id').split('_')[1];
    var Qty = parseInt($('#txtQty_' + IdNumber).val()) + 1;
    var TotalPrice = parseInt($('#lblPrice_' + IdNumber).val()) * Qty;
    $('#txtQty_' + IdNumber).val(Qty);
    $('#td_' + IdNumber).html('TL' + formatNumber(parseInt(TotalPrice)));
    var pId = $("#productId_" + IdNumber).val();
    var type = $("#productType_" + IdNumber).val();
    AjaxCall('/Buy/UpdateCartItem', JSON.stringify({ "Id": pId, "type": type, "Qty": Qty }), GetAfterAdd, null);

}
function GetAfterAdd(data) {
    if (data == "true") {
        location.href = '/Buy/MyCart';
    }
}
function SubQuantity(Id) {
    var IdNumber = $(Id).attr('id').split('_')[1];
    var Qty = parseInt($('#txtQty_' + IdNumber).val()) - 1;
    if (Qty <= 0) {
        Qty = 1;
    }
    var TotalPrice = parseInt($('#lblPrice_' + IdNumber).val()) * Qty;
    $('#txtQty_' + IdNumber).val(Qty);
    $('#td_' + IdNumber).html('TL' + formatNumber(parseInt(TotalPrice)));
    var pId = $("#productId_" + IdNumber).val();
    var type = $("#productType_" + IdNumber).val();
    AjaxCall('/Buy/UpdateCartItem', JSON.stringify({ "Id": pId, "type": type, "Qty": Qty }), GetAfterSub, null);
}
function GetAfterSub(data) {
    if (data == "true") {
        location.href = '/Buy/MyCart';
    }
}
function Changelng(lang) {
    AjaxCall('/Home/ChangeLng', JSON.stringify({ "Lang": lang}), LngChange, null);
}
function LngChange(data) {
    if (data != "") {
        location.reload();
    }
}
function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
}