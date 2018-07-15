(function (app) {
    'use strict';

    app.controller('productCategoryUpdateController', productCategoryUpdateController);
    productCategoryUpdateController.$inject = [
        '$scope',
        'apiService',
        'consts',
        'notificationService',
        '$stateParams']; // $stateParams get id from url

    function productCategoryUpdateController($scope, apiService, consts, notificationService, $stateParams) {
        // declare property
        // declare product category = empty object
        $scope.productCategory = {};

        //function
        $scope.updateProductCategory = updateProductCategory;

        function getProductCategoryById() {            
            apiService.get(consts.webApi.productCategory.getProductCategoryById + '/' + $stateParams.id, null,
                function (result) {
                    $scope.productCategory = result.data;
                }, function (error) {
                    notificationService.error(error);
                });
        };

        function updateProductCategory() {
            var productCategoryUpdate = $scope.productCategory;
            apiService.put(consts.webApi.productCategory.updateProductCategory, productCategoryUpdate,
                function (result) {
                    notificationService.success(result.data.name + ' has been updated successfully');
                    $state.go('product-category');
                },
                function (error) {
                    notificationService.error(error);
                });
        };
        getProductCategoryById();
    }

})(angular.module('product-category.module'));