angular.module('myFormApp', [])
    .controller("TeacherController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListTeacher = null;
        $scope.ListSubject = null;
        $scope.custModel = {};
        $scope.result = "color-default";
        $scope.isViewLoading = false;

        getallSubject();
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
                $scope.result = "color-red";
                console.log($scope.message);
            });
        }

        //******* Get All Subject ********
        function getallSubject() {
            //debugger;
            $http({
                method: 'GET',
                url: '/Teacher/GetAllSubject'
            }).then(function (response) {
                $scope.ListSubject = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
        }

        //******* Save Teacher ********
        $scope.saveTeacher = function () {
            $scope.isViewLoading = true;

            $http({
                method: 'POST',
                url: '/Teacher/Insert',
                data: $scope.custModel
            }).then(function (response) {
                $scope.message = "Form data Saved!";
                $scope.result = "color-green";
                getallData();
                $scope.custModel = {};
            }, function (error) {
                $scope.message = 'Unexpected Error while saving data!!' + error;
                $scope.result = 'color-red';
            })

            $scope.isViewLoading = false;
        }

        $scope.deleteTeacher = function (custModel) {
            var IsConf = confirm("You are about to delete " + custModel.FirstName + '. Are you sure?');
            if (IsConf) {
                $http({
                    method: 'POST',
                    url: '/Teacher/Delete/' + custModel.TeacherID
                }).then(function (response) {
                    $scope.message = custModel.FirstName + ' deleted from record!!';
                    $scope.result = 'color-green';
                    getallData();
                }, function (error) {
                    $scope.message = 'Error on deleting Record!';
                    $scope.result = 'color-red';
                })
            }
        }

        $scope.getTeacher = function (custModel) {
            $http({
                method: 'GET',
                url: '/Teacher/GetByID/' + custModel.TeacherID
            }).then(function (response) {
                $scope.custModel = response.data;
                getallData();
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                $scope.result = 'color-red';
            })
        }

        $scope.updateTeacher = function () {
            $scope.isViewLoading = true;
            $http({
                method: 'POST',
                url: '/Teacher/Update',
                data: $scope.custModel
            }).then(function (response) {
                $scope.message = "Form data Updated!";
                $scope.result = 'color-green';
                getallData();
            }, function (error) {
                $scope.message = 'Unexpected Error while updating data!!';
                $scope.result = 'color-red';
            })
            $scope.isViewLoading = false;
        }
    })
