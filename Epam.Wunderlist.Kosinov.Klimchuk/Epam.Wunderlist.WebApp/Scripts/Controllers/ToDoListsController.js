﻿webApp.controller('ToDoListController', ['$scope', 'ListsRest', 'listIdSharing', function ($scope, ListsRest, listIdSharing) {

    $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
        //listIdSharing.setProperty(data[0].Id);

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