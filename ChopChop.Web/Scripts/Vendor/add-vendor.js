$(document).ready(function () {
    debugger
    $("#btnSaveVendor").click(function () {
        debugger
        if (window.FormData !== undefined) {

            var fileUpload = $("#imgMain").get(0);
            var files = fileUpload.files;

            // Create FormData object  
            var fileData = new FormData();

            // Looping over all files and add it to FormData object  
            for (var i = 0; i < files.length; i++) {
                fileData.append(files[i].name, files[i]);
            }

        }
        debugger
        var vendorData = {
            "VendorName": $("#txtVendorName").val(),
            "VendorStyle": $("#ddlStyles :selected").val(),
            "Phone": $("#txtPhone").val(),
            "AddressLine1": $("#txtAddress").val(),
            "LunchTimeWeakDay": $("#ddlLunchTimeWeakDay :selected").val(),
            "LunchTimeWeakEnd": $("#ddlLunchTimeWeakEnd :selected").val(),
            "DinnerTimeWeakDay": $("#ddlDinnerTimeWeakDay :selected").val(),
            "DinnerTimeWeakEnd": $("#ddlDinnerTimeWeakEnd :selected").val(),
            "LunchWeakDays": $("#ddlLunchWeakDay :selected").val(),
            "LunchWeakEnd": $("#ddlLunchWeakEnd :selected").val(),
            "DinnerWeakDays": $("#ddlDinnerWeakDay :selected").val(),
            "DinnerWeakEnd": $("#ddlDinnerWeakEnd :selected").val(),
            "MainImagePath": fileData,
        }
        $.ajax({  
            url: '/Vendor/Vendor/SaveVendor',
            type: "POST",  
           dataType: "json", // Not to set any content header  
           
           data: vendorData,
            
            success: function (result) {  
                alert(result);  
            },  
            error: function (err) {  
                alert(err.statusText);  
            }  
         
     
});  
    })
})