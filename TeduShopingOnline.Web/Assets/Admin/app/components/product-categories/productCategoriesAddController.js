(function (app) {
    app.controller('productCategoriesAddController', productCategoriesAddController);

    productCategoriesAddController.$inject = [
        '$scope',
        'apiService',
        'consts',
        'notificationService',
        '$state'];

    function productCategoriesAddController($scope, apiService, consts, notificationService, $state) {
        //declare property
        $scope.name = '';
        $scope.alias = '';
        $scope.description = '';
        $scope.displayOrder = '';
        $scope.metaKeyword = '';
        $scope.metaDescription = '';

        $scope.statusOptions = [
            { value: true, label: 'Active' },
            { value: false, label: 'Inactive' }];

        $scope.homeFlagOptions = [
            { value: true, label: 'Yes' },
            { value: false, label: 'No' }];

        //function
        $scope.addProductCategory = addProductCategory;

        function addProductCategory() {
            var productCategory = {
                name: $scope.name,
                alias: $scope.alias,
                description: $scope.description,
                displayOrder: $scope.displayOrder,
                metaKeyword: $scope.metaKeyword,
                metaDescription: $scope.metaDescription,
                status: $scope.status.value,
                homeFlag: $scope.homeFlag.value
            };
            apiService.post(consts.webApi.productCategory.addProductCategory, productCategory,
                function (result) {
                    notificationService.success(result.data.name + ' has been added successfully');
                    $state.go('product-categories');
                },
                function (error) {
                    notificationService.error(error);
                });
        }
    }

})(angular.module('product-categories.module'));