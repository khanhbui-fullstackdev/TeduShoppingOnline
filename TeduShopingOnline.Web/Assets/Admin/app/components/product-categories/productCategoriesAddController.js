(function (app) {
    app.controller('productCategoriesAddController', productCategoriesAddController);

    productCategoriesAddController.$inject = ['$scope', , 'apiService', 'consts', 'notificationService'];

    var productCategoriesAddController = function ($scope, apiService, consts, notificationService) {
        $scope.addProductCategory = addProductCategory;

        function addProductCategory() {
            
        }
    }

})(angular.module('product-categories.module'));