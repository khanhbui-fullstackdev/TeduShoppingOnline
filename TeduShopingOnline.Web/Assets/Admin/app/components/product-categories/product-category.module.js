(function () {
    'use strict';

    var productCategoryModule = angular.module('product-category.module', [
        'common.module']);
    productCategoryModule.config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider', 'consts'];

    function config($stateProvider, $urlRouterProvider, consts) {
        var productCategoriesViewConfig = {
            url: '/product-categories/',
            templateUrl: consts.components.productCategories + 'productCategoriesController.html',
            controller: 'productCategoriesController'
        };

        var productCategoryAddConfig = {
            url: '/product-category/add',
            templateUrl: consts.components.productCategories + 'productCategoryAddController.html',
            controller: 'productCategoryAddController'
        };

        var productCategoryUpdateConfig = {
            url: '/product-category/update/:id',
            templateUrl: consts.components.productCategories + 'productCategoryUpdateController.html',
            controller: 'productCategoryUpdateController'
        };

        $stateProvider
            .state('product-categories', productCategoriesViewConfig)
            .state('product-category-add', productCategoryAddConfig)
            .state('product-category-update', productCategoryUpdateConfig)
    }
})();