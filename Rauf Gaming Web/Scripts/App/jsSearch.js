

function SearchProduct() {
    AjaxCall('/Search/DoSearch', JSON.stringify({ "searchText": $("#txtSearchProduct").val() }), GetLink, null);
}
function GetLink(data) {
    if (data != null) {
        var t = getUrlVars()["t"];
        var m = getUrlVars()["m"];
        var type = data;
    
        if (type == "Game") {
            if (t == "n" && m == "ps") {
                location.href = '/Game/Shop?t=' + t + '&m=' + m;
            }
            if (t == "u" && m == "ps") {
                location.href = '/Game/Shop?t=' + t +'&m=' + m;
            }
            if (t == "n" && m == "xbox") {
                location.href = '/Game/Shop?t=' + t + '&m=' + m;
            }
            if (t == "u" && m == "xbox") {
                location.href = '/Game/Shop?t=' + t + '&m=' + m;
            }
            if (t == "n" && m == "nintendo") {
                location.href = '/Game/Shop?t=' + t + '&m=' + m;
            }
            if (t == "u" && m == "nintendo") {
                location.href = '/Game/Shop?t=' + t + '&m=' + m;
            }
        }
        if (type == "Acc") {

            if (t == "vr") {
                location.href = '/Accessories/Shop?t=' + t; 
            }
            if (t == "tv") {
                location.href = '/Accessories/Shop?t=' + t;
            }
            if (t == "hs") {
                location.href = '/Accessories/Shop?t=' + t;
            }
            if (t == "ms") {
                location.href = '/Accessories/Shop?t=' + t;
            }
            if (t == "js") {
                location.href = '/Accessories/Shop?t=' + t;
            }
            if (t == "kb") {
                location.href = '/Accessories/Shop?t=' + t;
            }
            if (t == "cm") {
                location.href = '/Accessories/Shop?t=' + t;
            }
            if (t == "sp") {
                location.href = '/Accessories/Shop?t=' + t;
            }
        }

        if (type == "Console") {
            if (t == "n" && m == "ps") {
                location.href = '/Console/Shop?t=' + t + '&m=' + m;
            }
            if (t == "u" && m == "ps") {
                location.href = '/Console/Shop?t=' + t + '&m=' + m;
            }
            if (t == "n" && m == "xbox") {
                location.href = '/Console/Shop?t=' + t + '&m=' + m;
            }
            if (t == "u" && m == "xbox") {
                location.href = '/Console/Shop?t=' + t + '&m=' + m;
            }
            if (t == "n" && m == "nintendo") {
                location.href = '/Console/Shop?t=' + t + '&m=' + m;
            }
            if (t == "u" && m == "nintendo") {
                location.href = '/Console/Shop?t=' + t + '&m=' + m;
            }
        }

    }
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