$(document).ready(function () {
    
    let medicine_report_name = $('.medicine_report_name');
    
    if(medicine_report_name.length) {

        medicine_report_name.on('input', function() {
            $(this).next().val('');
        });

        medicine_report_name.autocomplete({
            source: ('/getmedicine'),
            minLength: 2,
            focus: function() {return false;},
            select: function( event, ui ) {
                medicine_report_name.val(ui.item.label);
                $('.item-medicine-id').val(ui.item.id);
                return false;
            }
        }).autocomplete( "instance" )._renderItem = function( ul, item ) {
            return $( "<li>" )
                .append('<div>' + item.label + '</div>')
                .appendTo( ul );
        };
    
    }

    if ($('.table-date-range').length) {
        var tabledate_data = $('.table-date-range').data();
        $('.table-date-range').daterangepicker({
            autoApply: false,
            alwaysShowCalendars: true,
            opens: 'left',
            applyButtonClasses: 'btn-danger',
            cancelClass: 'btn-white',
            locale: {
                format: "DD/MM/YYYY",
                separator: " => ",
            },
            startDate: tabledate_data.start,
            endDate: tabledate_data.end,
            ranges: {
                'Today': [moment(), moment()],
                'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                'This Month': [moment().startOf('month'), moment().endOf('month')],
                'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
                'This Year': [moment().startOf('year'), moment().endOf('year')],
                'All Time': [moment('2015-01-01'), moment().add(1, 'days')],
            },
        });

        $('.table-date-range').on('apply.daterangepicker', function(ev, picker) {
            window.location.replace(tabledate_data.route+'start='+picker.startDate.format('YYYY-MM-DD')+'&end='+picker.endDate.format('YYYY-MM-DD')+'&medicineId='+$('.item-medicine-id').val()+'&medicineName='+$('.medicine_report_name').val());
        });
    }
    
    
});