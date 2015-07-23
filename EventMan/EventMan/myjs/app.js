var EventApp = angular.module('EventApp', ['Factories', 'ngRoute']);

EventApp.config(function ($routeProvider) {
    $routeProvider.
        when('/', { controller: 'Home', templateUrl: '/templates/homePage.html' }).
        when('/Home', { controller: 'Home', templateUrl: '/templates/homePage.html' }).
        when('/Events', { controller: 'Events', templateUrl: '/templates/eventSummary.html' }).
        when('/StakeHolders', { controller: 'StakeHolders', templateUrl: '/templates/stakeHolderSummary.html' }).
        when('/Register', { controller: 'Register', templateUrl: '/templates/register.html' }).
        when('/Sponsors', { controller: 'Sponsor', templateUrl: '/templates/sponsor.html' }).
        when('/OurTeam', { controller: 'OurTeam', templateUrl: '/templates/ourTeamSummary.html' }).
        when('/Service', { controller: 'Home', templateUrl: '/templates/service.html' }).
        when('/Portfolio', { controller: 'Home', templateUrl: '/templates/portfolio.html' }).
        when('/About', { controller: 'About', templateUrl: '/templates/about.html' }).
        when('/Clients', { controller: 'Home', templateUrl: '/templates/clients.html' }).
        when('/Price', { controller: 'Home', templateUrl: '/templates/price.html' }).
        when('/Contact', { controller: 'Home', templateUrl: '/templates/contact.html' }).

        otherwise({ redirectTo: '/' });
});

EventApp.controller('Home', function ($scope, $location) {
    $scope.test = "testing";
});

EventApp.controller('About', function ($scope, $location, HttpRequest, $log) {
    $scope.team = [];

    HttpRequest.http('GET', '/api/StakeHolder?type=2' , {})
        .then(function (success) {
            $scope.team = success.data;
            $log.log(success);
        }, function (error) {
            $log.log(error);
        });

});


EventApp.controller('Events', function ($scope, $location, HttpRequest, $log, Broadcaster, $rootScope) {

    $scope.events = [];
    $scope.managers = ['kamla', 'nehru'];

    HttpRequest.http('GET', '/api/Event', {})
        .then(function (success) {

            $scope.AllEvents = success.data;
            $scope.events = $scope.AllEvents;
            $log.log(success);
        }, function (error) {
            $log.log(error);
        });
    $scope.events = $scope.AllEvents;

    //Logged in user's participating event list
    $rootScope.$on('loginUser', function () {
        $scope.updateMyEvent();
    });

    $scope.updateMyEvent = function () {
        $scope.loggedInUser = Broadcaster.loggedInUser;
        if ($scope.loggedInUser != null && $scope.loggedInUser != undefined) {
            HttpRequest.http('GET', '/api/Event?stakeHolderid=' + $scope.loggedInUser.Id, {})
            .then(function (success) {
                $scope.myEventList = success.data;
                $scope.eventFilter();
                $log.log(success);
            }, function (error) {
                $log.log(error);
                $scope.myEventList = [];
            });
        }
    }
    
    $scope.eventFilter = function (choice) {
        switch (choice) {
            case 0:
                $scope.events = $scope.AllEvents;
                break;
            case 1:
                $scope.events = [];
                for (event in $scope.AllEvents) 
                    if ($scope.myEventList.indexOf($scope.AllEvents[event].Id) >= 0)
                        $scope.events.push($scope.AllEvents[event]);
                break;
        }
    }

    $scope.plussed = function (eventId) {
        $scope.plussedEventId = eventId;
    }
    $scope.unplussed = function (eventId) {

        $scope.plussedEventId = {};
        $scope.plussedEventId = {};
    }
    $scope.isPlussed = function (eventId) {
        return $scope.plussedEventId == eventId;
    }

    $scope.updateMyEvent();

     
     HttpRequest.http('GET', '/api/StakeHolder', {})
        .then(function (success) {
            $scope.managers = success.data;
            $log.log(success);
        }, function (error) {
            $log.log(error);
        });
});


EventApp.controller('StakeHolders', function ($scope, $location, HttpRequest, $log, Broadcaster) {
    $scope.test = "testing";

    HttpRequest.http('GET', '/api/StakeHolder', {})
       .then(function (success) {
           $scope.stakeHolders = success.data;
           $log.log(success);
       }, function (error) {
           $log.log(error);
       });
});

EventApp.controller('Register', function ($scope, $location, HttpRequest, $log, Broadcaster) {
    $scope.test = "testing";

    $scope.createdMessage = "Successfully created! Please login now";
    $scope.register = function () {
        var data = {};
        data.Username = $scope.username;
        data.Name = $scope.name;
        data.Email = $scope.email;
        data.Password = $scope.password;
        data.Type = 1;
        data.Mobile = $scope.mobile;

        HttpRequest.http('POST', '/api/StakeHolder', {}, JSON.stringify(data) )
        .then( function(success){
            $log.log(success);
            $scope.createdMessage = "Successfully <strong>created</strong>! Please login now";
        }, function(error){
            $log.log(error);
            $scope.createdMessage = "<strong>Failed</strong> to create, try with different username";

        });
    }

    $scope.welcomeMessage = "";
    $scope.login = function () {
        var data = {};
        data.Username = $scope.username;
        data.Email = $scope.email;
        data.Password = $scope.password;
        data.Mobile = $scope.mobile;

        
        $scope.welcomeMessage = "Logging in, please wait";
        HttpRequest.http('POST', '/api/Login', {}, JSON.stringify(data))
        .then(function (success) {
            $log.log(success);
            $scope.welcomeMessage = "User <strong>successfully</strong> logged in";
            if (success.data.length > 0) {
                $scope.loginUser = success.data[0];
                Broadcaster.loginUser($scope.loginUser);
            }
            else
                $scope.welcomeMessage = "Re-check your details and <strong>try again</strong>";
        }, function (error) {
            $log.log(error);
        });
    }
});


EventApp.controller('MenuCtrl', function ($scope, $log, Broadcaster, HttpRequest, $rootScope) {
    $scope.menuOptions = ['Events', 'StakeHolders', 'Register','Sponsors'];
    $log.log(Broadcaster.sayGoodbye());

    $scope.loggedInUser = Broadcaster.loggedInUser;
    $rootScope.$on('loginUser', function () {
        $scope.loggedInUser = Broadcaster.loggedInUser;
        $scope.loggedInMessage = "Welcome" + $scope.loggedInUser.Name;
    });
    $scope.IsLoggedIn = function () {
        if ($scope.loggedInUser != null || $scope.loggedInUser != undefined) {
            $scope.loggedInMessage = "Welcome " + $scope.loggedInUser.Name + "!";
            return true;
        }
        else {
            $scope.loggedInMessage = "";
            return false;
        }
    }
    HttpRequest.http('GET', '/api/Event', {})
        .then( function(success){
            $log.log(success);
        }, function(error){
            $log.log(error);
        });

    HttpRequest.http('GET', '/api/StakeHolder', {})
        .then(function (success) {
            $log.log(success);
        }, function (error) {
            $log.log(error);
        });

    $scope.$on('topic', function (event, data) {
        $log.log(data); // 'Data to send'
    });

});

EventApp.controller('Sponsor', function ($scope, $location, HttpRequest, $log) {

    HttpRequest.http('GET', '/api/Sponsor', {})
    .then(function (success) {
        $scope.sponsors = success.data;
        $log.log(success);
    }, function (error) {
        $log.log(error);
    });


    $scope.plussed = function (eventId) {
        $scope.plussedEventId = eventId;
    }
    $scope.unplussed = function (eventId) {
        $scope.plussedEventId = {};
        $scope.plussedEventId = {};
    }
    $scope.isPlussed = function (eventId) {
        return $scope.plussedEventId == eventId;
    }
});

/*
EventApp.controller('ListCtrl', function ($scope, $location) {
    $scope.test = "testing";
});
*/

/*

    HttpRequest.http('GET', 'http://www.google.com', {})
        .then(function (success) {
            $log.log(success);
        }, function (error) {
            $log.log(error);
        });
    HttpRequest.http('GET', 'http://localhost:5852/api/Event', {})
        .then(function (success) {
            $log.log(success);
        }, function (error) {
            $log.log(error);
        });
        */