angular.module('myFormApp', [])
    .controller("StudentController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListStudent = null;
        $scope.result = "color-default";
        $scope.isViewLoading = false;
        $scope.custModel = {};

        getallData();

        //******* Get All Course ********
        function getallData() {
            //debugger;
            $http({
                method: 'GET',
                url: '/Student/GetAllData'
            }).then(function (response) {
                $scope.ListStudent = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                console.log($scope.message);
            });
        }

        $scope.saveStudent = function () {
            $scope.isViewLoading = true;

            $http({
                method: 'POST',
                url: '/Student/Insert',
                data: $scope.custModel
            }).then(function (response) {
                $scope.message = "Form data Saved!";
                $scope.result = "color-green";
                getallData();
                $scope.custModel = {};
            }, function (error) {
                $scope.message = "Form data not Saved!";
                $scope.result = "color-red";
            })

            $scope.isViewLoading = false;
        }

        $scope.deleteStudent = function (custModel) {
            var IsConf = confirm('You are about to delete ' + custModel.FirstName + '. Are you sure?');
            if (IsConf) {
                $http({
                    method: 'POST',
                    url: '/Student/Delete/' + custModel.StudentID
                }).then(function (response) {
                    $scope.message = custModel.FirstName + " deleted from record!!";
                    $scope.result = "color-green";
                    getallData();
                }, function (error) {
                    $scope.message = "Error on deleting Record!";
                    $scope.result = "color-red";
                })
            }
        }

        $scope.updateStudent = function () {
            $scope.isViewLoading = true;
            $http({
                method: 'POST',
                url: '/Student/Update',
                data: $scope.custModel
            }).then(function (response) {
                $scope.custModel = {};
                $scope.message = "Form data Updated!";
                $scope.result = "color-green";
                getallData();
            }, function (error) {
                $scope.message = "Form data not Updated!!";
                $scope.result = "color-red";
            })
            $scope.isViewLoading = false;
        }

        $scope.getStudent = function (custModel) {
            $http({
                method: 'GET',
                url: '/Student/GetByID/' + custModel.StudentID
            }).then(function (response) {
                $scope.custModel = response.data;
                getallData();
            }, function (error) {
                $scope.message = 'Unexpected Error whilte loading data!!';
                $scope.result = 'color-red';
            })
        }
    })
