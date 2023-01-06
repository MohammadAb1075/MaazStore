function calcTotal(tableElement) {
    var TotalPrice = 0;
    var TotalDiscount = 0;
    var Payable = 0
    $.each(tableElement.find('td.RowPriceTotal .form-c.RowPriceTotal'), function () {
        TotalPrice += Number($(this).val());
    })
    $.each(tableElement.find('td.CustomerProfitTotalDiscount .form-c.CustomerProfitTotalDiscount'), function () {
        TotalDiscount += Number($(this).val());
    })
    $.each(tableElement.find('td.DiscountedRowPriceTotal .form-c.DiscountedRowPriceTotal'), function () {
        Payable += Number($(this).val());
    })
    var totalObject = {
        TotalPrice: TotalPrice,
        TotalDiscount: TotalDiscount,
        Payable: Payable,
    }

    $.each(totalObject, function (k, v) {
        tableElement.find('.form-c.' + k).val(v)
    })

}
