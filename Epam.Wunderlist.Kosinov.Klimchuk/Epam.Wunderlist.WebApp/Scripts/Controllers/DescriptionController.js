webApp.controller('DescriptionController', ['$scope', function ($scope) {
    $scope.closeDescription = function () {
        main = document.getElementById('main');
        description = document.getElementById('item-info');

        main.className = main.className.replace('col-md-6', 'col-md-9');
        description.style.display = 'none';
    };
}]);