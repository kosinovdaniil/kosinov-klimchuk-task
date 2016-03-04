webApp.controller('ToDoItemController', ['$scope', 'ItemsRest', 'todoDescriptionSharing', 'listIdSharing', function ($scope, ItemsRest, todoDescriptionSharing, listIdSharing) {

    //$scope.getItems = function () {
    //    $scope.toDoItems = ItemsRest.query({ listId: listIdSharing.getProperty() });
    //}
    

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

    $scope.addToDoItem = function () {
        if ($scope.todoText) {
            $scope.toDoItems.push({ Text: $scope.todoText, IsCompleted: false });

            ItemsRest.save({ listId: listIdSharing.getProperty() },
                { Text: $scope.todoText, IsCompleted: false, IsFavourited: false, DateAdded: new Date(), List: { Id: listIdSharing.getProperty() } },
                function (data) {
                    console.log(data);
                });
        }
        $scope.todoText = '';
    };

    $scope.setDoneToDoItem = function (index) {
        var elem = $scope.toDoItems[index];
        console.log(item);

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