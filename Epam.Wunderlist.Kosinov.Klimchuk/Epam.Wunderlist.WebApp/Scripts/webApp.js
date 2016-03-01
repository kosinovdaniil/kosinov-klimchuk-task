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
    //return $resource('api/lists/:listId/items/', {
    return $resource('api/lists/:listId/items', {
    })
}]);








