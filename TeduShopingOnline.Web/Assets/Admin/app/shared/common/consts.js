(function (app) {

    var appUrl = '/Assets/Admin/app/';
    var componentUrl = appUrl + 'components/';
    var sharedUrl = appUrl + 'shared/';
    var productCategoryApi = 'api/product-category/';

    var consts = {
        components: {
            url: componentUrl,
            applicationGroups: componentUrl + 'application-groups/',
            applicationRoles: componentUrl + 'application-roles/',
            applicationUsers: componentUrl + 'application-users/',
            home: componentUrl + 'home/',
            login: componentUrl + 'login/',
            orders: componentUrl + 'orders/',
            productCategories: componentUrl + 'product-categories/',
            products: componentUrl + 'products/',
            statistic: componentUrl + 'statistic/'
        },
        shared: {
            url: sharedUrl,
            common: sharedUrl + 'common/',
            directives: sharedUrl + 'directives/',
            filters: sharedUrl + 'filters/',
            modules: sharedUrl + 'modules/',
            services: sharedUrl + 'services/',
            views: sharedUrl + 'views/'
        },
        webApi: {
            productCategory: {
                api: productCategoryApi,               
                getAllProductCategories: productCategoryApi + 'get-all-product-category',
                addProductCategory: productCategoryApi + 'add-product-category',
                updateProductCategory: productCategoryApi + 'update-product-category',
                getProductCategoryById: productCategoryApi + 'get-product-category-by-id'
            }
        }
    };
    https://docs.angularjs.org/api/ng/type/angular.Module#constant    
    app.constant('consts', consts);
})(angular.module('common.module'));