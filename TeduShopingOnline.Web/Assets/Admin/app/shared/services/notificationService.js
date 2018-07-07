(function (app) {
    app.service('notificationService', notificationService);

    function notificationService() {
        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onclick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut": 1000
        };

        function success(message) {
            toastr.success(message, 'Success');            
        }

        function error(error) {
            if (Array.isArray(error)) {
                error.each(function (err) {
                    toastr.error(err);
                });
            }
            else {
                toastr.error(error, 'Error');
            }
        }

        function warning(message) {
            toastr.warning(message, 'Warning');
        }

        function info(message) {
            toastr.info(message, 'Info');
        }

        return {
            success: success,
            error: error,
            warning: warning,
            info: info
        }
    }

})(angular.module('common.module'));