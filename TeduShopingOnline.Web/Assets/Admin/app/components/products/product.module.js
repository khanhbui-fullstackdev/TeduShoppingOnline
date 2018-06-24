(function () {
    angular.module('product.module', ['teduShoppingOnline.module.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        var productsUrlConfig = {
            url: '/products',
            templateUrl: '/app/components/product/productsView.html',
            controller: 'productsController'
        };

        var productCreateUrlConfig = {
            url: '/product/create',
            templateUrl: '/app/components/products/productCreateView.html',
            controller: 'productCreateController'
        };

        var productUpdateUrlConfig = {
            url: '/product/update',
            templateUrl: '/app/components/product/productUpdateView.html',
            controller: 'productUpdateController'
        };

        $stateProvider
            .state('products', productsUrlConfig)
            .state('product-create', productCreateUrlConfig)
            .state('product-update', productUpdateUrlConfig);
    }
})();