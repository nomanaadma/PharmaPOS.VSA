$(function () {

    //Stock table update modal
    $('.stock-table').on('click', '.edit-stock', function () {
        var ele = $(this), ele_parent = ele.parents('tr'),
            data = ele.data();
        $('#editstock-modal input[name="available"]').val(ele_parent.find('.available').text());
        $('#editstock-modal input[name="id"]').val(data.id);
        $('#editstock-modal input[name="medicineId"]').val(data.medicineid);
        $('#editstock-modal .medicine').html(data.medicine);
        $('#editstock-modal .batch').html(ele_parent.find('.batch').text());
        $('#editstock-modal .expiry').html(ele_parent.find('.expiry').text());
        $('#editstock-modal .qty').html(ele_parent.find('.qty').text());
        $('#editstock-modal .sold').html(ele_parent.find('.sold').text());
        $('#editstock-modal').modal('show');
    });

    $('#editstock-modal').on('hidden.bs.modal', function (e) {
        $('#editstock-modal input').not( "[name='_token']" ).val('');
    });
    
});