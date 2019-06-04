$(document).ready(function () {
    $('#btn-logo').change(function (e) {

        var file = e.target.files;


        var tagimg = $('#img-logo');

        var fileReader = new FileReader();


        fileReader.onload = function (event) {
            var imageUrl = event.target.result;
            $(tagimg).attr('src', imageUrl);
            $('#value-img-logo').val(imageUrl);
        };

        fileReader.readAsDataURL(file[0]);
    });
});