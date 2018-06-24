(function (app) {
    app.controller('productCategoriesController', productCategoriesController)

    productCategoriesController.$inject = ['$scope', 'apiService', 'consts'];

    function productCategoriesController($scope, apiService, consts) {
        $scope.productCategories = [];

        $scope.getProductCategories = getProductCategories;

        function getProductCategories() {
            apiService.get(consts.webApi.productCategory.getAllProductCategory, null, function (result) {
                $scope.productCategories = result.data;
            }, function (error) {
                console.log('Error:' + error.message);
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('product-categories.module')); // register namespace (register module)