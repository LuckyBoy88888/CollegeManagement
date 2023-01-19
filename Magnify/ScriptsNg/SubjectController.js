angular.module('myFormApp', [])
    .controller("SubjectController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListSubject = null;

        getallData();

        //******* Get All Course ********
        function getallData() {
            //debugger;
            $http({
                method: 'GET',
                url: '/Subject/GetAllData'
            }).then(function (response) {
                $scope.ListSubject = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading data!!';
                console.log($scope.message);
            });
        }
    })
