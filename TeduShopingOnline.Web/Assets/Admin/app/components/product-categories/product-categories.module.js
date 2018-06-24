(function () {
    var productCategoriesModule = angular.module('product-categories.module', [
        'common.module',
        'consts.module']);
    productCategoriesModule.config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider', 'consts'];

    function config($stateProvider, $urlRouterProvider, consts) {
        var productCategoriesUrlConfig = {
            url: '/product-categories/',
            templateUrl: consts.components.productCategories + 'productCategoriesView.html',
            controller: 'productCategoriesController'
        };

        $stateProvider
            .state('product-categories', productCategoriesUrlConfig);
    }
})();