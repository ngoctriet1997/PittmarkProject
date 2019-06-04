
(function (app) {


    app.controller('manageDisplayProduct', manageDisplayProduct);
    manageDisplayProduct.$inject = ['$scope', 'apiService', 'notificationService'];
    function manageDisplayProduct($scope, apiService, notificationService) {

        $scope.Products = [];

        $scope.addOrRemoveList = addOrRemoveList;

        $scope.addOrRemoveIdList = addOrRemoveIdList;

        $scope.deleteById = deleteById;

        $scope.Product = {};
        $scope.getById = getById;
        $scope.update = update;
        $scope.Add = Add;
        getAll();


        function getAll() {



            apiService.get('/Api/DisplayProduct/GetAll', "", function (result) {
                notificationService.displaySuccess('Lấy thành công');
                $scope.Products = result.data;
                angular.forEach($scope.Products, function (value, key) {
                    value.Delete = false;
                });
               
            }, function (error) {
                notificationService.displayError('Lấy thất bại');
            });
        }

        function getById(id) {
            var config = { params: { id: id } };

            apiService.get('/Api/DisplayProduct/GetById', config, function (result) {
                notificationService.displaySuccess('Lấy thành công');
              
          
                $scope.Product.Name = result.data.Name;
                $("#img-logo").attr("src", result.data.Image);
                $scope.Product.id = result.data.id;

                $scope.Product.Delete = false;


            }, function (error) {
                notificationService.displayError('Lấy thất bại');
                });
            $("#img-logo").attr("src", result.data.Image);
        }

        function update() {

            var data = {
                Image: $("#img-logo").attr('src'),
                Name: $scope.Product.Name,
           
                id: $scope.Product.id

            };

           
            apiService.put('/Api/DisplayProduct/Update', data, function (result) {

              
                getAll();
                notificationService.displaySuccess('Lưu thành công');
            }, function (error) {
                notificationService.displayError('Lưu thất bại');

            });
        }

        function deleteById() {

            var count = 0;
            for (var i = 0; i < $scope.Products.length; i++) {
                if ($scope.Products[i].Delete == true) {
                    count++;
                    var config = {
                        params: { id: $scope.Products[i].id }
                    };
                    apiService.del('/Api/DisplayProduct/DeleteById', config, function (result) {


                        notificationService.displaySuccess("Xóa thành công");
                        getAll();


                    }, function (error) {
                        notificationService.displayError('Xóa thất bại');
                        getAll();
                    });
                }
              
            }

        }
        function addOrRemoveIdList(id) {


            angular.forEach($scope.Products, function (value, key) {
                if (value.id == id) {
                    if (value.Delete == false) {
                        value.Delete = true;
                    }
                    else {
                        value.Delete = false;
                    }
                }
            });

           
        }



        function addOrRemoveList() {

            if ($('#cbkAll').data('check') == false) {
                $('#cbkAll').data('check', true);
                angular.forEach($scope.Products, function (value, key) {

                    value.Delete = true;

                });
            }
            else {
                $('#cbkAll').data('check', false);
                angular.forEach($scope.Products, function (value, key) {

                    value.Delete = false;

                });
            }

            
        }

        function Add() {
            $scope.Product.id = 0;
            $("#img-logo").attr('src','');
           
            $scope.Product.Name = "";
        }

    }
})(angular.module('pittmask.common'));