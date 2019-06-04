(function (app) {


    app.controller('order', order);
    order.$inject = ['$scope', 'apiService','notificationService'];
    function order($scope, apiService, notificationService) {

        $scope.Status = 0;
        $scope.Descript = "";
        $scope.IdProduct = "";
        $scope.CustomerName = "";
        $scope.NumberPhone = "";
        $scope.Address = "";

        $scope.Bill = {};
        $scope.addBill = addBill;
      

        var order = $.connection.orderHub;
        var bill = $.connection.getBillHub; 


        order.client.sendStatus = function (status) {
            if (status == "true") {
                notificationService.displaySuccess('Thêm thành công');
            }
            else {
                notificationService.displayError('Thêm thất bại');
            }
        };

        $.connection.hub.start().done(function () {
           
        });

       
        function addBill() {

           

            $scope.Bill.Descript = $scope.Descript;
            $scope.Bill.IdProduct = $scope.IdProduct;
            $scope.Bill.CustomerName = $scope.CustomerName;
            $scope.Bill.NumberPhone = $scope.NumberPhone;
            $scope.Bill.Address = $scope.Address;
            $scope.Bill.Status = 0;


            if ( $scope.Bill.IdProduct == 0 || $scope.Bill.CustomerName == ""
                || $scope.Bill.NumberPhone == "" || $scope.Bill.Address == "" || $scope.Bill.NumberPhone.length > 15 ) {
                notificationService.displayError('Thêm thất bại');
                return;
            }

       
            order.server.sendBillToAdmin($scope.Bill).done(function (result) {
                if (result > 0) {
                    bill.server.sendBillToAdmin(result);
                }
              
            });
          
            //apiService.post('/Api/Client/Create', $scope.Bill, function (result) {
            //  
               
            //}, function (error) {
            //   
            //});


        }
        


    }
})(angular.module('pittmask.common'));
