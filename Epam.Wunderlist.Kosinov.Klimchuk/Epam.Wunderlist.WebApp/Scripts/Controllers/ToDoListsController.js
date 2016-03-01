webApp.controller('ToDoListController', ['$scope', 'ToDoList', function ($scope, ToDoList) {

    $scope.toDoLists = ToDoList.query({ userId: userId }, function (data) {
        console.log(data);
    });

}]);