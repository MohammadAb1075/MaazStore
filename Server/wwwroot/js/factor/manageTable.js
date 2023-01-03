
var table;
var rowTable
var rowOuterHtml = ''

$(document).ready(function () {
    table = $('#factorRowTable');
    rowTable = $('#factorRowTable').find('tbody tr').first()
    rowOuterHtml = rowTable.get(0).outerHTML;

    function AddItem(btn) {
        var lastRow = table.find('tbody tr').last();
        console.log(lastRow)
        if (lastRow.length == 0) {
            table.find('tbody').append(rowOuterHtml)
        }
        lastRow.after(rowOuterHtml)
        rebindvalidators();
    }

    function rebindvalidators() {

        var $form = $("#createForm");

        $form.unbind();

        $form.data("validator", null);

        $.validator.unobtrusive.parse($form);

        $form.validate($form.data("unobtrusiveValidation").options);
    }

    function DeleteItem(btn) {
        if (table.find('tbody tr').length > 1) {
            btn.parents('tr').remove()
        }
        //CalcTotals();

}


    $('body').on('click', '.btnremove', function () {
        DeleteItem($(this))
    })
    
    $('body').find('#btnAddDetailRow').click(function () {
        AddItem(this)
    })

})