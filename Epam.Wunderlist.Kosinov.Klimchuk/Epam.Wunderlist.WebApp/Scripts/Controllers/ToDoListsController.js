webApp.controller('ToDoListController', ['$scope', 'ListsRest', 'currentListService', '$uibModal', 'descriptionService', function ($scope, ListsRest, currentListService, $uibModal, descriptionService) {

    $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
        switchList(data[0]);
    });

    //ListsRest.save();

    $scope.showItems = function (list) {
        switchList(list);
    };

    function switchList(list) {
        if (descriptionService.isChanged()) {
            $scope.$broadcast('itemChanged', descriptionService.getProperty());
        }
        $scope.$broadcast('listClicked', list.Id);

        currentListService.setProperty(list);
        $scope.listTitle = list.Name;
    };

    $scope.openListModal = function (list) {

        var modalInstance = $uibModal.open({
            animation: true,
            templateUrl: 'createList.html',
            controller: 'ModalListController',
            size: 'sm',
            resolve: {
                list: function () {
                    return list;
                }
            }
        });

        modalInstance.result.then(function (list) {
            if (list.Name) {
                if (list.Id) {
                    ListsRest.update({}, list,
                       function (data) {
                           console.log(data);
                           switchList(list);
                       });
                    var x = $scope.toDoLists.findIndex(function (temp) { return temp.Id == list.Id; });
                    $scope.toDoLists[x] = list;
                    //console.log(y);
                }
                else {
                    ListsRest.save({}, { Name: list.Name, Users: [{ Id: userId }] },
                        function (data) {
                            console.log(data);
                            $scope.toDoLists.push(data);
                            currentListService.setProperty(data);
                        });
                }
            }
        });
    };

    $scope.deleteList = function (list) {
        if (currentListService.getProperty() == list) {
            $scope.toDoLists = ListsRest.query({ userId: userId }, function (data) {
                switchList(data[0]);
            });
        }
        ListsRest.delete({ listId: list.Id }, function () {
            console.log(list.Id + 'deleted');
            console.log($scope.toDoLists.splice($scope.toDoLists.indexOf(list), 1));

        })
    };



}]);