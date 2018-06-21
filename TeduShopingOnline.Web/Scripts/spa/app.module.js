/// <reference path="../plugins/angular/angular.min.js" />

// initiate module
var appModule = angular.module('appModule', []);

// initiate controller
appModule.controller("myController", myController);

myController.$inject = ['$scope'];

function myController($scope) {
    $scope.message = "Good morning!";
}