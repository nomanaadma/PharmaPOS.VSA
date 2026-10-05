function roundNumber(number, decimals) {
	var newString;
	decimals = Number(decimals);
	if (decimals < 1) {
		newString = (Math.round(number)).toString();
	} else {
		var numString = number.toString();
		if (numString.lastIndexOf(".") == -1) {
			numString += ".";
		}
		var cutoff = numString.lastIndexOf(".") + decimals;
		var d1 = Number(numString.substring(cutoff, cutoff + 1));
		var d2 = Number(numString.substring(cutoff + 1, cutoff + 2));
		if (d2 >= 5) {
			if (d1 == 9 && cutoff > 0) {
				while (cutoff > 0 && (d1 == 9 || isNaN(d1))) {
					if (d1 != ".") {
						cutoff -= 1;
						d1 = Number(numString.substring(cutoff, cutoff + 1));
					} else {
						cutoff -= 1;
					}
				}
			}
			d1 += 1;
		}
		if (d1 == 10) {
			numString = numString.substring(0, numString.lastIndexOf("."));
			var roundedNum = Number(numString) + 1;
			newString = roundedNum.toString() + '.';
		} else {
			newString = numString.substring(0, cutoff) + d1.toString();
		}
	}
	if (newString.lastIndexOf(".") == -1) {
		newString += ".";
	}
	var decs = (newString.substring(newString.lastIndexOf(".") + 1)).length;
	for (var i = 0; i < decimals - decs; i++) newString += "0";
	return newString;
}

function updateTotal() {
	var total = 0, discount = 0;

	$('.item-gross').each(function (i) {
		var price = $(this).val();
		if (!isNaN(price) && price !== "") { total += Math.abs(Number(price)); }
	});

	var taxtotal = 0;
	$('.item-taxprice').each(function (i) {
		var taxprice = $(this).val();
		if (!isNaN(taxprice) && taxprice !== "") { taxtotal += Math.abs(Number(taxprice)); }
	});

	$('.item-discountvalue').each(function (i) {
		var value = $(this).val();
		if (!isNaN(value) && value !== "") { discount += Math.abs(Number(value)); }
	});

	total = roundNumber(total, 2);
	var taxpriceStr = roundNumber(taxtotal, 2);
	var discountStr = roundNumber(discount, 2);

	$('.total-price').val(total);
	$('.total-tax').val(taxpriceStr);
	$('.total-discount').val(discountStr);

	var amount = Number(total) - Number(discountStr) + parseFloat(taxpriceStr);
	amount = Number(roundNumber(amount, 2));
	if (amount < 0) amount = 0;

	$('.total-amount').val(amount);
}

function updatePrice() {
	$('.item-row').each(function () {
		var row = $(this);
		
		var purchasePrice = Number(row.find('.item-purchaseprice').val());
		if (purchasePrice < 0) {
			purchasePrice = Math.abs(purchasePrice);
			row.find('.item-purchaseprice').val(purchasePrice);
		}
		
		var qty = Number(row.find('.item-qty').val());
		if (qty < 0) {
			qty = Math.abs(qty);
			row.find('.item-qty').val(qty);
		}
		
		var price = purchasePrice * qty;

		price = Number(roundNumber(price, 2));
		row.find('.item-gross').val(price);

		var discounttype = row.find('.item-discounttype').val();
		var discount = Number(row.find('.item-discount').val());
		if (discount < 0) {
			discount = Math.abs(discount);
			row.find('.item-discount').val(discount);
		}

		discount = Number(roundNumber(discount, 2));
		if (discounttype === "2") {
			price = price - discount;
			row.find('.item-discountvalue').val(discount);
		} else {
			var discountVal = price * discount * 0.01;
			discountVal = Number(roundNumber(discountVal, 2));
			row.find('.item-discountvalue').val(discountVal);
			price = price - discountVal;
		}

		var tax = Number(row.find('.item-tax').val());
		if (tax < 0) {
			tax = Math.abs(tax);
			row.find('.item-tax').val(tax);
		}
		
		var tax_price = price * tax * 0.01;
		tax_price = Number(roundNumber(tax_price, 2));
		row.find('.item-taxprice').val(tax_price);

		price += tax_price;
		price = Number(roundNumber(price, 2));
		if (price < 0) price = 0;

		isNaN(price) ? row.find('.item-price').val("N/A") : row.find('.item-price').val(price);
	});
	updateTotal();
}

function bind() {
	$(".item-purchaseprice").on('input', updatePrice);
	$(".item-qty").on('input', updatePrice);
	$(".item-discounttype").on('input', updatePrice);
	$(".item-discount").on('input', updatePrice);
	$(".item-tax").on('input', updatePrice);
	$("body").on('change', '.discount-type', updatePrice);
}

function initDatepicker() {
	$('.exp-date').datetimepicker({
		viewMode: 'years',
		format: "MM-YYYY",
		widgetPositioning: {
			horizontal: 'auto',
			vertical: 'auto'
		},
		collapse: true,
		icons: {
			time: "far fa-clock",
			date: "far fa-calendar-alt",
			up: "fas fa-angle-up",
			down: "fas fa-angle-down",
			previous: 'fas fa-angle-left',
			next: 'fas fa-angle-right',

		}
	});
}

function initAutocomplete() {
	$(".item-name").autocomplete({
		minLength: 0,
		source: ('/getmedicine'),
		focus: function (event, ui) {
			$(this).parents('tr').find('.item-name').val(ui.item.label);
			return false;
		},
		select: function (event, ui) {
			$(this).parents('tr').find('.item-name').val(ui.item.label);
			$(this).parents('tr').find('.item-id').val(ui.item.id);
			$(this).removeClass('ui-state-error');
			return false;
		}
	});
}

var discountTypeOptionsHtml;

function itemHtml(count) {
	var item_html = '<tr class="item-row">' +
		'<td>' +
		'<textarea class="item-name" name="Input.Items[' + count + '].Name" required></textarea>' +
		'<input type="hidden" class="item-id" name="Input.Items[' + count + '].MedicineId">' +
		'<input type="hidden" name="Input.Items[' + count + '].Id" value="0">' +
		'</td>' +
		'<td>' +
		'<textarea class="item-batch" name="Input.Items[' + count + '].Batch" required></textarea>' +
		'</td>' +
		'<td>' +
		'<input type="text" class="item-expiry exp-date p-2 datetimepicker-input bg-white" name="Input.Items[' + count + '].Expiry" required>' +
		'</td>' +
		'<td>' +
		'<textarea class="item-pqty" name="Input.Items[' + count + '].Pqty"></textarea>' +
		'</td>' +
		'<td>' +
		'<textarea class="item-qty" name="Input.Items[' + count + '].Qty" required></textarea>' +
		'</td>' +
		'<td>' +
		'<textarea class="item-purchaseprice" name="Input.Items[' + count + '].Purchaseprice" required></textarea>' +
		'</td>' +
		'<td>' +
		'<textarea class="item-saleprice" name="Input.Items[' + count + '].SalePrice" required></textarea>' +
		'</td>' +
		'<td>' +
		'<input class="item-gross" readonly name="Input.Items[' + count + '].Gross" value="0" />' +
		'</td>' +
		'<td class="">' +
		'<div class="row no-gutters">' +
		'<div class="col">' +
		'<select name="Input.Items[' + count + '].DiscountType" class="custom-select border-light item-discounttype">'
            + discountTypeOptionsHtml +
		'</select>' +
		'</div>' +
		'<div class="col">' +
		'<textarea type="text" name="Input.Items[' + count + '].Discount" class="item-discount">0</textarea>' +
		'<input type="text" readonly name="Input.Items[' + count + '].DiscountValue" class="item-discountvalue" value="0">' +
		'</div>' +
		'</div>' +
		'</td>' +
		'<td class="invoice-tax">' +
		'<input type="text" name="Input.Items[' + count + '].Tax" class="item-tax" value="0">' +
		'<input type="text" readonly name="Input.Items[' + count + '].TaxPrice" class="item-taxprice" value="0">' +
		'</td>' +
		'<td>' +
		'<textarea class="bg-white item-price" name="Input.Items[' + count + '].Price" required readonly></textarea>' +
		'</td>' +
		'<td>' +
		'<a class="badge badge-danger badge-sm badge-pill delete m-1">Delete</a>' +
		'</td>' +
		'</tr>';

	if (count === 0) {
		$(".purchase-items tbody").prepend(item_html);
	} else {
		$(".purchase-items .item-row:last").after(item_html);
	}
}

$(document).ready(function () {
	"use strict";

    const discountTypeOptions = $('.item-discounttype option');

    discountTypeOptionsHtml = discountTypeOptions.map(function() {
        return this.outerHTML; // 'this' refers to the raw DOM element
    }).get().join('').replace(/ selected="selected"/gi, '').replace(/ selected/gi, '');

	$('.purchase-items').on('click', '.add-items', function () {
		if ($(".item-row").length === 0) {
			itemHtml(0);
		} else {
			var count = $('.purchase-items table tr.item-row:last .item-name').attr('name').split('[')[1];
			count = parseInt(count.split(']')[0]) + 1;
			itemHtml(count);
		}
		initAutocomplete();
		initDatepicker();
		bind();
	});

	$('.purchase-items').on('click', '.delete', function () {
		var ele = $(this);
		ele.parents('.item-row').remove();
		bind();
		return false;
	});

	$(".item-name").on('input', function () {
		const ethis = $(this);
		ethis.next().val('');
		ethis.addClass('ui-state-error');
	});

	$('.purchase_form').submit(function (e) {

		$('.item-id').each(function () {
			const itemEl = $(this);
			const item_id = itemEl.val();

			if (item_id == "") {

				e.preventDefault();

				itemEl.prev().addClass('ui-state-error');
				itemEl.focus();

			} else {
				itemEl.prev().removeClass('ui-state-error');
			}

		});

	});

	initAutocomplete();
	initDatepicker();
	bind();

});