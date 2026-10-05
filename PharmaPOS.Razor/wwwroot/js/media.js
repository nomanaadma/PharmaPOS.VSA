$(document).ready(function () {

    $('.image-upload').click(function () {
        $(this).parent().addClass('image-upload-progress');
        $("#media-upload").modal('show');
    });

    $('#media-upload').on('show.bs.modal', function (e) {
        var uploaded = $('#media-upload .uploaded');
        if (uploaded.val() === '0') {
            $.ajax({
                type: 'get',
                url: '/media/get',
                data: { name: 'media' },
                success: function (response) {
                    $('#media-upload .media-all').append(response);
                    uploaded.val('1');
                }
            });
        }
        $('#media-upload .media-all').addClass('media-modal-open');
    });


    $("#media-upload").on('hidden.bs.modal', function () {
        $(this).parent().find('.image-upload-progress').removeClass('image-upload-progress');
        $('#media-upload .media-all').removeClass('media-modal-open');
    });
    
    $("#media-dropzone").dropzone({
        addRemoveLinks: false,
        acceptedFiles: "image/*",
        maxFilesize: 5,
        autoProcessQueue: true,
        dictDefaultMessage: 'Drop files here or click here to upload <br /><br /> Only Image',
        init: function() {
            var reportDropzone = this;

            reportDropzone.on("success", function(file, response) {
                if (response.error === false) {
                    $('.media-all').prepend(response.media);
                    toastr.success('Uploaded Succefully', 'Media Uploaded Succefully.');
                } else {
                    toastr.error('Error', response.message);
                }
                reportDropzone.removeFile(file);
            });

            reportDropzone.on("error", function(file, message) {
                toastr.error('Error', message);
                reportDropzone.removeFile(file);
            });
        },
    });

    $('#media-upload').on('click', '.media-modal-open .picture', function () {
        var image = $(this).find('input').val();
        $('.image-upload-progress .saved-picture').append('<img src="/uploads/' + image + '" alt="">');
        $('.image-upload-progress .saved-picture input[type=hidden]').val(image);
        $('.image-upload-progress .saved-picture').show();
        $('.image-upload-progress .image-upload').hide();
        $('.image-upload-progress .saved-picture-delete').show();
        $('.content-input').removeClass('image-upload-progress');
        $('#media-upload').modal('hide');
    });

    // Image Delete 
    $('.media-all').on('click', '.block .remove', function () {
        var ele = $(this), ele_par = ele.parent(),
            media = ele_par.find('.picture input').val(),
            id = ele_par.find('.block-id').val();
        $.ajax({
            method: "POST",
            url: ('/media/delete'),
            data: { page: 'media', name: media, id: id, __RequestVerificationToken: xsrfToken },
            error: function () {
                alert('Sorry Try Again!');
            },
            success: function (response) {
                if (response.error === false) {
                    ele.parents('.block').remove();
                    toastr.success('Deleted', 'File deleted Succefully.');
                } else {
                    toastr.success('Wanrning', 'File could not be deleted!.');
                }
            }
        });
    });

    $('.saved-picture-delete').click(function () {
        $(this).siblings('.saved-picture').find('img').remove();
        $(this).siblings('.saved-picture').find('input').val('');
        $(this).siblings('.saved-picture').hide();
        $(this).siblings('.image-upload').show();
        $(this).hide();
    });
    
});