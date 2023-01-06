var table = $('#factorRowTable');
//var rowTable
var rowOuterHtml = ''
$(function () {

    function AddItem(btn) {
        //rowTable = table.find('tbody tr').last()
        //rowOuterHtml = rowTable.get(0).outerHTML;
        var lastRow = table.find('tbody tr').last();
        rowOuterHtml = lastRow.get(0).outerHTML;
        var lastrowIdx = lastRow.attr('rowIndex');
        if (!lastrowIdx) {
            lastrowIdx = table.find('tbody tr').length - 1;
        }
        var nextrowIdx = eval(lastrowIdx) + 1;
        rowOuterHtml = rowOuterHtml.replaceAll('_' + lastrowIdx + '_', '_' + nextrowIdx + '_');
        rowOuterHtml = rowOuterHtml.replaceAll('[' + lastrowIdx + ']', '[' + nextrowIdx + ']');
        rowOuterHtml = rowOuterHtml.replaceAll('-' + lastrowIdx, '-' + nextrowIdx);

        var trElement = $(rowOuterHtml);
        trElement.find('.form-c').val('0');
        //console.log(rowOuterHtml)
        if (lastRow.length == 0) {
            table.find('tbody').append(rowOuterHtml);
        }
        lastRow.after(rowOuterHtml);
        table.find('tbody tr').last().attr('rowIndex', nextrowIdx).find('.form-c').val('0');
        table.find('tbody tr').last().find('select.form-c').val('$0');
        rebindvalidators();
    }

    function rebindvalidators() {

        var $form = $("#factorForm");

        $form.unbind();

        $form.data("validator", null);

        $.validator.unobtrusive.parse($form);

        $form.validate($form.data("unobtrusiveValidation").options);
    }

    function DeleteItem(btn) {
        if (table.find('tbody tr').length > 1) {
            $(this).parents('table').find('.IsDeleted').val('1')
            btn.parents('tr').hide()
        }
        calcTotal(table);
    }

    $('body').on('click', '.btnremove', function () {
        DeleteItem($(this))
    })
    
    $('body').find('#btnAddDetailRow').click(function () {
        AddItem(this)
    })

})