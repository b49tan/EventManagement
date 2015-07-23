var Factories = angular.module('Factories', []);

Factories.service('Broadcaster', function ($http, $rootScope, $log) {
    this.sayGoodbye = function () { $rootScope.$broadcast('topic', { data: 'sampledata' }); };

    this.loginUser = function (loginUser) {
        this.loggedInUser = loginUser;
        $rootScope.$broadcast('loginUser');
    };
});
Factories.factory('HttpRequest', function ($http, $rootScope, $log, $q) {
    var callHttp = function (method, url, getParam, postData) {
        var deferred = $q.defer();

        $http({ url: url, method: method, param: getParam, data: postData })
            .success(function (data, status, headers, config) {
                deferred.resolve({ message: 'Response', 'data': data });
            })
            .error(function (data, status, headers, config) {
                deferred.reject({ message: 'Response', 'data': data });
            });

        return deferred.promise;
    };
    return {
        http: callHttp
    }
})