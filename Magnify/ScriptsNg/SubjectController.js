angular.module('myFormApp', [])
    .controller("SubjectController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListSubject = null;
        $scope.custModel = {};
        $scope.result = "color-default";
        $scope.isViewLoading = false;

        getallData();

        //******* Get All Course ********
        function getallData() {
            $scope.isViewLoading = true;
            //debugger;
            $http({
                method: 'GET',
                url: '/Subject/GetAllData'
            }).then(function (response) {
                $scope.ListSubject = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
            $scope.isViewLoading = false;
        }

        $scope.saveSubject = function () {
            $scope.isViewLoading = true;

            $http({
                method: 'POST',
                url: '/Subject/Insert',
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

        $scope.deleteSubject = function (custModel) {
            var IsConf = confirm('You are about to delete ' + custModel.Title + '. Are you sure?');
            if (IsConf) {
                $http({
                    method: 'POST',
                    url: '/Subject/Delete/' + custModel.SubjectID
                }).then(function (response) {
                    $scope.message = custModel.Title + ' deleted from record!';
                    getallData();
                }, function (error) {
                    $scope.message = 'Error on deleting Record!';
                })
            }
        }

        $scope.getSubject = function (custModel) {
            $http({
                method: 'GET',
                url: '/Subject/GetByID/' + custModel.SubjectID
            }).then(function (response) {
                $scope.custModel = response.data;
                getallData();
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                $scope.result = 'color-red';
            })
        }

        $scope.updateSubject = function () {
            $scope.isViewLoading = true;
            $http({
                method: 'POST',
                url: '/Subject/Update',
                data: $scope.custModel
            }).then(function (response) {
                $scope.custModel = null;
                $scope.message = "Form data Updated!";
                $scope.result = 'color-green';
                getallData();
            }, function (error) {
                $scope.message = 'Form data not Updated!';
                $scope.result = "color-red";
            })
            $scope.isViewLoading = false;
        }
    })
