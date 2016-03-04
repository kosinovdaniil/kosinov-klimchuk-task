webApp.controller('UserController', ['$scope', 'UsersRest', function ($scope, UsersRest) {

    //$scope.users = UsersRest.query();

    $scope.user = UsersRest.get({ userId: userId });

    //$scope.newUser = UsersRest.update({Id: '1', Name: 'newUser', PhotoPath: '35shgf'});

}]);