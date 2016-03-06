﻿webApp.controller('ToDoItemController', ['$scope', 'ItemsRest', 'descriptionService', 'currentListService', function ($scope, ItemsRest, descriptionService, currentListService) {

    $scope.addToDoItem = function () {
        if ($scope.todoText) {
            ItemsRest.save({ listId: currentListService.getProperty().Id },
                { Text: $scope.todoText, IsCompleted: false, IsFavourited: false, DateAdded: new Date(), List: { Id: currentListService.getProperty().Id } },
                function (data) {
                    console.log(data);
                    $scope.toDoItems.push(data);
                });
        }
        $scope.todoText = '';
    };

    $scope.toggleCompleted = function (item) {
        var index = $scope.toDoItems.indexOf(item)
        item.IsCompleted = !item.IsCompleted;
        ItemsRest.update({},
            { Id: item.Id, IsCompleted: item.IsCompleted },
            function (data) {
                console.log(data);
            });
    };

    $scope.deleteItem = function (item) {
        ItemsRest.delete({ itemId: item.Id }, function (data) {
            console.log(item.Id + 'deleted');
            $scope.toDoItems.splice($scope.toDoItems.indexOf(item), 1);
        });
    };


    $scope.showDescription = function (todo) {

        if (descriptionService.isChanged()) {
            $scope.$emit('itemChanged', descriptionService.getProperty());
        }
        $scope.tempDate = todo.DateCompletion ? new Date(todo.DateCompletion) : null;

        descriptionService.showDescription(todo);
    };

    $scope.$on('listClicked', function (event, data) {
        if (descriptionService.isOpen()) {
            descriptionService.closeDescription();
        }
        $scope.toDoItems = ItemsRest.query({ listId: data });
    });

    $scope.$on('itemChanged', function (event, data) {
        console.log(data);

        ItemsRest.update({}, data, function (data) {
            console.log(data);
        });
    });



}]);