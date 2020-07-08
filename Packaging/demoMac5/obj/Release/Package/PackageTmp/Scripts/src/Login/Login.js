﻿angular.module('AceApp').controller('LoginController', ['$scope', '$location', '$stateParams', '$http', '$rootScope',
    function ($scope, $location, $stateParams, $http, $rootScope) {
    $rootScope.CheckUser = 0;

    $scope.submitLogin = function () {
        $http.post("../api/Staffs/login", { StaffLogin: $scope.username, StaffPassword: $scope.password })
            .then(function (data) {
                if (data.data.StatusCode == 2) {
                    console.log(data.data.Messages);
                }
                else {
                    if (data.data.Results.StaffLogin.length > 0) {
                        $scope.login = data.data.Results.StaffLogin[0];
                        localStorage.setItem('StaffID', $scope.login.StaffID);
                        localStorage.setItem('StaffCode', $scope.login.StaffCode);
                        localStorage.setItem('StaffImage', $scope.login.StaffImage);
                        localStorage.setItem('StaffFirstName', $scope.login.StaffFirstName);
                        localStorage.setItem('StaffLastName', $scope.login.StaffLastName);
                        localStorage.setItem('StaffDepartmentID', $scope.login.StaffDepartmentID);
                        localStorage.setItem('StaffLevelID', $scope.login.StaffLevelID);
                        localStorage.setItem('StaffLevel', $scope.login.StaffLevel);
                        window.location = '../../#/';
                    }
                    else {
                        $rootScope.CheckUser = 1;
                    }
                }
            });
    };
}])

