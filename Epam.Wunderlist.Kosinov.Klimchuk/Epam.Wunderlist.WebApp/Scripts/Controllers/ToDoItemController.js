webApp.controller('ToDoItemController', ['$scope', 'ItemsRest', 'descriptionService', 'currentListService', '$filter', 'isCompletedFilter', function ($scope, ItemsRest, descriptionService, currentListService, $filter, isCompletedFilter) {

    $scope.addToDoItem = function () {
        if ($scope.todoText) {
            ItemsRest.save({ listId: currentListService.getProperty().Id },
                { Text: $scope.todoText, IsCompleted: false, IsFavourited: false, DateAdded: new Date(), List: { Id: currentListService.getProperty().Id } },
                function (data) {
                    console.log(data);
                    //$scope.toDoItems.push(data);
                    $scope.notCompletedItems.push(data);
                });
        }
        $scope.todoText = '';
    };

    $scope.toggleCompleted = function (item) {
        if (item.IsCompleted) {
            var index = $scope.completedItems.indexOf(item);
            item.IsCompleted = !item.IsCompleted;
            $scope.notCompletedItems.push(item);
            $scope.completedItems.splice(index, 1)
        } else {
            var index = $scope.notCompletedItems.indexOf(item);
            item.IsCompleted = !item.IsCompleted;
            $scope.completedItems.push(item);
            $scope.notCompletedItems.splice(index, 1)
        }
        
        ItemsRest.update({},
            { Id: item.Id, IsCompleted: item.IsCompleted },
            function (data) {
                console.log(data);
            });
    };

    $scope.deleteItem = function (item) {
        ItemsRest.delete({ itemId: item.Id }, function (data) {
            console.log(item.Id + 'deleted');
            if (item.IsCompleted) {
                $scope.completedItems.splice($scope.completedItems.indexOf(item), 1);
            }
            else {
                $scope.notCompletedItems.splice($scope.notCompletedItems.indexOf(item), 1);
            }
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
        ItemsRest.query({ listId: data }, function (data) {
            $scope.notCompletedItems = [];
            for (var i = 0; i < data.length; i++) {
                if (!data[i].IsCompleted) {
                    $scope.notCompletedItems.push(data[i]);
                }
            }
            console.log($scope.notCompletedItems);
            $scope.completedItems = data.filter(function (el) {
                return $scope.notCompletedItems.indexOf(el) < 0;
            });
            console.log($scope.completedItems);
        });

    });

    $scope.$on('itemChanged', function (event, data) {
        console.log(data);

        ItemsRest.update({}, data, function (data) {
            console.log(data);
        });
    });

    $scope.length = 35;
    $scope.$watch('todoText', function (newValue) {
        if (newValue && newValue.length > 35) {
            $scope.todoText = newValue.substring(0, 35);
        }

        if (newValue != undefined) {
            $scope.length = 35 - newValue.length;
        }
    });

    $scope.models = {
        selected: null
    };
    $scope.onMoved = function (value, event) {
        //console.log('model');
        //for (i = 0; i < $scope.models.lists.length; i++) {
        //    console.log($scope.models.lists[i]);
        //}
        console.log(event);
        console.log($scope.notCompletedItems);
        var index = $scope.notCompletedItems.indexOf(value);
        $scope.notCompletedItems.splice(index, 1);
        
        //$scope.models.lists.splice($index, 1)
    };

    $scope.itemDropped = function (item, index) {
        var list = $scope.toDoLists[index];
        console.log(list);
        ItemsRest.update({},
           { Id: item.Id, IsCompleted: item.IsCompleted, List: list },
           function (data) {
               console.log(data);
           });
        var indexItem = $scope.notCompletedItems.indexOf(item);
        $scope.notCompletedItems.splice(indexItem, 1);
    };

    $scope.lists = []
}]);