namespace GroupProjectStart {

    angular.module('GroupProjectStart', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: GroupProjectStart.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: GroupProjectStart.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: GroupProjectStart.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: GroupProjectStart.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: GroupProjectStart.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: GroupProjectStart.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('contact', {
                url: '/contact',
                templateUrl: '/ngApp/views/contact.html',
                controller: GroupProjectStart.Controllers.ContactController,
                controllerAs: 'controller'
            })

            .state('edit', {
                url: '/edit/:id',
                templateUrl: '/ngApp/views/carEdit.html',
                controller: GroupProjectStart.Controllers.CarsEditController,
                controllerAs: 'controller'
            })
            .state('cars', {
                url: '/cars',
                templateUrl: '/ngApp/views/car.html',
                controller: GroupProjectStart.Controllers.CarsController,
                controllerAs: 'controller'
            })
            .state('carDetail', {
                url: '/car/:id',
                templateUrl: '/ngApp/views/carForm.html',
                controller: GroupProjectStart.Controllers.CarDetailController,
                controllerAs: 'controller'
            })
            .state('carAdd', {
                url: '/carAdd',
                templateUrl: '/ngApp/views/carAdd.html',
                controller: GroupProjectStart.Controllers.CarFormController,
                controllerAs: 'controller'
            })
            .state('carDelete', {
                url: '/deleteCar/:id',
                templateUrl: '/ngApp/views/deleteCar.html',
                controller: GroupProjectStart.Controllers.DeleteCarController,
                controllerAs: 'controller'
            })
            .state('profiles', {
                url: '/profiles',
                templateUrl: 'ngApp/views/profiles.html',
                controller: GroupProjectStart.Controllers.ProfilesController,
                controllerAs: 'controller'
            })
            .state('profile', {
                url: '/profile/:id',
                templateUrl: 'ngApp/views/profile.html',
                controller: GroupProjectStart.Controllers.ProfileController,
                controllerAs: 'controller'
            })
            .state('ratings', {
                url: '/ratings',
                templateUrl: 'ngApp/views/ratings.html',
                controller: GroupProjectStart.Controllers.CarRatingController,
                controllerAs: 'controller'
            })
            .state('driverRatings', {
                url: '/driverRatings',
                templateUrl: 'ngApp/views/driverRatings.html',
                controller: GroupProjectStart.Controllers.DriverRatingController,
                controllerAs: 'controller'
            })
            .state('deleteRating', {
                url: '/delete/:id',
                templateUrl: 'ngApp/views/deleteRating.html',
                controller: GroupProjectStart.Controllers.DeleteDriverRatingController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('GroupProjectStart').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('GroupProjectStart').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
