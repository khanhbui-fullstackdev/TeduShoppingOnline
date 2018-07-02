(function (app) {
    app.controller('productCategoriesController', productCategoriesController)

    productCategoriesController.$inject = ['$scope', 'apiService', 'consts'];

    function productCategoriesController($scope, apiService, consts) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.keyword = '';
        $scope.search = search;

        function search() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,// by default page = 0
                    pageSize: 5//display 2 items only on one page
                }
            };

            apiService.get(consts.webApi.productCategory.getAllProductCategories, config, function (result) {
                if (result.data.TotalCount == 0) {

                }
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function (error) {
                console.log('Error:' + error.message);
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('product-categories.module')); // register namespace (register module)