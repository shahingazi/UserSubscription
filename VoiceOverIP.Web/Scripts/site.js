

var app = angular.module('voipApp', []);
app.controller('userCtrl', function ($scope, $http) {

    function get() {
        $http.get("/api/users")
            .then(function (response) {
                $scope.users = response.data;
            });
    }

    get();

    $scope.sendPost = function () {
        $scope.status = false;
        var data = JSON.stringify({
            FirstName: $scope.firstname,
            LastName: $scope.lastname,
            Email: $scope.email
        });

        $http.post("/api/users/", data).success(function (data, status) {
            $scope.status = true;
            get();
        });
    }
});

