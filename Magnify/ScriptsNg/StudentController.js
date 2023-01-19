angular.module('myFormApp', [])
    .controller("StudentController", function ($scope, $http, $location, $window) {
        $scope.message = '';
        $scope.ListStudent = null;

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
    })
