(function () {
    var productCategoriesModule = angular.module('product-categories.module', [
        'common.module']);
    productCategoriesModule.config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider', 'consts'];

    function config($stateProvider, $urlRouterProvider, consts) {
        var productCategoriesViewConfig = {
            url: '/product-categories/',
            templateUrl: consts.components.productCategories + 'productCategoriesView.html',
            controller: 'productCategoriesController'
        };

        var productCategoriesAddConfig = {
            url: '/product-categories/add',
            templateUrl: consts.components.productCategories + 'productCategoriesAddController.html',
            controller: 'productCategoriesAddController'
        };

        $stateProvider
            .state('product-categories', productCategoriesViewConfig)
            .state('product-categories-add', productCategoriesAddConfig);
    }
})();