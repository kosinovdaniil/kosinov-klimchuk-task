webApp.controller('DescriptionController', ['$scope', 'todoDescriptionSharing', function ($scope, todoDescriptionSharing) {

    $scope.getTodo = function () {
        return todoDescriptionSharing.getProperty();
    }
    $scope.closeDescription = function () {
        main = document.getElementById('main');
        description = document.getElementById('item-info');
        main.className = main.className.replace('col-md-6', 'col-md-9');
        description.style.display = 'none';
    };
}]);