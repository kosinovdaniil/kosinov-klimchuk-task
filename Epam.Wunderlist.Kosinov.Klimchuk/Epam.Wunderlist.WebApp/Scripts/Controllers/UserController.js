webApp.controller('UserController', ['$scope', 'UsersRest', '$uibModal', function ($scope, UsersRest, $uibModal) {

    //$scope.users = UsersRest.query();

    $scope.user = UsersRest.get({ userId: userId });

    //$scope.newUser = UsersRest.update({Id: '1', Name: 'newUser', PhotoPath: '35shgf'});
    $scope.openUserModal = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'updateUser.html',
            controller: 'ModalUserController',
            size: 'lg',
            resolve: {
                user: function () {
                    return $scope.user;
                }
            }
        });


        modalInstance.result.then(function (user) {
            if (user.Name) {
                UsersRest.update({}, user,
                   function (data) {
                       console.log(data);
                   }
                );
            }
        })
    };
}]);