webApp.controller('ToDoListController', ['$scope', 'ToDoList', function ($scope, ToDoList) {

    $scope.toDoLists = ToDoList.query({ userId: '1' }, function (data) {
        console.log(data);
    });

}]);