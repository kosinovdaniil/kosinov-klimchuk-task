var webApp = angular.module('webApp', ['ngResource']);

webApp.factory('ListsRest', ['$resource', function ($resource) {
    return $resource('api/lists/', {}, {
        query: { method: 'GET', url: 'api/users/:userId/lists', isArray: true },
        get: { method: 'GET', params: {} },
        save: { method: 'POST', params: {} },
        update: { method: 'PUT', params: {} },
        delete: { method: 'DELETE', params: {}}
    });
}]);

webApp.factory('ItemsRest', ['$resource', function ($resource) {
    return $resource('api/items/', {}, {
        query: { method: 'GET', url: 'api/lists/:listId/items', isArray: true },
        get: { method: 'GET', params: {} },
        save: { method: 'POST', params: {} },
        update: { method: 'PUT', params: {} },
        delete: { method: 'DELETE', url: 'api/items/:itemId'}
    });
}]);

webApp.factory('UsersRest', ['$resource', function ($resource) {
    return $resource('api/users/', {}, {
        query: { method: 'GET', params: {}, isArray: true },
        get: { method: 'GET', url: 'api/users/:userId' },
        update: { method: 'PUT', params: {} }
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












