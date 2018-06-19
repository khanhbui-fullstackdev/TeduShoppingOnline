var register = {
    init: function () {
        register.registerEvents();       
    },
    registerEvents: function () {
        // Step up validate config
        var validateConfig = {
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
                userName: {
                    required: true,
                    number: true,
                    minlength: 6,
                    maxlength: 30,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true
                },
                password: {
                    required: true,
                    minlength: 10,
                    maxlength: 50,
                    preventScriptInjection: true,
                    preventHtmlInjection: true,
                    preventWhiteSpace: true,
                    repeatPassword: {
                        equalTo: '#txtPassword'
                    }
                },
                repeatPassword: {
                    required: true,
                    minlength: 10,
                    maxlength: 50,
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
                userName: {
                    required: 'Your username is required',
                    number: 'Your username is invalid, phone must be number only',
                    minlength: 'Your username requires at least 6 characters',
                    maxlength: 'Your username cannot length over 30 characters',
                    preventScriptInjection: 'Your username cannot contain any javascript code',
                    preventHtmlInjection: 'Your username cannot contain any html characters',
                    preventWhiteSpace: 'Your username cannot contain white space or empty string'
                },
                password: {
                    required: 'Your password is required',
                    minlength: 'Your password requires at least 10 characters',
                    maxlength: 'Your password cannot length over 50 characters',
                    preventScriptInjection: 'Your password cannot contain any javascript code',
                    preventHtmlInjection: 'Your password cannot contain any html characters',
                    preventWhiteSpace: 'Your password cannot contain white space or empty string',
                    repeatPassword: 'Your password must match with repeated password'
                },
                repeatPassword: {
                    required: 'Your repeat password is required',
                    minlength: 'Your repeat password requires at least 10 characters',
                    maxlength: 'Your repeat passwordr cannot length over 50 characters',
                    preventScriptInjection: 'Your repeat password cannot contain any javascript code',
                    preventHtmlInjection: 'Your repeat password cannot contain any html characters',
                    preventWhiteSpace: 'Your repeat password cannot contain white space or empty string'
                },
                birthday: {
                    required: 'Your birthday is required'
                }
            }
        };
        
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

        $('#btnRegister').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frm_registerAccount').valid();
            if (isValid)
                $('#frm_registerAccount').submit();
        });
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
register.init();