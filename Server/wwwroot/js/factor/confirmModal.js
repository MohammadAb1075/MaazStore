$(function () {
    $('table').on('click', 'button.deleteItem', function () {
        $('.modal#confirmModal').modal('show')
        var href = $('.modal#confirmModal').find('a#deleteBtn').attr('href')
        $('.modal#confirmModal').find('a#deleteBtn').attr('href', href + '/' + $(this).attr('linkAction'))
    })
    $('.modal#confirmModal').find('a#deleteBtn').click(function () {
        $('.modal#confirmModal').modal('hide')
    })
})