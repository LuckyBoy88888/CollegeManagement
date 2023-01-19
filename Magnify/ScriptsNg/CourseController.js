angular.module('myFormApp', [])
    .controller("CourseController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListCourse = null;

        getallData();

        //******* Get All Course ********
        function getallData() {
            //debugger;
            $http({
                method: 'GET',
                url: '/Course/GetAllData'
            }).then(function (response) {
                $scope.ListCourse = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                console.log($scope.message);
            });
        }
    })
