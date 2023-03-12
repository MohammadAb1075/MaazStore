$(function () {
    $('table').on('change', 'tr td.Product .selectProduct', function () {
        var trElement = $(this).parents('tr')
        var value = $(this).val()
        $(this).siblings('input.ProductId').val(value.split('$')[0])
        $(this).siblings('input.Name').val($(this).find('option[value="' + value + '"]').text())
        trElement.find('td.UnitPrice input').val(value.split('$')[1])
        if (value.split('$')[0] != '') {
            trElement.find('td input.Quantity').val('1')
            trElement.find('.calc').removeClass('form-control-plaintext').removeAttr('readonly', 'readonly').first().change()
        }
        else {
            trElement.find('.calc').addClass('form-control-plaintext').attr('readonly', 'readonly')
            trElement.find('.calc').val('0').first().change()
        }
    })
    $('table').on('change', '.calc', function () {
        calculate($(this), $(this).parents('tr'));
    });
})