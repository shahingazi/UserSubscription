

var app = angular.module('voipApp', []);
app.controller('userCtrl', function ($scope, $http) {

    $http.get("/api/users")
        .then(function (response) {
            console.log(response);
            $scope.users = response.data;
        });
});

