(function () {
    'use strict';

    /* Controllers */
    var Controllers = angular.module('itemsControllers', []);
    
    Controllers.controller('TestListCtrl', ['$scope', '$http', 
        function ($scope, $http) {
            // Note: Dictionaries *are* objects
            $scope.tests = [ {id : 1,
                              name : "Test 1",
                              pass : true},
                             {id : 2,
                              name : "Test 2",
                              pass : false},
                             {id : 3,
                              name : "Test 3",
                              pass: false}]; 
            $scope.author = 'idk';
        }]);

}())
