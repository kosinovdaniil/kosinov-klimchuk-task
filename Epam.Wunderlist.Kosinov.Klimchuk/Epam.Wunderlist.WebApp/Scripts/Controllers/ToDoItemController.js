webApp.controller('ToDoItemController', ['$scope', 'ItemsRest', 'todoDescriptionSharing', function ($scope, ItemsRest, todoDescriptionSharing) {

    $scope.toDoItems = ItemsRest.query({ listId: '1' });

    //ItemsRest.save({ listId: '1' },
    //    { Text: 'watch film', IsCompleted: false, IsFavourited: false, DateAdded: '2/29/2016', List: { Id: '1' } },
    //    function (data) {
    //        console.log(data);
    //    });

    //ItemsRest.update({ listId: '1' },
    //    { Id: '121', Text: 'watch NEW film', DateAdded: '3/1/2016' },
    //    function (data) {
    //        console.log(data);
    //    });

    ItemsRest.delete({ itemId: '121' });

    $scope.addToDoItem = function () {
        if ($scope.todoText) {
            $scope.toDoItems.push({ text: $scope.todoText, done: false });
        }
        $scope.todoText = '';
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