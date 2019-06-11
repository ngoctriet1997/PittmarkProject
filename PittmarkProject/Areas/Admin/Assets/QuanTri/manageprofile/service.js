(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http, notificationService) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        }
        function del(url, data, success, failure) {
            var username = localStorage.username;
            var password = localStorage.password;
            $http.defaults.headers.common.Authorization = 'Basic ' + username + ":" + password;
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                  
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function post(url, data, success, failure) {
            var username = localStorage.username;
            var password = localStorage.password;
            $http.defaults.headers.common.Authorization = 'Basic ' + username + ":" + password;
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                 
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function put(url, data, success, failure) {
            var username = localStorage.username;
            var password = localStorage.password;
            $http.defaults.headers.common.Authorization = 'Basic ' + username + ":" + password;
            $http.put(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (error.status === 401) {
                   
                }
                else if (failure != null) {
                    failure(error);
                }

            });
        }
        function get(url, params, success, failure) {
            var username = localStorage.username;
            var password = localStorage.password;
            $http.defaults.headers.common.Authorization = 'Basic ' + username + ":" + password;
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('pittmask.common'));