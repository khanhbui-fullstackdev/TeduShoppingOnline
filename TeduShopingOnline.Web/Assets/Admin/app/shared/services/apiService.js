/// <reference path="/Scripts/plugins/angular/angular.min.js" />
(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http'];// for minify js

    function apiService($http) {
        return {
            get: get,
            post: post
        };
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (response) {
                success(response)
            }, function (error) {
                failure(error);
            });
        };
        function post(url, params, success, failure) {
            $http.post(url, params).then(function (response) {
                success(response);
            }, function (error) {
                failure(error);
            });
        }
    };
})(angular.module('common.module')); // api service belongs to common.module