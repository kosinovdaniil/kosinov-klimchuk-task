webApp.controller('ModalUserController', ['$scope', 'user', '$uibModalInstance', 'Upload', function ($scope, user, $uibModalInstance, Upload) {
    $scope.user = jQuery.extend({}, user);

    $scope.ok = function () {
        if ($scope.form.file.$valid && $scope.file) {
            $scope.upload($scope.file);
            $scope.user.PhotoPath = $scope.file.name;
        }
        $uibModalInstance.close($scope.user);
    };

    // upload on file select or drop
    $scope.upload = function (file) {
        Upload.upload({
            url: '/Home/UploadFile',
            data: { file: file }
        }).then(function (resp) {
            console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
        }, function (resp) {
            console.log('Error status: ' + resp.status);
        }, function (evt) {
            var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
            console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
        });
    };

    //$scope.ChechFileValid = function (file) {
    //    var isValid = false;
    //    if (file != null) {

    //        if ((file.type == 'image/png' || file.type == 'image/jpeg' || file.type == 'image/gif') && file.size <= (1600 * 1200)) {
    //            $scope.FileInvalidMessage = "";
    //            isValid = true;
    //        }
    //        else {
    //            $scope.FileInvalidMessage = "Only JPEG/PNG/Gif Image can be upload )";
    //        }
    //    }

    //    $scope.IsFileValid = isValid;
    //};


    //$scope.ok = function () {
    //    var formdata = new FormData();
    //    var fileInput = document.getElementById('file');

    //    $scope.ChechFileValid(fileInput.files[0]);

    //    if ($scope.IsFileValid) {
    //        formdata.append("image", fileInput.files[0]);

    //        var xhr = new XMLHttpRequest();
    //        xhr.open('POST', '/Home/UploadFile', true);
    //        xhr.send(formdata);

    //        xhr.onreadystatechange = function () {
    //            if (xhr.status == 200) {
    //                console.log(xhr.readyState);
    //                console.log($scope.user);
    //                var res = xhr.responseText;

                    
    //                $scope.user.MimeTypeImage = JSON.parse(res).MimeType;
    //                $scope.user.PhotoPath = fileInput.files[0].name;
    //                $uibModalInstance.close($scope.user);
    //            }
    //            else {
    //                $scope.FileInvalidMessage = JSON.parse(xhr.responseText).Message;
    //                $scope.cancel;
    //            }
    //        }
    //    }
    //    $uibModalInstance.close($scope.user);
    //};

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