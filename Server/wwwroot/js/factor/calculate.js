function calculate(selector, trElement) { 
    var UnitPrice = trElement.find('.form-c.UnitPrice').val() 
    var Quantity = trElement.find('.form-c.Quantity').val() 
    var Discount = trElement.find('.form-c.Discount').val() 

    var DiscountedUnitPrice = UnitPrice * (100 - Discount) / 100;
    var RowPriceTotal = Quantity * UnitPrice;
    var DiscountedRowPriceTotal = RowPriceTotal * (100 - Discount) / 100;
    var CustomerProfitUnitDiscount = UnitPrice * Discount / 100;
    var CustomerProfitTotalDiscount = RowPriceTotal * Discount / 100;

    var calcObject = {
        DiscountedUnitPrice: DiscountedUnitPrice,
        RowPriceTotal: RowPriceTotal,
        DiscountedRowPriceTotal: DiscountedRowPriceTotal,
        CustomerProfitUnitDiscount: CustomerProfitUnitDiscount,
        CustomerProfitTotalDiscount: CustomerProfitTotalDiscount,
    }
    $.each(calcObject, function (k, v) {
        trElement.find('.form-c.' + k).val(v)
    })
    calcTotal(trElement.parents('table'));
}

