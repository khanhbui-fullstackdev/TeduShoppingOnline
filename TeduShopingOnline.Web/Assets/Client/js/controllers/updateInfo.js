var updateInfor = {
    init: function () {
        updateInfor.registerEvents();
        updateInfor.getAccountInfo();
        updateInfor.customRules();
    },
    registerEvents: function () {
        // Step up validate config
        var frm_validateUpdateAccountInfoConfig = {
            rules: {
                firstName: {
                    required: true,
                    minlength: 2,
                    maxlength: 255,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                lastName: {
                    required: true,
                    minlength: 2,
                    maxlength: 255,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                identityNumber: {
                    required: true,
                    minlength: 8,
                    maxlength: 50,
                    number: true,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                address: {
                    required: true,
                    minlength: 2,
                    maxlength: 255,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                email: {
                    required: true,
                    email: true,
                    minlength: 12,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                phoneNumber: {
                    required: true,
                    number: true,
                    minlength: 10,
                    maxlength: 20,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                birthday: {
                    required: true
                }
            },
            messages: {
                firstName: {
                    required: 'Your first name is required',
                    minlength: 'Your first name requires at least 2 characters',
                    maxlength: 'Your first name cannot length over 255 characters',
                    preventScriptInjection: 'Your first name cannot contain any javascript code',
                    preventHtmlInjection: 'Your first name cannot contain any html characters',
                    preventWhiteSpace: 'Your first name cannot contain white space or empty string'
                },
                lastName: {
                    required: 'Your last name is required',
                    minlength: 'Your last name requires at least 2 characters',
                    maxlength: 'Your last name cannot length over 255 characters',
                    preventScriptInjection: 'Your last name cannot contain any javascript code',
                    preventHtmlInjection: 'Your last name cannot contain any html characters',
                    preventWhiteSpace: 'Your last name cannot contain white space or empty string'
                },
                identityNumber: {
                    required: 'Your identity number is required',
                    minlength: 'Your identity number requires at least 8 characters',
                    maxlength: 'Your identity number cannot length over 50 characters',
                    preventScriptInjection: 'Your identity number cannot contain any javascript code',
                    preventHtmlInjection: 'Your identity number cannot contain any html characters',
                    preventWhiteSpace: 'Your identity number cannot contain white space or empty string'
                },
                address: {
                    required: 'Your address is required',
                    minlength: 'Your address requires at least 2 characters',
                    maxlength: 'Your address cannot length over 255 characters',
                    preventScriptInjection: 'Your address cannot contain any javascript code',
                    preventHtmlInjection: 'Your address cannot contain any html characters',
                    preventWhiteSpace: 'Your address cannot contain white space or empty string'
                },
                email: {
                    required: 'Your email is required',
                    email: 'Your email is invalid',
                    minlength: 'Your email requires at least 12 characters',
                    maxlength: 'Your email cannot length over 50 characters',
                    preventScriptInjection: 'Your email cannot contain any javascript code',
                    preventHtmlInjection: 'Your email cannot contain any html characters',
                    preventWhiteSpace: 'Your email cannot contain white space or empty string'
                },
                phoneNumber: {
                    required: 'Your phone is required',
                    number: 'Your phone is invalid, phone must be number only',
                    minlength: 'Your phone requires at least 10 characters',
                    maxlength: 'Your phone cannot length over 20 characters',
                    preventScriptInjection: 'Your phone cannot contain any javascript code',
                    preventHtmlInjection: 'Your phone cannot contain any html characters',
                    preventWhiteSpace: 'Your phone cannot contain white space or empty string'
                },
                birthday: {
                    required: 'Your birthday is required'
                }
            }
        };
        $('#frm_updateAccountInfo').validate(frm_validateUpdateAccountInfoConfig);

        // Form change password
        var frm_validateChangePasswordConfig = {
            rules: {
                oldPassword: {
                    required: true,
                    minlength: 10,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true
                },
                newPassword: {
                    required: true,
                    minlength: 10,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true
                },
                repeatNewPassword: {
                    required: true,
                    minlength: 10,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    comparePassword: true
                }
            },
            messages: {
                oldPassword: {
                    required: 'Your password is required',
                    minlength: 'Your password requires at least 10 characters',
                    maxlength: 'Your password cannot length over 50 characters',
                    preventScriptInjection: 'Your password cannot contain any javascript code',
                    preventHtmlInjection: 'Your password cannot contain any html characters'
                },
                newPassword: {
                    required: 'Your password is required',
                    minlength: 'Your password requires at least 10 characters',
                    maxlength: 'Your password cannot length over 50 characters',
                    preventScriptInjection: 'Your password cannot contain any javascript code',
                    preventHtmlInjection: 'Your password cannot contain any html characters',

                },
                repeatNewPassword: {
                    required: 'Your password is required',
                    minlength: 'Your repeat password requires at least 10 characters',
                    maxlength: 'Your repeat passwordr cannot length over 50 characters',
                    preventScriptInjection: 'Your repeat password cannot contain any javascript code',
                    preventHtmlInjection: 'Your repeat password cannot contain any html characters',
                    comparePassword: 'Your password must match with repeated password'
                }
            }
        };
        $('#frm_changePassword').validate(frm_validateChangePasswordConfig);

        $('#btnUpdateInfo').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frm_updateAccountInfo').valid();
            if (isValid) {
                var firstName = $("#txtFirstName").val();
                var lastName = $("#txtLastName").val();
                var fullName = firstName + " " + lastName;
                var birthday = $("#birthday-datepicker").datepicker("getDate");
                var identityNumber = $('#txtIdentityNumber').val();
                var userName = $('#txtUserName').val();
                var email = $('#txtEmail').val();
                var address = $("#txtAddress").val();
                var phoneNumber = $("#txtPhoneNumber").val();

                var accountInfo = {
                    FullName: fullName,
                    Birthday: birthday,
                    IdentityNumber: identityNumber,
                    UserName: userName,
                    Email: email,
                    Address: address,
                    PhoneNumber: phoneNumber,
                };
                updateInfor.updateAccountInfo(accountInfo);
            }
        });
        $('#birthday-datepicker').datepicker({
            dateFormat: "dd/M/yy",
            changeMonth: true,
            changeYear: true,
            defaultDate: null,
            yearRange: "-60:+0",
            onSelect: function (dateText, inst) {
                $("#birthday-datepicker").datepicker("setDate", new Date(inst.selectedYear, inst.selectedMonth, parseInt(inst.selectedDay)));
            }
        });
        var today = new Date();
        var currentDate = $("#birthday-datepicker").datepicker("getDate");
        if (!currentDate) {
            $("#birthday-datepicker").datepicker("setDate", today);
        };

        $('#btnOpenModal').off('click').on('click', function (e) {
            e.preventDefault();
            $('#modalChangePassword').modal();
        });
        $('#btnChangePassword').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frm_changePassword').valid();
            if (isValid) {
                var oldPassword = $('#txtOldPassword').val();
                var newPassword = $('#txtNewPassword').val();
                var repeatPassword = $('#txtRepeatNewPassword').val();

                var password = {
                    OldPassword: oldPassword,
                    NewPassword: newPassword,
                    RepeatNewPassword: repeatPassword
                };
                updateInfor.changePassword(password);
            }
        });
    },
    getAccountInfo: function () {
        var ajaxConfig = {
            url: '/Account/GetAccountInfo',
            type: 'GET',
            dataType: 'json',
            success: function (result, status, xhr) {
                if (result.status) {
                    var fullName = result.data.FullName;
                    var address = result.data.Address;
                    var birthdayTemp = result.data.Birthday;
                    var identityNumber = result.data.IdentityNumber;
                    var email = result.data.Email;
                    var phoneNumber = result.data.PhoneNumber;
                    var userName = result.data.UserName;

                    if (fullName) {
                        var firstName = fullName.split(" ")[0].concat(" " + fullName.split(" ")[1]);
                        var lastName = fullName.split(" ")[2];
                        $("#txtFirstName").val(firstName);
                        $("#txtLastName").val(lastName);
                    }
                    if (birthdayTemp) {
                        var startIndex = birthdayTemp.indexOf('(');
                        var endIndex = birthdayTemp.indexOf(')');
                        var birthday = parseInt(birthdayTemp.substring(startIndex + 1, endIndex));
                        $("#birthday-datepicker").datepicker("setDate", new Date(birthday));
                    }

                    $("#txtIdentityNumber").val(identityNumber);
                    $("#txtEmail").val(email).attr('disabled', true);
                    $("#txtAddress").val(address);
                    $("#txtPhoneNumber").val(phoneNumber);
                    $("#txtUserName").val(userName).attr('disabled', true);
                }
            },
            error: function (xhr, status, error) {
                console.log('Error:' + error);
            }
        }
        $.ajax(ajaxConfig);
    },
    updateAccountInfo: function (accountInfo) {
        var ajaxConfig = {
            url: '/Account/UpdateAccountInfo',
            type: 'POST',
            dataType: 'json',
            data: {
                accountInfoData: JSON.stringify(accountInfo)
            },
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            success: function (result, status, xhr) {
                if (result.status) {
                    alert('update account info success');
                }
                else {
                    console.log(result.error);
                }
            },
            error: function (xhr, status, error) {
                console.log(error);
            }
        };
        $.ajax(ajaxConfig);
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
                    alert('Your password has been updated successfully !');
                } else {
                    alert(result.error);
                }
            }, error: function (xhr, status, error) {
                console.log(error);
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
            var repeatNewPassword = $('#txtRepeatNewPassword').val();
            if (newPassword && repeatNewPassword) {
                if (newPassword !== repeatNewPassword)
                    return false;
                return true;
            } else return true;
        }, '');
    }
};
updateInfor.init();