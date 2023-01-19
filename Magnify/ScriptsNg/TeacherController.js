angular.module('myFormApp', [])
    .controller("TeacherController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListTeacher = null;

        getallData();

        //******* Get All Course ********
        function getallData() {
            //debugger;
            $http({
                method: 'GET',
                url: '/Teacher/GetAllData'
            }).then(function (response) {
                $scope.ListTeacher = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                console.log($scope.message);
            });
        }
    })
