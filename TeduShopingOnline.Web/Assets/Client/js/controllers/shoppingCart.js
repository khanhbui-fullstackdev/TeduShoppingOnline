var cart = {
    init: function () {
        cart.getAllItemsInCart();
        cart.registerEvents();
        cart.customRules();
    },
    registerEvents: function () {

        // Reference to jquery validation
        // Set up validate config
        var validateConfig = {
            rules: {
                customerName: {
                    required: true,
                    minlength: 2,
                    maxlength: 255,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                customerAddress: {
                    required: true,
                    minlength: 2,
                    maxlength: 255,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                customerEmail: {
                    required: true,
                    email: true,
                    minlength: 12,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                customerPhone: {
                    required: true,
                    number: true,
                    minlength: 10,
                    maxlength: 20,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                customerMessage: {
                    required: true,
                    minlength: 2,
                    maxlength: 500,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                customerIdentityNumber: {
                    required: true,
                    minlength: 8,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                }
            },
            messages: {
                customerName: {
                    required: 'Your name is required',
                    minlength: 'Your name requires at least 2 characters',
                    maxlength: 'Your name cannot length over 255 characters',
                    preventScriptInjection: 'Your name cannot contain any javascript code',
                    preventHtmlInjection: 'Your name cannot contain any html characters',
                    preventWhiteSpace: 'Your name cannot contain white space or empty string'
                },
                customerAddress: {
                    required: 'Your address is required',
                    minlength: 'Your address requires at least 2 characters',
                    maxlength: 'Your address cannot length over 255 characters',
                    preventScriptInjection: 'Your address cannot contain any javascript code',
                    preventHtmlInjection: 'Your address cannot contain any html characters',
                    preventWhiteSpace: 'Your address cannot contain white space or empty string'
                },
                customerEmail: {
                    required: 'Your email is required',
                    email: 'Your email is invalid',
                    minlength: 'Your email requires at least 12 characters',
                    maxlength: 'Your email cannot length over 50 characters',
                    preventScriptInjection: 'Your email cannot contain any javascript code',
                    preventHtmlInjection: 'Your email cannot contain any html characters',
                    preventWhiteSpace: 'Your email cannot contain white space or empty string'
                },
                customerPhone: {
                    required: 'Your phone is required',
                    number: 'Your phone is invalid, phone must be number only',
                    minlength: 'Your phone requires at least 10 characters',
                    maxlength: 'Your phone cannot length over 20 characters',
                    preventScriptInjection: 'Your phone cannot contain any javascript code',
                    preventHtmlInjection: 'Your phone cannot contain any html characters',
                    preventWhiteSpace: 'Your phone cannot contain white space or empty string'
                },
                customerMessage: {
                    required: 'Your message is required',
                    minlength: 'Your message requires at least 2 characters',
                    maxlength: 'Your message cannot length over 500 characters',
                    preventScriptInjection: 'Your message cannot contain any javascript code',
                    preventHtmlInjection: 'Your message cannot contain any html characters',
                    preventWhiteSpace: 'Your message cannot contain white space or empty string'
                },
                customerIdentityNumber: {
                    required: 'Your identity number is required',
                    minlength: 'Your identity number requires at least 8 characters',
                    maxlength: 'Your identity number cannot length over 50 characters',
                    preventScriptInjection: 'Your identity number cannot contain any javascript code',
                    preventHtmlInjection: 'Your identity number cannot contain any html characters',
                    preventWhiteSpace: 'Your identity number cannot contain white space or empty string'
                }
            }
        };
        $('#frmPayment').validate(validateConfig);
        // off('click') remove all the events before. Xoa tat ca su kien da dc bind luc truoc
        $('.btnAddToCart').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.addItemToCart(productId);
        });
        $('.btnRemoveItem').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            var confirmMessage = confirm("Are you sure you want to remove this item:");
            if (confirmMessage === true) {
                cart.deleteItemInCart(productId);
            }
        });
        $('#btnRemoveCart').off('click').on('click', function (e) {
            e.preventDefault();
            var confirmRemove = confirm("Are you sure to remove all items in this cart?");
            if (confirmRemove === true) {
                cart.deleteAll();
            }
        });
        $('#btnContinueShopping').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/";//redirect to home page
        });
        $('#btnPayment').off('click').on('click', function (e) {
            e.preventDefault();
            $('#payment_section').show();
        });
        $('#chkUserLoginInfo').off('click').on('click', function (e) {
            if ($(this).prop('checked'))
                cart.getUserInfo();
            else {
                $('#txtCustomerName').val('');
                $('#txtCustomerAddress').val('');
                $('#txtCustomerEmail').val('');
                $('#txtCustomerPhone').val('');
            }
        });
        $('.txtQuantity').off('keyup').on('keyup', function (e) {
            var quantity = parseInt($(this).val());
            var productId = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) === false) {
                var amount = quantity * price;
                $('#amount_' + productId).text(numeral(amount).format('0,0'));
                // After update quantity of cart in keyup event, we should update cart in server side(Session)
                cart.updateCart();
            } else {
                $('#amount_' + productId).text(0);
            }
            $('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
        });
        $('#btnBuy').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frmPayment').valid();
            if (isValid) {
                cart.createOrder().then(function (result) {
                    if (result) {
                        cart.deleteAll();
                        setTimeout(function () {
                            $('#cartContent').html('Thank you for your shopping. We will contact you as soon as possible');
                        }, 2000);
                    }
                });

                // Client email

                //cart.createOrderAndSendEmail().then(function (result) {
                //    if (result) {
                //        var order = result.newOrder;
                //        var cartItems = result.cartItems;

                //        cart.sendEmail(order, cartItems).done(function (result) {
                //            cart.deleteAll();
                //            setTimeout(function () {
                //                $('#cartContent').html('Thank you for your shopping. We will contact you as soon as possible');
                //            }, 2000);
                //        });
                //    }
                //})
            }
        });
    },
    getAllItemsInCart: function () {
        var ajaxConfig = {
            url: '/ShoppingCart/GetAllItemsInCart',
            type: 'GET',
            dataType: 'json',
            success: function (result, status, xhr) {
                if (result.status === true) {
                    var templateCartHtml = $("#template-cart").html();
                    var html = '';
                    var data = result.data;
                    $.each(data, function (index, item) {
                        html += Mustache.render(templateCartHtml, {
                            ProductId: item.ProductId,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            Price: item.Product.Price,
                            PriceFormat: numeral(item.Product.Price).format('0,0'),
                            Quantity: item.Quantity,
                            Amount: numeral(item.Quantity * item.Product.Price).format('0,0')
                        });
                    });
                    $('#tbody_cart').html(html);
                    if (html === '') {
                        $('#tb_cart').hide();
                        $('.pull-right').hide();
                        $('#btnRemoveCart').attr('disabled', true);
                        $('#btnPayment').attr('disabled', true);
                        $('#cartContent').html('There are not any products in cart!.');
                    }
                    $('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
                    cart.registerEvents();//after loading data, we should bind this event again!
                } else {
                    $('#tb_cart').hide();
                    $('.pull-right').hide();
                    $('#btnRemoveCart').attr('disabled', true);
                    $('#btnPayment').attr('disabled', true);
                    $('#cartContent').html('There is not any products in cart!.');
                }
            },
            error: function (xhr, status, error) {
                console.log('Error:' + error);
            }
        };
        $.ajax(ajaxConfig);
    },
    addItemToCart: function (productId) {
        var ajaxConfig = {
            url: '/ShoppingCart/Add',
            // data is parameter of the function in server side
            data: {
                productId: productId
            },
            type: 'POST', // using type post because you're sending data to server side
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    alert('Add new item into cart successfully!');
                }
            }
        };
        $.ajax(ajaxConfig);
    },
    deleteItemInCart: function (productId) {
        var ajaxConfig = {
            url: '/ShoppingCart/DeleteItem',
            // data is parameter of the function in server side
            data: {
                productId: productId
            },
            type: 'POST', // using type post because you're sending data to server side
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.getAllItemsInCart();
                }
            }
        };
        $.ajax(ajaxConfig);
    },
    deleteAll: function () {
        var ajaxConfig = {
            url: '/ShoppingCart/DeleteAll',
            type: 'POST', // using type post because you're sending data to server side
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.getAllItemsInCart();
                }
            }
        };
        $.ajax(ajaxConfig);
    },
    updateCart: function (cartData) {
        var cartItems = [];
        $.each($('.txtQuantity'), function (index, item) {
            cartItems.push({
                ProductId: $(item).data('id'), //this preresents element txtQuantity
                Quantity: $(item).val()
            });
        });

        var ajaxConfig = {
            url: '/ShoppingCart/UpdateCart',
            type: 'POST', // using type post because you're sending data to server side
            data: {
                cartData: JSON.stringify(cartItems)
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.getAllItemsInCart();
                }
            }
        };
        $.ajax(ajaxConfig);
    },
    getTotalOrder: function () {
        var listTextBox = $('.txtQuantity');
        var total = 0;
        $.each(listTextBox, function (index, item) {
            var quantity = $(item).val();
            var price = $(item).data('price');
            if (quantity && price) {
                total += parseInt(quantity) * parseFloat(price);// clear, understand
            }
        });
        return total;
    },
    getUserInfo: function () {
        var ajaxConfig = {
            url: '/ShoppingCart/GetUserInfo',
            type: 'POST', // using type post because you're sending data to server side
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var user = response.data;
                    $('#txtCustomerId').val(user.Id);
                    $('#txtCustomerName').val(user.FullName);
                    $('#txtCustomerAddress').val(user.Address);
                    $('#txtCustomerEmail').val(user.Email);
                    $('#txtCustomerPhone').val(user.PhoneNumber);
                }
            },
            error: function (xhr, status, error) {
                console.log('Error:' + error);
            }
        };
        $.ajax(ajaxConfig);
    },
    createOrder: function () {
        var dfd = $.Deferred();

        var customerIdentityNumber = $('#txtIdentityNumber').val();
        var customerId = $('#txtCustomerId').val();
        var customerName = $('#txtCustomerName').val();
        var customerAddress = $('#txtCustomerAddress').val();
        var customerEmail = $('#txtCustomerEmail').val();
        var customerMobile = $('#txtCustomerPhone').val();
        var customerMessage = $('#txtCustomerMessage').val();

        var order = {
            CustomerIdentityNumber: customerIdentityNumber,
            CustomerId: customerId,
            CustomerName: customerName,
            CustomerAddress: customerAddress,
            CustomerEmail: customerEmail,
            CustomerMobile: customerMobile,
            CustomerMessage: customerMessage,
            PaymentMethod: 'Cash only',//should be changed to drop down list
            Status: false,
        };
        var ajaxConfig = {
            url: '/ShoppingCart/CreateOrder',
            type: 'POST', // using type post because you're sending data to server side
            dataType: 'json',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            success: function (response) {
                if (response.status && response.mailStatus) {
                    // clear shopping cart session (means delete all) and hide payment_section div
                    $('#payment_section').hide();
                    dfd.resolve(response.status);
                } else {
                    console.log(response.error);
                }
            },
            error: function (xhr, status, error) {
                console.log('Error:' + error);
            }
        };
        $.ajax(ajaxConfig);
        return dfd.promise();
    },
    createOrderAndSendEmail: function () {
        var dfd = $.Deferred();

        var customerIdentityNumber = $('#txtIdentityNumber').val();
        var customerId = $('#txtCustomerId').val();
        var customerName = $('#txtCustomerName').val();
        var customerAddress = $('#txtCustomerAddress').val();
        var customerEmail = $('#txtCustomerEmail').val();
        var customerMobile = $('#txtCustomerPhone').val();
        var customerMessage = $('#txtCustomerMessage').val();

        var order = {
            CustomerIdentityNumber: customerIdentityNumber,
            CustomerId: customerId,
            CustomerName: customerName,
            CustomerAddress: customerAddress,
            CustomerEmail: customerEmail,
            CustomerMobile: customerMobile,
            CustomerMessage: customerMessage,
            PaymentMethod: 'Cash only',//should be changed to drop down list
            Status: false,
        };
        var ajaxConfig = {
            url: '/ShoppingCart/CreateOrderAndSendEmail',
            type: 'POST', // using type post because you're sending data to server side
            dataType: 'json',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            success: function (response) {
                if (response.status) {
                    // clear shopping cart session (means delete all) and hide payment_section div
                    $('#payment_section').hide();
                    var data = {
                        newOrder : response.orderInfo,
                        cartItems: response.cartItems
                    };
                    dfd.resolve(data);
                } else {
                    console.log(response.error);
                }
            },
            error: function (xhr, status, error) {
                console.log('Error:' + error);
            }
        };
        $.ajax(ajaxConfig);
        return dfd.promise();
    },
    sendEmail: function (order, cartItems) {
        var dfd = $.Deferred();
        var customerInfoTemplate = $("#customer-info-template").html();

        var theadOrderDetailTemplate = $('#thead-order-detail-template').html();
        var trowOrderDetailTemplate = $("#trow-order-detail-template").html();
        var trowOrderDetailTotalTemplate = $("#trow-order-detail-total-template").html();

        var customerInfoHtml = '';
        var trowOrderDetailHtml = '';

        var customerInforView = {
            FullName: order.CustomerName,
            UserName: order.CreatedBy,
            IdentityNumber: order.CustomerIdentityNumber,
            PhoneNume: order.CustomerMobile,
            Email: order.CustomerEmail,
            Address: order.CustomerAddress
        };
        customerInfoHtml += Mustache.render(customerInfoTemplate, customerInforView);

        $.each(cartItems, function (index, item) {
            trowOrderDetailHtml += (Mustache.render(trowOrderDetailTemplate, {
                OrderId: order.ID,
                ProductId: item.ProductId,
                ProductName: item.Product.Name,
                Quantity: item.Quantity,
                Price: numeral(item.Product.Price).format('0,0'),
                Total: numeral(item.Product.Price * item.Product.Quantity).format('0,0')
            }));
        });

        var tableOrderDetailHtml = customerInfoHtml.trim() + "<table border='1' style='border - collapse:collapse'>"
            + theadOrderDetailTemplate.trim()
            + "<tbody>" + trowOrderDetailHtml.trim() + "</tbody>" + "</table>";

        var tableOrderDetailHtml1 = customerInfoHtml;        
        var emailContentHtml = tableOrderDetailHtml;
        var jsonData = JSON.stringify({ 'emailContentViewModel': emailContentHtml });

        var ajaxConfig = {
            url: '/ShoppingCart/SendEmail',
            type: 'POST',
            dataType: 'JSON',
            contentType: 'text/html',
            data: { emailContentViewModel: emailContentHtml.toString() },
            success: function (result, status, xhr) {
                if (result.status === true) {
                    dfd.resolve(result.status);
                    alert('Your order detail has been sent to your email, please check');
                }
            },
            error: function (error) {
                console.log('Error:' + error);
            }
        };
        $.ajax(ajaxConfig);
        return dfd.promise();
    },
    customRules: function () {
        jQuery.validator.addMethod('preventScriptInjection', function (value, element, params) {
            if (value.toLowerCase().search('<script>') !== -1 || value.toLowerCase().search('</script>') !== -1)
                return false; // has script
            return true; // none script
        }, '');
        jQuery.validator.addMethod('preventHtmlInjection', function (value, element, params) {
            var htmlPattern = new RegExp(/<[a-z][\s\S]*>/i);
            if (htmlPattern.test(value))
                return false; // has html
            return true; // none html
        }, '');
        jQuery.validator.addMethod('preventWhiteSpace', function (value, element, params) {
            if (value.trim() === '')
                return false; // has empty string
            return true; // none empty string
        }, '');
    }
};
cart.init();
