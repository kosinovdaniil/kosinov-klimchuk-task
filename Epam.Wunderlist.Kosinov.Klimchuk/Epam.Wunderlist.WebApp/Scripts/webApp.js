var webApp = angular.module('webApp', ['ngResource', 'ui.bootstrap']);

webApp.factory('ListsRest', ['$resource', function ($resource) {
    return $resource('api/lists/', {}, {
        query: { method: 'GET', url: 'api/users/:userId/lists', isArray: true },
        get: { method: 'GET', url: 'api/lists/listId' },
        save: { method: 'POST', params: {} },
        update: { method: 'PUT', params: {} },
        delete: { method: 'DELETE', url: 'api/lists/:listId'}
    });
}]);

webApp.factory('ItemsRest', ['$resource', function ($resource) {
    return $resource('api/items/', {}, {
        query: { method: 'GET', url: 'api/lists/:listId/items', isArray: true },
        get: { method: 'GET', url: 'api/items/:itemId' },
        save: { method: 'POST', url: 'api/lists/:listId/items' },
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

webApp.service('listSharing', function () {
    var list;

    return {
        getProperty: function () {
            return list;
        },
        setProperty: function (value) {
            list = value;
        }
    };
});













