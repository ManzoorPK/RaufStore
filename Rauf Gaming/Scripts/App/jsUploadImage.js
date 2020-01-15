$(document).ready(function () {
   
    var op = getUrlVars()["o"];

    if (op != null) {
        if (op == "s")
            alert("Image Uploaded Successfully.");
        if (op == "d")
            alert("Image Deleted Successfully.");
    }
    $('#btnUpload').click(function () {
        var Id = getUrlVars()["id"];
        // Checking whether FormData is available in browser  
        if (window.FormData !== undefined) {

            var fileUpload = $("#FileUpload1").get(0);
            var files = fileUpload.files;

            // Create FormData object  
            var fileData = new FormData();

            // Looping over all files and add it to FormData object  
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }
            $.ajax({
                url: '/Admin/UploadFiles?id=' + Id,
                type: "POST",
                contentType: false, // Not to set any content header  
                processData: false, // Not to process data  
                data: fileData,
                success: function (result) {
                    location.href = '/Admin/Images?id=' + Id + "&o=s";//form page
                },
                error: function (err) {
                    alert(err.statusText);
                }
            });
        } else {
            alert("FormData is not supported.");
        }
    });
});
function ImageDelete(Id) {
    if (confirm("Are you sure to proceed?")) {
        AjaxCall('/Admin/ImageDelete', JSON.stringify({ "ID": Id }), GetDeleteStatus, null);
    }
}
function GetDeleteStatus(data) {
    var Id = getUrlVars()["id"];
    if (data == "true") {
        location.href = '/Admin/Images?id=' + Id + "&o=d";//form page
    }
    else {
        alert("An error occured while deleting image.");
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