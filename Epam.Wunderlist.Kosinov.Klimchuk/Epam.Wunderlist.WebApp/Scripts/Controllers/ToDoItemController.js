webApp.controller('ToDoItemController', ['$scope', 'ToDoItems', function ($scope, ToDoItems) {

    $scope.toDoItems = ToDoItems.query({ listId: '1' });

    //ToDoItems.save({ listId: '1' },
    //    { Text: 'watch film', IsCompleted: false, IsFavourited: false, DateAdded: '2/29/2016', List: { Id: '1' } },
    //    function (data) {
    //        console.log(data);
    //    });

    $scope.addToDoItem = function () {
        if ($scope.todoText) {
            $scope.toDoItems.push({ text: $scope.todoText, done: false });
        }
        $scope.todoText = '';
    };

    $scope.showDescription = function () {
        main = document.getElementById('main');
        description = document.getElementById('item-info');

        main.className = main.className.replace('col-md-9', 'col-md-6');
        description.style.display = 'block';
    };
}]);