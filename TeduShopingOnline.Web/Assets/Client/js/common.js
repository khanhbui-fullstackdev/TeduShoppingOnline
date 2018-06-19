var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {
        $('#txtKeyword').autocomplete({
            minLength: 3,
            source: function (request, response) {
                $.ajax({
                    type: "GET",
                    url: "/Product/GetProductsByName",
                    dataType: "json",
                    data: {
                        keyword: request.term
                    },
                    success: function (result, status, xhr) {
                        response(result);
                    },
                    error: function (xhr, status, error) {
                        console.log(error.message);
                    }
                })
            },
            focus: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyword").val(ui.item.label);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<a>" + item.label + "</a><br/>")
                .appendTo(ul);
        };
        $(".btnAddToCart").off('click').on('click', function (e) {
            // The event.preventDefault() method stops the default action of an element from happening.
            // Prevent a submit button from submitting a form
            // Prevent a link from following the URL
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            $.ajax({
                url: "/ShoppingCart/Add",
                data: {
                    productId: productId
                },
                type: "POST",
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        alert("Add item success!");
                    }
                }
            });
        });
        $('#btnLogout').off('click').on('click', function (e) {
            e.preventDefault();
            $('#frm_Logout').submit();
        });
    }
}
common.init();