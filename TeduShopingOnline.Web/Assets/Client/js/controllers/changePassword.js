var changePassword = {
    init: function () {
        changePassword.registerEvents();
        changePassword.customRules();
    },
    registerEvents: function () {
        // Form change password
        var frm_validateUpdatePasswordConfig = {
            rules: {
                temporaryPassword: {
                    required: true,
                    minlength: 10,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                newPassword: {
                    required: true,
                    minlength: 10,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                repeatPassword: {
                    required: true,
                    minlength: 10,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true,
                    comparePassword: true
                }
            },
            messages: {
                temporaryPassword: {
                    required: 'Your temporary password is required',
                    minlength: 'Your temporary password requires at least 10 characters',
                    maxlength: 'Your temporary password cannot length over 50 characters',
                    preventScriptInjection: 'Your temporary password cannot contain any javascript code',
                    preventHtmlInjection: 'Your temporary password cannot contain any html characters',
                    preventWhiteSpace: 'Your temporary password cannot contain white space or empty string'
                },
                newPassword: {
                    required: 'Your new password is required',
                    minlength: 'Your new password requires at least 10 characters',
                    maxlength: 'Your new password cannot length over 50 characters',
                    preventScriptInjection: 'Your new password cannot contain any javascript code',
                    preventHtmlInjection: 'Your new password cannot contain any html characters',
                    preventWhiteSpace: 'Your new password cannot contain white space or empty string'
                },
                repeatPassword: {
                    required: 'Your password is required',
                    minlength: 'Your repeat password requires at least 10 characters',
                    maxlength: 'Your repeat passwordr cannot length over 50 characters',
                    preventScriptInjection: 'Your repeat password cannot contain any javascript code',
                    preventHtmlInjection: 'Your repeat password cannot contain any html characters',
                    preventWhiteSpace: 'Your repeat cannot contain white space or empty string',
                    comparePassword: 'Your password must match with repeated password'
                }
            }
        };
        $('#frm_updatePassword').validate(frm_validateUpdatePasswordConfig);

        $('#btnChangePassword').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frm_updatePassword').valid();
            if (isValid) {
                var temporaryPassword = $('#txtTemporaryPassword').val();
                var newPassword = $('#txtNewPassword').val();
                var repeatPassword = $('#txtRepeatPassword').val();
                var currentUrl = window.location.href;
                var userName = currentUrl.split('/')[6];
               
                var password = {
                    UserName: userName,
                    OldPassword: temporaryPassword,
                    NewPassword: newPassword,
                    RepeatNewPassword: repeatPassword
                };
                changePassword.changePassword(password);
            }
        });
    },
    changePassword: function (password) {
        var ajaxConfig = {
            url: '/Account/ChangePassword',
            type: 'POST',
            dataType: 'json', // dataType is what you're expecting back from server
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',//  is the type of data you're sending
            data: {
                passwordInfo: JSON.stringify(password)
            },
            success: function (result, status, xhr) {
                if (result.status) {
                    bootbox.alert('Your password has been updated successfully !');
                    $('#txtTemporaryPassword').val('');
                    $('#txtNewPassword').val('');
                    $('#txtRepeatPassword').val('');
                    setTimeout(function () {
                        window.location.href = '/account/login';
                    }, 3000);
                } else {
                    bootbox.alert(result.error);
                }
            }, error: function (xhr, status, error) {
                bootbox.alert(error);
            }
        };
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
            var repeatNewPassword = $('#txtRepeatPassword').val();
            if (newPassword && repeatNewPassword) {
                if (newPassword !== repeatNewPassword)
                    return false;
                return true;
            } else return true;
        }, '');
    }
}
changePassword.init();