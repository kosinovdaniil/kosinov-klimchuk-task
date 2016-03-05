webApp.controller('ToDoListController', ['$scope', 'ListsRest', 'listIdSharing', '$uibModal', function ($scope, ListsRest, listIdSharing, $uibModal) {

    $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
        generationItemsLoad(data[0].Id);
    });

    //ListsRest.save();

    $scope.showItems = function (listId) {
        generationItemsLoad(listId);
    };

    function generationItemsLoad(listId) {
        $scope.$broadcast('listClicked', listId);

        listIdSharing.setProperty(listId);
    };

    $scope.openCreateList = function () {
        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'createList.html',
            controller: 'ModalListController',
            size: 'sm'
        });

        modalInstance.result.then(function (nameList) {
            if (nameList) {
                ListsRest.save({}, { Name: nameList, Users: [{ Id: userId }]},
                    function (data) {
                        console.log(data);
                        $scope.toDoLists.push(data);
                    });
            }
        });
    };


}]);