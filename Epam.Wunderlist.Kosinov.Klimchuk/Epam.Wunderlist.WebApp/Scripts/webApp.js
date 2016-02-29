var webApp = angular.module('webApp', ['pageslide-directive', 'ngResource']);

webApp.factory('ToDoList', ['$resource', function ($resource) {
    return $resource('api/users/:userId/lists', {
        //userId: '@ClaimTypes.NameIdentifier',
        //update: {method: 'PUT', params: {userId : '1'}, isArray: true}
        //return $resource('api/lists/:listId/items', {
    })
}]);

webApp.factory('ToDoItems', ['$resource', function ($resource) {
    //userId: '@ClaimTypes.NameIdentifier',
    //update: {method: 'PUT', params: {userId : '1'}, isArray: true}
    return $resource('api/lists/:listId/items/', {
    })
}]);

webApp.controller('ToDoItemController', ['$scope', 'ToDoItems', function ($scope, ToDoItems) {
    $scope.toDoItems = [
      { text: 'learn angular', done: true},
      { text: 'build an angular app', done: false}];

    //$scope.toDoItems = ToDoItems.query({listId: '1'});

    //ToDoItems.save({ listId: '1' },
    //    { Text: 'watch film', IsCompleted: false, IsFavourited: false, DateAdded: '2/29/2016' },
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
        hasClass = document.getElementById('main').classList.contains('col-md-6');
        if (hasClass) {
            document.getElementById("main").className = document.getElementById("main").className.replace('col-md-6', 'col-md-9');
        }
        else {
            document.getElementById("main").className = document.getElementById("main").className.replace('col-md-9', 'col-md-6');
            
        }
    };
}]);

webApp.controller('ToDoListController', ['$scope', 'ToDoList', function ($scope, ToDoList) {

    $scope.toDoLists = ToDoList.query({ userId: '1' }, function (data) {
        console.log(data);
    });

}]);


