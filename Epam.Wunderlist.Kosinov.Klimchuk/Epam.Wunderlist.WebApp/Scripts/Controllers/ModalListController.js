webApp.controller('ModalListController', ['$scope', '$uibModalInstance', 'list', function ($scope, $uibModalInstance, list) {
    $scope.list = list;
    $scope.modalHeader = list ? 'Update list' : 'Create list';
    $scope.ok = function () {
        $uibModalInstance.close($scope.list);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);