var EventApp = angular.module('EventApp');

EventApp.directive('newsletter', function () {
    return {
        restrict: 'E',
        transclude: true,
        templateUrl: 'templates/newsletter.html'
    };
});