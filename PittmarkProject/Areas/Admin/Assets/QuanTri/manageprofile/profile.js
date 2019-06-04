(function (app) {


    app.controller('profile', profile);
    profile.$inject = ['$scope', 'apiService','notificationService'];
    function profile($scope, apiService, notificationService) {

        $scope.emails = [];
        $scope.address = [];
        $scope.numberPhone = [];
        $scope.facebook = [];
        $scope.imgLogo = "";
        $scope.imgCover = "";
        $scope.updateProfile = updateProfile;

        $scope.profile = {};
        function getEmails() {
            $scope.emails.length = 0;
            var lstEmailsTag = $('#pnlEmail').find("input[type='text']");
            $(lstEmailsTag).each(function (index, item) {
                $scope.emails.push($(item).val());

            });
            console.log($scope.emails);
        }

        function getAddress() {
            $scope.address.length = 0;
            var lstEmailsTag = $('#pnlAddress').find("input[type='text']");
            $(lstEmailsTag).each(function (index, item) {
                $scope.address.push($(item).val());

            });
            console.log($scope.address);
        }

        function getNumberPhone() {
            $scope.numberPhone.length = 0;
            var lstEmailsTag = $('#pnlPhone').find("input[type='text']");
            $(lstEmailsTag).each(function (index, item) {
                $scope.numberPhone.push($(item).val());

            });
            console.log($scope.numberPhone);
        }

        function getFacebooks() {
            $scope.facebook.length = 0;
            var lstEmailsTag = $('#pnlFacebook').find("input[type='text']");
            $(lstEmailsTag).each(function (index, item) {
                $scope.facebook.push($(item).val());

            });
            console.log($scope.facebook);
        }


        function updateProfile() {
            getEmails();
            getAddress();
            getNumberPhone();
            getFacebooks();
          

            $scope.profile.ImgLogo = $('#img-logo').attr('src');
            $scope.profile.ImgCover = $('#img-cover').attr('src');
            $scope.profile.EmailList = $scope.emails;
            $scope.profile.PhoneNumberList = $scope.numberPhone;
            $scope.profile.AddressList = $scope.address;
            $scope.profile.FaceBook = $scope.facebook;

            console.log($scope.profile);
            

            apiService.put('/Api/Profile/Update', $scope.profile, function (result) {
                notificationService.displaySuccess('Lưu thành công');
                $state.go('products');
            }, function (error) {
                notificationService.displayError('Lưu thất bại');
            });


        }



    }
})(angular.module('pittmask.common'));
