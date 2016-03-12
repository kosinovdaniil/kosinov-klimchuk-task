var webApp = angular.module('webApp', ['ngResource', 'ui.bootstrap', 'dndLists', 'ngFileUpload']);

webApp.factory('ListsRest', ['$resource', function ($resource) {
    return $resource('api/lists/', {}, {
        query: { method: 'GET', url: 'api/users/:userId/lists', isArray: true },
        get: { method: 'GET', url: 'api/lists/listId' },
        save: { method: 'POST', params: {} },
        update: { method: 'PUT', params: {} },
        delete: { method: 'DELETE', url: 'api/lists/:listId' }
    });
}]);

webApp.factory('ItemsRest', ['$resource', function ($resource) {
    return $resource('api/items/', {}, {
        query: { method: 'GET', url: 'api/lists/:listId/items', isArray: true },
        get: { method: 'GET', url: 'api/items/:itemId' },
        save: { method: 'POST', url: 'api/lists/:listId/items' },
        update: { method: 'PUT', params: {} },
        delete: { method: 'DELETE', url: 'api/items/:itemId' }
    });
}]);

webApp.factory('UsersRest', ['$resource', function ($resource) {
    return $resource('api/users/', {}, {
        query: { method: 'GET', params: {}, isArray: true },
        get: { method: 'GET', url: 'api/users/:userId' },
        update: { method: 'PUT', params: {} }
    });
}]);

webApp.service('descriptionService', function () {
    var todo;

    return {
        getProperty: function () {
            return todo;
        },
        setProperty: function (value) {
            todo = value;
        },
        initialProperty: null,
        isOpen: function () {
            return todo != null;
        },
        isChanged: function () {
            return this.initialProperty && JSON.stringify(this.initialProperty) != JSON.stringify(todo);
        },
        closeDescription: function () {
            this.initialProperty = null;
            main = document.getElementById('main');
            description = document.getElementById('item-info');
            main.className = main.className.replace('col-md-6', 'col-md-9');
            description.style.display = 'none';

            this.setProperty(null);
        },
        showDescription: function (value) {
            this.initialProperty = jQuery.extend({}, value);

            main = document.getElementById('main');
            description = document.getElementById('item-info');
            main.className = main.className.replace('col-md-9', 'col-md-6');
            description.style.display = 'block';

            this.setProperty(value);
        }

    };
});

webApp.service('currentListService', function () {
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

webApp.filter('isCompleted', function () {
    return function (arr) {
        for (var i = 0; i < arr.length; i++) {
            if (!arr[i].IsCompleted) {
                arr.splice(i);
            }
        }
        return arr;
    }
});













