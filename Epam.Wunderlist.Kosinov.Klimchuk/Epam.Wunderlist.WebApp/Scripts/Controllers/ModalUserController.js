webApp.controller('ModalUserController', ['$scope','user', '$uibModalInstance', function ($scope, user, $uibModalInstance) {
    $scope.user = user;
    $scope.ok = function () {
        $uibModalInstance.close($scope.user);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);