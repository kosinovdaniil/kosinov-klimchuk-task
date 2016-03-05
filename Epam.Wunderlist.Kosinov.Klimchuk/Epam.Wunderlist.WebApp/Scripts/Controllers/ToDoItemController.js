webApp.controller('ToDoItemController', ['$scope', 'ItemsRest', 'todoDescriptionSharing', 'listIdSharing', function ($scope, ItemsRest, todoDescriptionSharing, listIdSharing) {

    $scope.addToDoItem = function () {
        if ($scope.todoText) {
            ItemsRest.save({ listId: listIdSharing.getProperty() },
                { Text: $scope.todoText, IsCompleted: false, IsFavourited: false, DateAdded: new Date(), List: { Id: listIdSharing.getProperty() } },
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
        ItemsRest.update({ listId: listIdSharing.getProperty() },
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
        main = document.getElementById('main');
        description = document.getElementById('item-info');
        main.className = main.className.replace('col-md-9', 'col-md-6');
        description.style.display = 'block';

        todoDescriptionSharing.setProperty(todo);
    };

    $scope.$on('listClicked', function (event, data) {
        $scope.toDoItems = ItemsRest.query({ listId: data });
    });

}]);