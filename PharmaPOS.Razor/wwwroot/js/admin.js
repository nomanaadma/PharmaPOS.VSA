 Dropzone.autoDiscover = false;
 
 $(document).ready(function () {

     $('.logout-link').click(function () {
         $('#logoutForm').trigger('submit');
     })
  
    "use strict";

    $('[data-toggle="tooltip"]').tooltip();
    $('[data-toggle="popover"]').popover()

    $('body').on('click', '.menu-close', function () {
        var ele = $(this);
        $('#main-wrapper').addClass('page-menu-small');
        ele.find('i').removeClass('fa-hand-point-left');
        ele.find('i').addClass('fa-hand-point-right');
        ele.removeClass('menu-close');
        ele.addClass('menu-open');
    });

    $('body').on('click', '.menu-open', function () {
        var ele = $(this);
        $('#main-wrapper').removeClass('page-menu-small');
        ele.find('i').removeClass('fa-hand-point-right');
        ele.find('i').addClass('fa-hand-point-left');
        ele.removeClass('menu-open');
        ele.addClass('menu-close');
    });

    $('body').on('click', 'li.has-sub > a', function () {
        var ele = $(this), target = ele.parent('li.has-sub').find('ul.sub-menu:first');
        ele.parent('li.has-sub').siblings('li').find('a .arrow').removeClass('rotate');
        if (target.css('display') === "none") {
            ele.parent('li.has-sub').siblings('li').find('.sub-menu').slideUp();
            ele.find('.arrow').addClass('rotate');
            target.slideDown();
        } else {
            ele.parent('li.has-sub').find('.arrow').removeClass('rotate');
            ele.parent('li.has-sub').find('ul.sub-menu').slideUp();
        }
        return false;
    });

    $('body').on('click', '.open-left-menu', function () {
        var ele = $('.menu-wrapper'), nav_ele = $('.navbar-container');
        $('body').append('<div class="menu-overlay"></div>');
        ele.addClass('menu-mobile-open');
        nav_ele.addClass('menu-mobile-open');
    });

    $('body').on('click', '.menu-overlay', function () {
        $('.menu-wrapper, .navbar-container').removeClass('menu-mobile-open');
        $('.menu-overlay').remove();
    });

    $('body').on('click', '.open-page-menu-desktop', function () {
        var ele = $('.page-hdr-desktop');
        $('.page-search').slideUp(300);
        if (ele.css('display') === "none") {
            ele.slideDown(300);
        } else {
            ele.slideUp(300);
        }
    });
    

    $(document).on('click', '.table-delete', function () {
        $('.delete-card-button input.delete-id').val($(this).find('input').val());
        $("#delete-card").modal({
            keyboard: true
        });
    });

    $('#delete-card').on('hidden.bs.modal', function (e) {
        $('.delete-card-button input.delete-id').val('');
    });

    $('.menu-dropdown').click(function () {
        var ele = $(this);
        if (ele.siblings('.sub-menu').css('display') === 'none') {
            $('.sub-menu').slideUp();
            $('#menu-menu ul a').removeClass('menu-arrow-rotate');
            ele.addClass('menu-arrow-rotate');
            ele.siblings('.sub-menu').slideDown(200);
        } else {
            ele.removeClass('menu-arrow-rotate');
            $('.sub-menu').slideUp(200);
        }
    });


    $('.theme-accordion:nth-child(1) .theme-accordion-bdy').slideDown();
    $('.theme-accordion:nth-child(1) .theme-accordion-control i').addClass('ti-minus');
    $('body').on('click', '.theme-accordion-hdr', function () {
        var ele = $(this);
        $('.theme-accordion-bdy').slideUp();
        $('.theme-accordion-control i').removeClass('ti-minus');
        if (ele.parents('.theme-accordion').find('.theme-accordion-bdy').css('display') === "none") {
            ele.find('.theme-accordion-control i').addClass('ti-minus');
            ele.parents('.theme-accordion').find('.theme-accordion-bdy').slideDown();
        } else {
            ele.find('.theme-accordion-control i').removeClass('ti-minus');
            ele.parents('.theme-accordion').find('.theme-accordion-bdy').slideUp();
        }
    });
    
    const dateFormat = "dd/mm/yy";

    //Filter date picker
    $('.filter-date').datepicker({
        dateFormat: dateFormat
    });

    //Filter date picker
    $('.date').datepicker({
        dateFormat: dateFormat
    });
    

    var dataTable = $('.datatable-table').DataTable({
        aLengthMenu: [[10, 25, 50, 75, -1], [10, 25, 50, 75, "All"]],
        iDisplayLength: 10,
        pagingType: 'full_numbers',
        order: [],
        dom: "<'row align-items-center pb-3'<'col-sm-6 text-left'l><'col-sm-6 text-right'f>><'row'<'col-sm-12'tr>><'row align-items-center pt-3'<'col-sm-12 col-md-4'i><'col-sm-12 col-md-8 text-right dataTables_pager'p>>",
        responsive: true,
        language: {
            "paginate": {
                "first":       '<i class="las la-angle-double-left"></i>',
                "previous":    '<i class="las la-angle-left"></i>',
                "next":        '<i class="las la-angle-right"></i>',
                "last":        '<i class="las la-angle-double-right"></i>'
            },
        }
    });

    $('.datatable-count-table').DataTable({
        aLengthMenu: [[10, 25, 50, 75, -1], [10, 25, 50, 75, "All"]],
        iDisplayLength: 10,
        pagingType: 'full_numbers',
        order: [],
        dom: "<'row align-items-center pb-3'<'col-sm-6 text-left'l><'col-sm-6 text-right'f>><'row'<'col-sm-12'tr>><'row align-items-center pt-3'<'col-sm-12 col-md-4'i><'col-sm-12 col-md-8 text-right dataTables_pager'p>>",
        responsive: false,
        language: {
            "paginate": {
                "first":       '<i class="las la-angle-double-left"></i>',
                "previous":    '<i class="las la-angle-left"></i>',
                "next":        '<i class="las la-angle-right"></i>',
                "last":        '<i class="las la-angle-double-right"></i>'
            },
        },
        footerCallback: function ( row, data, start, end, display ) {

            if(row == undefined) return;

            var api = this.api(), data, column;
            var intVal = function ( i ) {
                return typeof i === 'string' ?
                i.replace(/[\Rs,]/g, '')*1 :
                typeof i === 'number' ?
                i : 0;
            };

            if (data.length === 0) {
                for (var i = 0; i < row.childElementCount; i++) {
                    $(api.column(i).footer()).html('');
                }
                return;
            }

            let dataHtml = '<div class="row datatotals">';


            for (var i = row.childElementCount - 1; i >= 0; i--) {
                if (i == 0 ) {
                    $( api.column(i).footer() ).html('Total');
                } else if (i > 0) {
                    column = api.column(i).data().reduce( function (a, b) {
                        return intVal(a) + intVal(b);
                    }, 0 );

                    column = api.column( i, { page: 'current'} ).data().reduce( function (a, b) {
                        return intVal(a) + intVal(b);
                    }, 0 );

                    if (!Number.isNaN(column))  {
                        
                        const columnTitle = $(api.column(i).header()).text();

                        if( $(this).hasClass('stock-list') ) {

                            const cols = ['Total Purchase', 'Total Sale', 'Profit', 'Sold'];
                            
                            if( cols.includes(columnTitle) ) {

                                const currencyCol =  ['Total Purchase', 'Total Sale', 'Profit'];

                                let numbers = column.toFixed(2);

                                if( currencyCol.includes(columnTitle) ) {
                                    numbers = common_currency+column.toFixed(2);
                                }

                                dataHtml += `
                                    <div class="col">
                                        <div class="dashboard-stat">
                                            <div class="content"><h4 class="text-dark">${numbers}</h4>
                                            <span class="text-dark">${columnTitle}</span></div>
                                            <div class="icon"><i class="las la-dollar-sign text-secondary"></i></div>
                                        </div>
                                    </div>
                                `;
    
                                $( api.column(i).footer() ).html(numbers);

                            }                     

                        } else if( $(this).hasClass('report_inventory') ) {

                            const cols = ['Purchase', 'Sales', 'Profit'];
                            
                            if( cols.includes(columnTitle) ) {

                                let numbers = common_currency+column.toFixed(2);

                                dataHtml += `
                                    <div class="col">
                                        <div class="dashboard-stat">
                                            <div class="content"><h4 class="text-dark">${numbers}</h4>
                                            <span class="text-dark">${columnTitle}</span></div>
                                            <div class="icon"><i class="las la-dollar-sign text-secondary"></i></div>
                                        </div>
                                    </div>
                                `;
    
                                $( api.column(i).footer()).html(numbers);

                            } 

                        } else {
                         
                            $( api.column(i).footer() ).html(common_currency+column.toFixed(2));

                        }
                    }
                }

            }

            dataHtml += '</div>';

            $('.datatotals').remove();

            $(dataHtml).insertBefore('.dataTables_wrapper');
        }
    });

    $('.toggle-button a').on( 'click', function (e) {
        e.preventDefault();
        var ele = $(this);
        var column = countdatatable.column(ele.attr('data-column'));
        if (column.visible()) {
            ele.find('i').removeClass('la-toggle-on');
            ele.find('i').addClass('la-toggle-off');
        } else {
            ele.find('i').addClass('la-toggle-on');
            ele.find('i').removeClass('la-toggle-off');
        }
        column.visible(!column.visible());
    });

     if ($('.alert-message').length) {
         const $alertInput = $('.alert-message'); // Store reference to the element
         const alert_message = JSON.parse($alertInput.val());

         toastr.options = {
             "closeButton": true,
             "debug": false,
             "newestOnTop": false,
             "progressBar": false,
             "positionClass": "toast-top-right",
             "preventDuplicates": false,
             "onclick": null,
             "showDuration": "10000",
             "hideDuration": "10000",
             "timeOut": "2000",
             "extendedTimeOut": "800",
             "showEasing": "swing",
             "hideEasing": "linear",
             "showMethod": "fadeIn",
             "hideMethod": "fadeOut"
         }

         toastr[alert_message.alert](alert_message.value, alert_message.alert);

         // Remove the input from the DOM so it doesn't trigger on browser back
         $alertInput.remove();
     }
     
});



