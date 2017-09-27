$(document).ready(function () {

    function readMainURL(input) {

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#Main').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
    $("#imgMain").change(function () {
        readMainURL(this);
    });


    function readOtherURL(input) {

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#Other').attr('src', e.target.result);
            }
                reader.readAsDataURL(input.files[0]);
            }
        }
    
    $("#imgOther").change(function () {
        readOtherURL(this);
    });

    function readLogoURL(input) {

        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#Logo').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
    }
    $("#imgLogo").change(function () {
        readLogoURL(this);
    });

});
     
