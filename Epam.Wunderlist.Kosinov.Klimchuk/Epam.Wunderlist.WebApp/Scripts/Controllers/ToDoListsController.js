﻿webApp.controller('ToDoListController', ['$scope', 'ListsRest', 'listSharing', '$uibModal', function ($scope, ListsRest, listSharing, $uibModal) {

    $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
        generationItemsLoad(data[0]);
    });

    //ListsRest.save();

    $scope.showItems = function (list) {
        generationItemsLoad(list);
    };

    function generationItemsLoad(list) {
        $scope.$broadcast('listClicked', list.Id);

        listSharing.setProperty(list);
        $scope.listTitle = list.Name;
    };

    $scope.openCreateList = function (list) {

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'createList.html',
            controller: 'ModalListController',
            size: 'sm',
            resolve: {
                list: function () {
                    return list;
                }
            }
        });

        modalInstance.result.then(function (list) {
            if (list) {
                if (list.Id) {
                    ListsRest.update({}, list,
                       function (data) {
                           console.log(data);
                           generationItemsLoad(list);
                       });
                }
                else {
                    ListsRest.save({}, { Name: list.Name, Users: [{ Id: userId }] },
                        function (data) {
                            console.log(data);
                            $scope.toDoLists.push(data);
                            listSharing.setProperty(data);
                        });
                }
            }
        });
    };

    $scope.deleteList = function (list) {
        if (listSharing.getProperty() == list) {
            $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
                generationItemsLoad(data[0]);
            });
        }
        ListsRest.delete({ listId: list.Id }, function () {
            console.log(list.Id + 'deleted');
            console.log($scope.toDoLists.splice($scope.toDoLists.indexOf(list), 1));
            
        })
    };
}]);