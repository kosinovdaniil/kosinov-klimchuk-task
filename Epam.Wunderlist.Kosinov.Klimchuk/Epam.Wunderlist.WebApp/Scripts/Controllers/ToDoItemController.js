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

    $scope.toggleCompleted = function (id) {

        var find = function (arr, condition) {
            var i, x;
            for (i in arr) {
                x = arr[i];
                if (condition(x)) return x;
            }
        };

        var elem = find($scope.toDoItems, function (x) { return x.Id == id });

        elem.IsCompleted = !elem.IsCompleted;
        ItemsRest.update({ listId: listIdSharing.getProperty() },
            { Id: elem.Id, IsCompleted: elem.IsCompleted },
            function (data) {
                console.log(data);
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