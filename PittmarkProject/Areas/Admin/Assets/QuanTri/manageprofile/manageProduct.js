
(function (app) {


    app.controller('manageProduct', manageProduct);
    manageProduct.$inject = ['$scope', 'apiService', 'notificationService'];
    function manageProduct($scope, apiService, notificationService) {

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



            apiService.get('/Api/Product/GetAll', "", function (result) {
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

            apiService.get('/Api/Product/GetById', config, function (result) {
                notificationService.displaySuccess('Lấy thành công');
               

                $scope.Product.Descript = result.data.Descript;
                $scope.Product.Name = result.data.Name;
                $scope.Product.Price = result.data.Price;
                $scope.Product.id = result.data.id;

                $scope.Product.Delete = false;


            }, function (error) {
                notificationService.displayError('Lấy thất bại');
            });
        }

        function update() {

            var data = {
                Descript: $scope.Product.Descript,
                Name: $scope.Product.Name,
                Price: $scope.Product.Price,
                id: $scope.Product.id

            };

           
            apiService.put('/Api/Product/Update', data, function (result) {

                angular.forEach($scope.Products, function (value, key) {
                    if (value.id == $scope.Product.id) {

                            value.Descript = $scope.Product.Descript,
                            value.Name = $scope.Product.Name,
                            value.Price = $scope.Product.Price,
                            value.id = $scope.Product.id
                    }
                });
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
                    apiService.del('/Api/Product/DeleteById', config, function (result) {


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
            $scope.Product.Descript = "";
            $scope.Product.Price = 0;
            $scope.Product.Name = "";
        }

    }
})(angular.module('pittmask.common'));