/// <reference path="E:\ILearning\LTPM\ASP.NET MVC\GlammyStore\GlammyStore\GlammyStore.Web\Assets/libs/angular/angular.js" />
(function (app) {
    app.module('notifications', ['GlammyStore.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
           .state('notifications', {
               url: "/noti",
               parent: 'base',
               templateUrl: "/app/components/notifications/notificationListView.html",
               controller: "notificationListController"
           }).state('detail', {
               url: "/detail/:id",
               parent: 'base',
               templateUrl: "/app/components/feedbacks/feedbackDetailView.html",
               controller: "feedbackDetailController"
           });
    }
})();