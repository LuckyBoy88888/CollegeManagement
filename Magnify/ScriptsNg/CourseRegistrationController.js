﻿angular.module('myFormApp', [])
    .controller("CourseRegistrationController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListCourseRegistration = null;

        getallData();

        //******* Get All Course ********
        function getallData() {
            //debugger;
            $http({
                method: 'GET',
                url: '/CourseRegistration/GetAllData'
            }).then(function (response) {
                $scope.ListCourseRegistration = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                console.log($scope.message);
            });
        }
    })
