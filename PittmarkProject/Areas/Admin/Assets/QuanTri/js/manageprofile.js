$(document).ready(function () {
    $('[data-toggle="popover"]').popover();

    $('.btn-remove').click(function () {
        $(this).parent().remove();
    });

    $('.btn-them-moi-thuoc-tinh').click(function () {
        $(this).parent().parent().append($('#div-input-mau').html());
        $('.btn-remove').click(function () {
            $(this).parent().remove();
        });
    });


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


    $('#btn-cover').change(function (e) {

        var file = e.target.files;


        var tagimg = $('#img-cover');

        var fileReader = new FileReader();


        fileReader.onload = function (event) {
            var imageUrl = event.target.result;
            $(tagimg).attr('src', imageUrl);
            $('#value-img-cover').val(imageUrl);
        };
        fileReader.readAsDataURL(file[0]);
    });
  
   
});
