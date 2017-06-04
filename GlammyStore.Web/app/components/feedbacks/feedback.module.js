/// <reference path="E:\ILearning\LTPM\ASP.NET MVC\GlammyStore\GlammyStore\GlammyStore.Web\Assets/libs/angular/angular.js" />
(function () {
    angular.module('GlammyStore.feedbacks', ['GlammyStore.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('feedbacks', {
                url: "/feedbacks",
                parent: 'base',
                templateUrl: "/app/components/feedbacks/feedbackListView.html",
                controller: "feedbackListController"
            }).state('detail', {
                url: "/detail/:id",
                parent: 'base',
                templateUrl: "/app/components/feedbacks/feedbackDetailView.html",
                controller: "feedbackDetailController"
            });
    }
})();