/// <reference path="/Scripts/plugins/angular/angular.min.js" />
(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];// for minify js

    function apiService($http, notificationService) {
        return {
            get: get,
            post: post,
            put: put
        };

        function get(url, params, success, failure) {
            $http.get(url, params).then(function (response) {
                success(response)
            }, function (error) {
                failure(error);
            });
        };

        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.error('Authenticate is required.');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        };

        function put(url, data, success, failure) {            
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                    notificationService.error('Authenticate is required.');
                }
                else if (failure != null) {
                    failure(error);
                }
            });
        }
    };
})(angular.module('common.module')); // api service belongs to common.module