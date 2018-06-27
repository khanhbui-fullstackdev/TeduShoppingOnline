/// <reference path="../../../../../scripts/plugins/angular/angular.min.js" />

(function (app) {
    var statusFilter = app.filter('statusFilter', function () {
        return function (input) {
            if (input == true)
                return 'Active';
            return 'Inactive';
        }
    });
}(angular.module('common.module')));