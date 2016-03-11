webApp.controller('ModalUserController', ['$scope', 'user', '$uibModalInstance', function ($scope, user, $uibModalInstance) {
    $scope.user = user;

    $scope.ChechFileValid = function (file) {
        var isValid = false;
        if (file != null) {

            if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (1600 * 1200)) {
                $scope.FileInvalidMessage = "";
                isValid = true;
            }
            else {
                $scope.FileInvalidMessage = "Only JPEG/PNG/Gif Image can be upload )";
            }
        }

        $scope.IsFileValid = isValid;
    };


    $scope.ok = function () {
        var formdata = new FormData();
        var fileInput = document.getElementById('file');

        $scope.ChechFileValid(fileInput.files[0]);

        if ($scope.IsFileValid) {
            formdata.append("image", fileInput.files[0]);

            var xhr = new XMLHttpRequest();
            xhr.open('POST', '/Home/UploadFile', true);
            xhr.send(formdata);

            xhr.onreadystatechange = function () {
                if (xhr.status == 200) {
                    console.log(xhr.readyState);
                    console.log($scope.user);
                    var res = xhr.responseText;

                    
                    $scope.user.MimeTypeImage = JSON.parse(res).MimeType;
                    $scope.user.PhotoPath = fileInput.files[0].name;
                    $uibModalInstance.close($scope.user);
                }
                else {
                    $scope.FileInvalidMessage = JSON.parse(xhr.responseText).Message;
                    $scope.cancel;
                }
            }
        }
        $uibModalInstance.close($scope.user);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    $scope.length = 12;
    $scope.$watch('user.Name', function (newValue) {
        if (newValue && newValue.length > 12) {
            $scope.user.Name = newValue.substring(0, 12);
        }

        if (newValue != undefined) {
            $scope.length = 12 - newValue.length;
        }
    });
}]);