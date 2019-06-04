(function (app) {


    app.controller('manageBill', manageBill);
    manageBill.$inject = ['$scope', 'apiService', 'notificationService'];
    function manageBill($scope, apiService, notificationService) {

        $scope.Bill = {};

        $scope.getBill = getBill;

        $scope.Bills = [];

        $scope.MaxPage;
        $scope.Page;
        $scope.TotalCount;
        $scope.TotalPages;

        $scope.PageLoop;


        $scope.deleteList = [];

        $scope.getAll = getAll;
        $scope.updateBill = updateBill;


        $scope.deleteById = deleteById;
        $scope.addOrRemoveIdList = addOrRemoveIdList;
        $scope.addOrRemoveList=addOrRemoveList;

        $scope.range = function (min, max, step) {
            step = step || 1;
            var input = [];
            for (var i = min; i <= max; i += step) {
                input.push(i);
            }
            return input;
        };

        var bills = $.connection.getBillHub;
        bills.client.getBill = function (result) {
          
            notificationService.displaySuccess('Bạn nhận được một đơn đặt hàng mới');
            $scope.$apply(function () {
                $scope.Bills.unshift(result);
            });
           
         
        };
        $.connection.hub.start().done(function () {
            bills.server.joinGroup();
        });
        apiService.post('/Admin/Home/GetUserLogin', null, function (result) {
          

        }, function (errors) {
        });
        function getBill(id) {
            var config = { params: { id: id } };

            apiService.get('/Api/Bill/Get',config, function (result) {
                notificationService.displaySuccess('Lấy thành công');
      

                $scope.Bill.Status = result.data.Status;
                $scope.Bill.Address = result.data.Address;
                $scope.Bill.CustomerName = result.data.CustomerName;
                $scope.Bill.Descript = result.data.CustomerName;
                $scope.Bill.Id = result.data.Id;
                $scope.Bill.IdProduct = result.data.IdProduct;
                $scope.Bill.NumberPhone = result.data.NumberPhone;
                $scope.Bill.OrderDate = result.data.OrderDate;
                $scope.Bill.Price = result.data.Price;
                $scope.Bill.ProductName = result.data.ProductName;
                $scope.Bill.Delete = false;

               
            }, function (error) {
                notificationService.displayError('Lấy thất bại');
            });
        }
        getAll(1);
        function getAll(page) {
             
            var config = {
                params: { page: page, pageSize: 10, maxPage: 4 }
            };

            apiService.get('/Api/Bill/GetAll', config, function (result) {
                notificationService.displaySuccess('Lấy thành công');
               


                $scope.Bills = result.data.Items;

                angular.forEach($scope.Bills, function (value, key) {
                 
                    value.Delete = false;
                   
                });


                $scope.MaxPage = result.data.MaxPage;
                $scope.Page = result.data.Page;
                $scope.TotalCount = result.data.TotalCount;
                $scope.TotalPages = result.data.TotalPages;

                if ($scope.TotalPages - $scope.Page > $scope.MaxPage) {
                    $scope.PageLoop = $scope.MaxPage;
                }
                else {
                    $scope.PageLoop = $scope.TotalPages - $scope.Page;
                }
                
             

              
              

            }, function (error) {
                notificationService.displayError('Lấy thất bại');
            });
        }

        function updateBill() {
          
            var data = {
                Id: $scope.Bill.Id, Status: $scope.Bill.Status,
            };

            apiService.put('/Api/Bill/Update', data, function (result) {
                
                angular.forEach($scope.Bills, function (value, key) {
                    if (value.Id == $scope.Bill.Id) {
                        value.Status = $scope.Bill.Status;
                    }
                });
                notificationService.displaySuccess('Lưu thành công');
            }, function (error) {
                notificationService.displayError('Lưu thất bại');

                });
        }
        function deleteById() {
           
            var count = 0;
            for (var i = 0; i < $scope.Bills.length; i++) {
                if ($scope.Bills[i].Delete == true) {
                    count++;
                    var config = {
                        params: { id: $scope.Bills[i].Id }
                    };
                    apiService.del('/Api/Bill/Delete', config, function (result) {


                        notificationService.displaySuccess("Xóa thành công");
                        if (count == $scope.Bills.length && $scope.Page != 1) {
                            getAll($scope.Page - 1);
                        }
                        else {
                            getAll($scope.Page);
                        }
                      
                    }, function (error) {
                        notificationService.displayError('Xóa thất bại');

                    });
                }
            }
          
        }
        function addOrRemoveIdList(id) {

          
            angular.forEach($scope.Bills, function (value, key) {
                if (value.Id == id) {
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
                angular.forEach($scope.Bills, function (value, key) {
                   
                    value.Delete = true;

                });
            }
            else {
                $('#cbkAll').data('check', false);
                angular.forEach($scope.Bills, function (value, key) {
                 
                    value.Delete = false;

                });
            }
           
          
        }
    }
})(angular.module('pittmask.common'));
