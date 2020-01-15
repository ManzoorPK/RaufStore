function validateMobile(mobi) {
    if (validatePhone(mobi)) {
        $('#spnPhoneStatus').html('');
        //$('#spnPhoneStatus').css('color', 'green');
    }
    else {
        $('#spnPhoneStatus').html('Invalid');
        $('#spnPhoneStatus').css('color', 'red');
    }
}

function validatePhone(txtPhone) {
    var a = document.getElementById(txtPhone).value;
    var filter = /^\d{10}$/;
    if (filter.test(a)) {
        return true;
    }
    else {
        return false;
    }
}
function SweateNoti(lbltitle, lbltext, lbltype) {
    swal({
        title: lbltitle,
        text: lbltext,
        type: lbltype,
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes",
        cancelButtonText: "No, I am not sure!",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        function (isConfirm) {
            if (isConfirm) {
                return true;
            }
            else {
                return false;
            }
        });
}
function NotiTop(Msg) {
    if (Msg.includes("Successfully")) {
        $("#ReturnMsgS").html('');
        $("#alertS").hide();
        $("#ReturnMsgS").html(Msg);
        $("#alertS").show();
    }
    else if (Msg.includes("Error")) {
        $("#ReturnMsgE").html('');
        $("#alertE").hide();
        $("#ReturnMsgE").html(Msg);
        $("#alertE").show();
    }
    else if (Msg.includes("Warning")) {
        $("#ReturnMsgW").html('');
        $("#alertW").hide();
        $("#ReturnMsgW").html(Msg);
        $("#alertW").show();
    }
}

function MsgNoti(Msg) {
    var x = document.getElementById("snackbar");
    $("#spanmsg").html('');
    $("#spanIcon").html('');
    $("#spanmsg").html(Msg);

    //x.innerHTML = Msg;
    var s = Msg;

    if (s.includes("Log Out")) {
        x.style.backgroundColor = "#52ae54";
        x.className = "show";
        $("#spanIcon").html('<i class="fa fa-sign-out"></i>')
    }
    else if (s.includes("Successfully")) {
        x.style.backgroundColor = "#52ae54";
        x.className = "show";
        $("#spanIcon").html('<i class="fa fa-check"></i>');
    }
    else if (s.includes("Welcome")) {
        x.className = "showonLogin";
        $("#spanIcon").html('<i class="fa fa-sign-in"></i>');
        x.style.backgroundColor = "rgb(66, 139, 202)";
        setTimeout(function () { x.className = x.className.replace("showonLogin", ""); }, 5000);
    }
    else {
        x.style.backgroundColor = "#e03f3f";
        x.className = "show";
        $("#spanIcon").html('<i class="fa fa-exclamation-circle"></i>');
    }
    //x.className = x.className.replace("hide", "show");
}
function closeMSG() {
    var x = document.getElementById("snackbar");
    x.className = x.className.replace("show", "hide");
};
