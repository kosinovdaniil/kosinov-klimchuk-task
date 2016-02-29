var webApp = angular.module('webApp', []);

webApp.controller('ToDoItemController', function ($scope) {
    $scope.toDoItems = [
      { text: 'learn angular', done: true },
      { text: 'build an angular app', done: false }];

    $scope.addToDoItem = function () {
        if ($scope.todoText) {
            $scope.toDoItems.push({ text: $scope.todoText, done: false });
        }
        $scope.todoText = '';
    };
});

webApp.controller('MainCtrl', function ($scope) {
    $scope.showDiv = '1';

    $scope.toggleShow = function () {
        $scope.showDiv = !$scope.showDiv;
    }
});