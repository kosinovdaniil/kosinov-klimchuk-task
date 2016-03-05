﻿webApp.controller('ToDoListController', ['$scope', 'ListsRest', 'listIdSharing', '$uibModal', function ($scope, ListsRest, listIdSharing, $uibModal) {

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
                        listIdSharing.setProperty(data.Id);
                    });
            }
        });
    };

    $scope.deleteList = function (list) {
        alert(listIdSharing.getProperty());
        if (listIdSharing.getProperty() == list.Id) {
            $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
                generationItemsLoad(data[0].Id);
            });
        }
        ListsRest.delete({ listId: list.Id }, function () {
            console.log(list.Id + 'deleted');
            console.log($scope.toDoLists.splice($scope.toDoLists.indexOf(list), 1));
            
        })
    };
}]);