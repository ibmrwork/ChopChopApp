$(document).ready(function () {
    debugger
    $("#btnLogIn").click(function () {
        var LoginData = {
            "UserName": $("#txtUserName").val(),
            "Password": $("#txtPassword").val()
        };
        $.ajax({
            type: "POST",
            Url: '/Areas/Account/Login/Login',
            data: LoginData,
            dataType: "json",
            beforeSend: function () {
                $("#loader").show();
            },
            success: function (data) {
                if (data == "Admin") {
                    $("#loader").hide();
                    window.location.href = "/Admin/Dashboard/Dashboard";
                }
            },
            error: function (xhr) { alert('Invalid Email and Password'); }
        })
    });
});