var forgotPassword = {
    init: function () {
        forgotPassword.registerEvents();
        forgotPassword.customRules();
    },
    registerEvents: function () {        
        $('#successMessage').hide();

        // Form forgot password
        var frm_validateForgotPasswordConfig = {
            rules: {
                email: {
                    required: true,
                    email: true,
                    minlength: 12,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                userName: {
                    required: true,
                    minlength: 6,
                    maxlength: 30,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                }
            },
            messages: {
                email: {
                    required: 'Your password is required',
                    minlength: 'Your password requires at least 12 characters',
                    maxlength: 'Your password cannot length over 50 characters',
                    preventScriptInjection: 'Your password cannot contain any javascript code',
                    preventHtmlInjection: 'Your password cannot contain any html characters',
                    preventWhiteSpace: 'Your password cannot contain any white space or empty string'
                },
                userName: {
                    required: 'Your user name is required',
                    minlength: 'Your user name requires at least 6 characters',
                    maxlength: 'Your user name cannot length over 30 characters',
                    preventScriptInjection: 'Your user name cannot contain any javascript code',
                    preventHtmlInjection: 'Your user name cannot contain any html characters',
                    preventWhiteSpace: 'Your user name cannot contain any white space or empty string'
                }
            }
        };
        $('#frm_forgotPassword').validate(frm_validateForgotPasswordConfig);

        $('#btnResetPassword').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frm_forgotPassword').valid();
            if (isValid) {
                var email = $('#txtEmail').val();
                var userName = $('#txtUserName').val();
                var accountData = {
                    email: email,
                    userName: userName
                };
                forgotPassword.generatePassword(accountData);
            }
        });
    },
    generatePassword: function (accountData) {
        var ajaxConfig = {
            url: '/Account/GeneratePassword',
            type: 'POST',
            dataType: 'json', // dataType is what you're expecting back from server
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',//  is the type of data you're sending
            //contentType: 'application/json',
            data: {
                accountInfo: JSON.stringify(accountData)
            },
            success: function (result, status, xhr) {
                if (result.status) {
                    $('#txtEmail').val('');
                    $('#txtUserName').val('');
                    $('#successMessage').show();

                    var changePasswordUrl = "/account/change-password/user-name/" + result.userName;
                    $('#btnHref').attr('href', changePasswordUrl);
                    $('#forgotPassword').hide();                    
                } else {
                    bootbox.alert(result.error);
                }
            },
            error: function (xhr, status, error) {
                bootbox.alert(error);
            }
        }
        $.ajax(ajaxConfig);
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
        jQuery.validator.addMethod('comparePassword', function (value, element, params) {
            var newPassword = $('#txtNewPassword').val();
            var repeatNewPassword = $('#txtRepeatNewPassword').val();
            if (newPassword && repeatNewPassword) {
                if (newPassword !== repeatNewPassword)
                    return false;
                return true;
            } else return true;
        }, '');
    }
};

forgotPassword.init();