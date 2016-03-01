webApp.controller('ToDoListController', ['$scope', 'ListsRest', '$uibModal', function ($scope, ListsRest, $uibModal) {

    $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
        console.log(data);
    });

    ListsRest.save();

    $scope.showItems =  function (listId){
        $scope.$broadcast('listClicked', listId);
    };

    //$scope.openCreateList = function () {
    //    var modalInstance = $uibModal.open({
    //        animation: true,
    //        templateUrl: 'createList.html',
    //        controller: 'ModalInstanceCtrl',
    //        size: size,
    //        resolve: {
    //            items: function () {
    //                return $scope.items;
    //            }
    //        }
    //};

}]);