﻿function CalcTotals() {

    var x = document.getElementsByClassName('QtyTotal');


    var totalQty = 0;
    var Amount = 0;
    var totalAmount = 0;
    var txtExchangeRate = eval(document.getElementById('txtExchangeRate').value);



    var i;

    for (i = 0; i < x.length; i++) {

        var idofIsDeleted = i + "__IsDeleted";

        var idofPrice = i + "__PrcInBaseCur";

        var idofFob = i + "__Fob";

        var idofTotal = i + "__Total";

        var hidIsDelId = document.querySelector("[id$='" + idofIsDeleted + "']").id;

        var priceTxtId = document.querySelector("[id$='" + idofPrice + "']").id;

        var fobTxtId = document.querySelector("[id$='" + idofFob + "']").id;

        var totalTxtId = document.querySelector("[id$='" + idofTotal + "']").id;


        if (document.getElementById(hidIsDelId).value != "true") {
            totalQty = totalQty + eval(x[i].value);

            var txttotal = document.getElementById(totalTxtId);
            var txtprice = document.getElementById(priceTxtId);
            var txtfob = document.getElementById(fobTxtId);

            txtprice.value = txtExchangeRate * eval(txtfob.value);

            txttotal.value = eval(x[i].value) * txtprice.value;

            totalAmount = eval(totalAmount) + eval(txttotal.value);
        }
    }

    document.getElementById('txtQtyTotal').value = totalQty;
    document.getElementById('txtAmountTotal').value = totalAmount.toFixed(2);

    return;
}
