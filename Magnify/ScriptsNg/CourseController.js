angular.module('myFormApp', [])
    .controller("CourseController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListCourse = null;
        $scope.courseModel = {
        };
        $scope.courseDropdownlist = null;
        $scope.courseSelected = "";
        getallData();
        getCreate();

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

        function getCreate() {
            $http({
                method: 'GET',
                url: '/Course/GetCreate'
            })
                .then(function (response) {
                    console.log(response.data);
                    $scope.courseDropdownlist = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                console.log($scope.message);
            });
        }
        //******* Create New Course ********
        $scope.createCourseForm = function () {            
            $http({
                method: 'POST',
                url: '/Course/New',
                data: $scope.courseModel
            })
            .then(function (response) {
                $window.location = "/Course";
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                console.log($scope.message);
            });
        };
        //******* Edit Course ********
        $scope.editCourseOpen = function (courseID) {
            console.log(courseID);
            $http({
                method: 'POST',
                url: '/Course/Getcourse/' + courseID
            })
                .then(function (response) {
                    $scope.courseModel = response.data;
                }, function (error) {
                    $scope.message = 'Unexpected Error while loading data!!';
                    console.log($scope.message);
                });
        }
        
        $scope.updateCourseForm = function () {
            $http({
                method: 'POST',
                url: '/Course/Update',
                data: $scope.courseModel
            })
                .then(function (response) {
                    $scope.courseModel = {};
                    $window.location = "/Course";
                }, function (error) {
                    $scope.message = 'Unexpected Error while loading data!!';
                    console.log($scope.message);
                });
        };
        //******* Delete Course ********
        $scope.deleteCourse = function (courseID) {
            if (confirm("Are you sure?")) {
                $http({
                    method: 'POST',
                    url: '/Course/DeleteOne/' + courseID
                })
                    .then(function (response) {
                        $window.location = "/Course";
                    }, function (error) {
                        $scope.message = 'Unexpected Error while loading data!!';
                        console.log($scope.message);
                    });
            }
        }
    })
