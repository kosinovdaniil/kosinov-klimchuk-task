webApp.controller('DescriptionController', ['$scope', 'descriptionService', function ($scope, descriptionService) {

    $scope.getTodo = function () {
        return descriptionService.getProperty();
    }

    $scope.closeDescription = function () {
        descriptionService.getProperty().DateCompletion = $scope.tempDate;
        if (descriptionService.isChanged()) {
            $scope.$emit('itemChanged', descriptionService.getProperty());
        }
        descriptionService.closeDescription();
                
    };

    $scope.openCalendar = function () {
        $scope.popup.opened = true;
    };

    $scope.popup = {
        opened: false
    };
}]);