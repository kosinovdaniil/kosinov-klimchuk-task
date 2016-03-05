webApp.controller('ModalListController', ['$scope', '$uibModalInstance', function ($scope, $uibModalInstance) {
    $scope.ok = function () {
        $uibModalInstance.close($scope.nameList);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);