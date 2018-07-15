(function () {
    angular.module('product.module', [
        'common.module']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', 'consts'];

    function config($stateProvider, $urlRouterProvider, consts) {
        var productsUrlConfig = {
            url: '/products',
            templateUrl: consts.components.products + 'productsView.html',
            controller: 'productsController'
        };

        var productCreateUrlConfig = {
            url: '/product/create',
            templateUrl: consts.components.products + 'productCreateView.html',
            controller: 'productCreateController'
        };

        var productUpdateUrlConfig = {
            url: '/product/update',
            templateUrl: consts.components.products + 'productUpdateView.html',
            controller: 'productUpdateController'
        };

        $stateProvider
            .state('products', productsUrlConfig)
            .state('product-create', productCreateUrlConfig)
            .state('product-update', productUpdateUrlConfig);
    }
})();