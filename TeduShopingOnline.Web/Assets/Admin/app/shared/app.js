/// <reference path="/Scripts/plugins/angular/angular.min.js" />
// anonymos method
(function () {
    angular.module('teduShoppingOnline.module', [
        'common.module',
        'product.module',
        'product-category.module'
    ]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', 'consts'];

    function config($stateProvider, $urlRouterProvider, consts) {

        var homeUrlConfig = {
            url: '/admin',
            templateUrl: consts.components.home + 'homeView.html',
            controller: 'homeController'
        }
        $stateProvider.state('home', homeUrlConfig);
        $urlRouterProvider.otherwise('');
    }
})();