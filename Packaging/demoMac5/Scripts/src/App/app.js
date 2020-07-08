var app = angular
    .module('AceApp', [
        'ngAnimate',
        'ngResource',
        'ngSanitize',
        'dx',
        'ui.router',
        'oc.lazyLoad'
    ]);

angular.module('AceApp').controller('IndexController', function ($scope, $rootScope, LoginService, $http) {
    $scope.logout = function () {
        localStorage.clear();
        localStorage.clear();
        window.location = 'Home/Login';
    }

    $scope.FirstName = localStorage.getItem('StaffFirstName');
    $scope.LastName = localStorage.getItem('StaffLastName');
    $scope.PictureFile = localStorage.getItem('StaffImage');
    $scope.DepartmentID = localStorage.getItem('StaffDepartmentID');

    LoginService.GlobalLogin();
});

angular.module('AceApp').controller('DashboardController', function ($scope, $rootScope, LoginService, $http) {

    LoginService.GlobalLogin();
})

angular.module('AceApp').service('LoginService', ['$http', function ($http) {
    this.GlobalLogin = function () {
        //if (localStorage.getItem('StaffCode') === null || localStorage.getItem('StaffCode') === 'null') {
        //    localStorage.clear();
        //    localStorage.clear();
        //    window.location = 'Home/Login';
        //}
    }
}]);

function convertDate(inputFormat) {
    function pad(s) { return (s < 10) ? '0' + s : s; }
    var d = new Date(inputFormat);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
}