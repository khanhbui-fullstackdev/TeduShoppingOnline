/// <reference path="/Scripts/plugins/angular/angular.min.js" />
// anonymos method
(function () {
    angular.module('teduShoppingOnline.module', [
        'tedushopingOnline.module.common',
        'product.module'

    ]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        var homeUrlConfig = {
            url: '/admin',
            templateUrl: '/app/components/home/homeView.html',
            controller: 'homeController'
        }
        $stateProvider.state('home', homeUrlConfig);
        $urlRouterProvider.otherwise('/admin');
    }
})();