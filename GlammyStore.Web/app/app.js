﻿(function () {
    angular.module('GlammyStore',
        ['GlammyStore.products',
            'GlammyStore.product_categories',
            'GlammyStore.slides',
            'GlammyStore.brands',
            'GlammyStore.application_groups',
            'GlammyStore.application_roles',
            'GlammyStore.application_users',
            'GlammyStore.statistics',
            'GlammyStore.vehicles',
            'GlammyStore.trackorders',
            'GlammyStore.feedbacks',
            'GlammyStore.orders',
            'GlammyStore.common'])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: "",
                templateUrl: "/app/shared/views/baseView.html",
                abstract: true
            })
            .state('login', {
                url: "/login",
                templateUrl: "/app/components/login/loginView.html",
                controller: "loginController"
            })
            .state('home', {
                url: "/home",
                parent: 'base',
                templateUrl: "/app/components/home/homeView.html",
                controller: "homeController"
            });
        $urlRouterProvider.otherwise('/login');
    }
    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {

                    return config;
                },
                requestError: function (rejection) {

                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status === "401") {
                        $location.path('/login');

                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {

                    if (rejection.status === "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
    
})();