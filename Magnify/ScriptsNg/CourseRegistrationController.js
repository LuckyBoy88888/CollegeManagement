angular.module('myFormApp', [])
    .controller("CourseRegistrationController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListCourseRegistration = null;
        $scope.courseModel = {
        };
        $scope.courseDropdownlist = null;
        $scope.studentDropdownlist = null;
        getallData();
        getCourseList();
        getStudentList();

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

        //****** Create New *******
        function getCourseList() {
            $http({
                method: 'GET',
                url: '/CourseRegistration/GetCourseList'
            })
                .then(function (response) {
                    console.log(response.data);
                    $scope.courseDropdownlist = response.data;
                }, function (error) {
                    $scope.message = 'Unexpected Error while loading data!!';
                    console.log($scope.message);
                });
        }
        function getStudentList() {
            $http({
                method: 'GET',
                url: '/CourseRegistration/GetStudentList'
            })
                .then(function (response) {
                    console.log(response.data);
                    $scope.studentDropdownlist = response.data;
                }, function (error) {
                    $scope.message = 'Unexpected Error while loading data!!';
                    console.log($scope.message);
                });
        }
        $scope.createCourseRegForm = function () {
            $http({
                method: 'POST',
                url: '/CourseRegistration/New',
                data: $scope.courseModel
            })
                .then(function (response) {
                    $window.location = "/CourseRegistration";
                }, function (error) {
                    $scope.message = 'Unexpected Error while loading data!!';
                    console.log($scope.message);
                });
        };

        //******** Delete Course Reg*******
        $scope.deleteCourseReg = function (CourseRegistrationID) {
            if (confirm("Are you sure?")) {
                $http({
                    method: 'POST',
                    url: '/CourseRegistration/DeleteOne/' + CourseRegistrationID
                })
                    .then(function (response) {
                        $window.location = "/CourseRegistration";
                    }, function (error) {
                        $scope.message = 'Unexpected Error while loading data!!';
                        console.log($scope.message);
                    });
            }
        }

        //******* Edit Course Reg********
        $scope.editCourseOpen = function (CourseRegistrationID) {
            console.log(CourseRegistrationID);
            $http({
                method: 'POST',
                url: '/CourseRegistration/GetcourseReg/' + CourseRegistrationID
            })
                .then(function (response) {
                    console.log(response.data);
                    $scope.courseModel = response.data;
                }, function (error) {
                    $scope.message = 'Unexpected Error while loading data!!';
                    console.log($scope.message);
                });
        }
        $scope.updateCourseRegForm = function () {
            $http({
                method: 'POST',
                url: '/CourseRegistration/Update',
                data: $scope.courseModel
            })
                .then(function (response) {
                    $scope.courseModel = {};
                    $window.location = "/CourseRegistration";
                }, function (error) {
                    $scope.message = 'Unexpected Error while loading data!!';
                    console.log($scope.message);
                });
        };
        
    })
