var webApp = angular.module('webApp', ['ngResource']);

webApp.factory('ListsRest', ['$resource', function ($resource) {
    return $resource('api/users/', {}, {
        query: { method: 'GET', url: 'api/users/:userId/lists', isArray: true },
        get: { method: 'GET', url: 'api/lists/:listId' },
        save: { method: 'POST', params: {} }
        //update: { method: 'PUT', url: 'service/products/modifyProduct' },
        //delete: { method: 'DELETE', url: ''}
    });
}]);

webApp.factory('ItemsRest', ['$resource', function ($resource) {
    return $resource('api/lists/:listId/items', {}, {
        query: { method: 'GET', params: {}, isArray: true },
        get: { method: 'GET', url: 'api/items/:itemId' },
        save: { method: 'POST', params: {} },
        update: { method: 'PUT', params: {} },
        delete: { method: 'DELETE', params: {}}
    });
}]);

webApp.factory('UsersRest', ['$resource', function ($resource) {
    return $resource('api/users/', {}, {
        query: { method: 'GET', params: {}, isArray: true },
        get: { method: 'GET', url: 'api/users/:userId' },
        update: { method: 'PUT', url: 'service/products/modifyProduct' },
    });
}]);

webApp.service('todoDescriptionSharing', function () {
    var todo;

    return {
        getProperty: function () {
            return todo;
        },
        setProperty: function (value) {
            todo = value;
        }
    };
});












