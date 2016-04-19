var GroupProjectStart;
(function (GroupProjectStart) {
    angular.module('GroupProjectStart', ['ui.router', 'ngResource', 'ui.bootstrap']).config(function ($stateProvider, $urlRouterProvider, $locationProvider) {
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
            .state('edit', {
            url: '/edit/:id',
            templateUrl: '/ngApp/views/carEdit.html',
            controller: GroupProjectStart.Controllers.CarsEditController,
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
    angular.module('GroupProjectStart').factory('authInterceptor', function ($q, $window, $location) {
        return ({
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
        });
    });
    angular.module('GroupProjectStart').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });
})(GroupProjectStart || (GroupProjectStart = {}));
/// <reference path="wwwroot/ngapp/app.ts" />
var GroupProjectStart;
(function (GroupProjectStart) {
    var Controllers;
    (function (Controllers) {
        var AccountController = (function () {
            function AccountController(accountService, $location, $uibModal, $state, $stateParams) {
                var _this = this;
                this.accountService = accountService;
                this.$location = $location;
                this.$uibModal = $uibModal;
                this.$state = $state;
                this.$stateParams = $stateParams;
                this.getExternalLogins().then(function (results) {
                    _this.externalLogins = results;
                });
            }
            AccountController.prototype.getUserName = function () {
                return this.accountService.getUserName();
            };
            AccountController.prototype.getClaim = function (type) {
                return this.accountService.getClaim(type);
            };
            AccountController.prototype.isLoggedIn = function () {
                return this.accountService.isLoggedIn();
            };
            AccountController.prototype.logout = function () {
                this.accountService.logout();
                this.$location.path('/');
            };
            AccountController.prototype.getExternalLogins = function () {
                return this.accountService.getExternalLogins();
            };
            AccountController.prototype.showSignInModal = function (x) {
                this.$uibModal.open({
                    templateUrl: '/ngApp/views/modalViews/login.html',
                    controller: GroupProjectStart.Controllers.LoginController,
                    controllerAs: 'controller',
                    resolve: {
                        x: function () { return x; },
                    },
                    size: 'lg'
                });
            };
            AccountController.prototype.showSignUpModal = function (x) {
                this.$uibModal.open({
                    templateUrl: '/ngApp/views/modalViews/signUp.html',
                    controller: GroupProjectStart.Controllers.RegisterController,
                    controllerAs: 'controller',
                    resolve: {
                        x: function () { return x; },
                    },
                    size: 'lg'
                });
            };
            AccountController.prototype.cancel = function () {
                this.$state.go('/');
            };
            return AccountController;
        }());
        Controllers.AccountController = AccountController;
        angular.module('GroupProjectStart').controller('AccountController', AccountController);
        var LoginController = (function () {
            function LoginController(accountService, $location, $uibModalInstance, $state, x, $stateParams) {
                this.accountService = accountService;
                this.$location = $location;
                this.$uibModalInstance = $uibModalInstance;
                this.$state = $state;
                this.x = x;
                this.$stateParams = $stateParams;
            }
            LoginController.prototype.login = function () {
                var _this = this;
                this.accountService.login(this.loginUser).then(function () {
                    _this.$location.path('/');
                    _this.ok();
                }).catch(function (results) {
                    _this.validationMessages = results;
                });
            };
            LoginController.prototype.ok = function () {
                this.$uibModalInstance.close();
            };
            return LoginController;
        }());
        Controllers.LoginController = LoginController;
        var RegisterController = (function () {
            function RegisterController(accountService, $location, $uibModalInstance, x, $state, $stateParams) {
                this.accountService = accountService;
                this.$location = $location;
                this.$uibModalInstance = $uibModalInstance;
                this.x = x;
                this.$state = $state;
                this.$stateParams = $stateParams;
            }
            RegisterController.prototype.register = function () {
                var _this = this;
                this.accountService.register(this.registerUser).then(function () {
                    _this.$location.path('/');
                    _this.ok();
                }).catch(function (results) {
                    _this.validationMessages = results;
                });
            };
            RegisterController.prototype.ok = function () {
                this.$uibModalInstance.close();
            };
            return RegisterController;
        }());
        Controllers.RegisterController = RegisterController;
        var ExternalRegisterController = (function () {
            function ExternalRegisterController(accountService, $location) {
                this.accountService = accountService;
                this.$location = $location;
            }
            ExternalRegisterController.prototype.register = function () {
                var _this = this;
                this.accountService.registerExternal(this.registerUser.email)
                    .then(function (result) {
                    _this.$location.path('/');
                }).catch(function (result) {
                    _this.validationMessages = result;
                });
            };
            return ExternalRegisterController;
        }());
        Controllers.ExternalRegisterController = ExternalRegisterController;
        var ConfirmEmailController = (function () {
            function ConfirmEmailController(accountService, $http, $stateParams, $location) {
                var _this = this;
                this.accountService = accountService;
                this.$http = $http;
                this.$stateParams = $stateParams;
                this.$location = $location;
                var userId = $stateParams['userId'];
                var code = $stateParams['code'];
                accountService.confirmEmail(userId, code)
                    .then(function (result) {
                    _this.$location.path('/');
                }).catch(function (result) {
                    _this.validationMessages = result;
                });
            }
            return ConfirmEmailController;
        }());
        Controllers.ConfirmEmailController = ConfirmEmailController;
    })(Controllers = GroupProjectStart.Controllers || (GroupProjectStart.Controllers = {}));
})(GroupProjectStart || (GroupProjectStart = {}));
var GroupProjectStart;
(function (GroupProjectStart) {
    var Controllers;
    (function (Controllers) {
        var CarsController = (function () {
            function CarsController(carService) {
                this.carService = carService;
                this.cars = this.carService.getCars();
            }
            return CarsController;
        }());
        Controllers.CarsController = CarsController;
    })(Controllers = GroupProjectStart.Controllers || (GroupProjectStart.Controllers = {}));
})(GroupProjectStart || (GroupProjectStart = {}));
var GroupProjectStart;
(function (GroupProjectStart) {
    var Controllers;
    (function (Controllers) {
        var CarsEditController = (function () {
            function CarsEditController(carService, $stateParams, $state) {
                this.carService = carService;
                this.$stateParams = $stateParams;
                this.$state = $state;
                // extracts the car id from the url using $stateParams
                var carid = this.$stateParams['id'];
                this.carToEdit = this.carService.getCar(carid);
            }
            CarsEditController.prototype.editCar = function () {
                var _this = this;
                this.carService.saveCar(this.carToEdit).then(function () {
                    _this.$state.go('cars');
                });
            };
            return CarsEditController;
        }());
        Controllers.CarsEditController = CarsEditController;
    })(Controllers = GroupProjectStart.Controllers || (GroupProjectStart.Controllers = {}));
})(GroupProjectStart || (GroupProjectStart = {}));
var GroupProjectStart;
(function (GroupProjectStart) {
    var Controllers;
    (function (Controllers) {
        var HomeController = (function () {
            function HomeController() {
                this.message = 'Hello from the home page!';
            }
            return HomeController;
        }());
        Controllers.HomeController = HomeController;
        var SecretController = (function () {
            function SecretController($http) {
                var _this = this;
                $http.get('/api/secrets').then(function (results) {
                    _this.secrets = results.data;
                });
            }
            return SecretController;
        }());
        Controllers.SecretController = SecretController;
        var AboutController = (function () {
            function AboutController() {
                this.message = 'Hello from the about page!';
            }
            return AboutController;
        }());
        Controllers.AboutController = AboutController;
    })(Controllers = GroupProjectStart.Controllers || (GroupProjectStart.Controllers = {}));
})(GroupProjectStart || (GroupProjectStart = {}));
var GroupProjectStart;
(function (GroupProjectStart) {
    var Controllers;
    (function (Controllers) {
        var DeleteCarController = (function () {
            function DeleteCarController(carService, $stateParams, $state) {
                this.carService = carService;
                this.$stateParams = $stateParams;
                this.$state = $state;
            }
            DeleteCarController.prototype.deleteCar = function () {
                var _this = this;
                this.carService.deleteCar(this.$stateParams['id']).then(function () {
                    _this.$state.go('cars');
                });
            };
            DeleteCarController.prototype.cancel = function () {
                this.$state.go('controller');
            };
            return DeleteCarController;
        }());
        Controllers.DeleteCarController = DeleteCarController;
    })(Controllers = GroupProjectStart.Controllers || (GroupProjectStart.Controllers = {}));
})(GroupProjectStart || (GroupProjectStart = {}));
var GroupProjectStart;
(function (GroupProjectStart) {
    var Services;
    (function (Services) {
        var AccountService = (function () {
            function AccountService($q, $http, $window) {
                this.$q = $q;
                this.$http = $http;
                this.$window = $window;
                // in case we are redirected from a social provider
                // we need to check if we are authenticated.
                this.checkAuthentication();
            }
            // Store access token and claims in browser session storage
            AccountService.prototype.storeUserInfo = function (userInfo) {
                // store user name
                this.$window.sessionStorage.setItem('userName', userInfo.userName);
                // store claims
                this.$window.sessionStorage.setItem('claims', JSON.stringify(userInfo.claims));
            };
            AccountService.prototype.getUserName = function () {
                return this.$window.sessionStorage.getItem('userName');
            };
            AccountService.prototype.getClaim = function (type) {
                var allClaims = JSON.parse(this.$window.sessionStorage.getItem('claims'));
                return allClaims ? allClaims[type] : null;
            };
            AccountService.prototype.login = function (loginUser) {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    _this.$http.post('/api/account/login', loginUser).then(function (result) {
                        _this.storeUserInfo(result.data);
                        resolve();
                    }).catch(function (result) {
                        var messages = _this.flattenValidation(result.data);
                        reject(messages);
                    });
                });
            };
            AccountService.prototype.register = function (userLogin) {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    _this.$http.post('/api/account/register', userLogin)
                        .then(function (result) {
                        _this.storeUserInfo(result.data);
                        resolve(result);
                    })
                        .catch(function (result) {
                        var messages = _this.flattenValidation(result.data);
                        reject(messages);
                    });
                });
            };
            AccountService.prototype.logout = function () {
                // clear all of session storage (including claims)
                this.$window.sessionStorage.clear();
                // logout on the server
                return this.$http.post('/api/account/logout', null);
            };
            AccountService.prototype.isLoggedIn = function () {
                return this.$window.sessionStorage.getItem('userName');
            };
            // associate external login (e.g., Twitter) with local user account
            AccountService.prototype.registerExternal = function (email) {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    _this.$http.post('/api/account/externalLoginConfirmation', { email: email })
                        .then(function (result) {
                        _this.storeUserInfo(result.data);
                        resolve(result);
                    })
                        .catch(function (result) {
                        // flatten error messages
                        var messages = _this.flattenValidation(result.data);
                        reject(messages);
                    });
                });
            };
            AccountService.prototype.getExternalLogins = function () {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    var url = "api/Account/getExternalLogins?returnUrl=%2FexternalLogin&generateState=true";
                    _this.$http.get(url).then(function (result) {
                        resolve(result.data);
                    }).catch(function (result) {
                        reject(result);
                    });
                });
            };
            // checks whether the current user is authenticated on the server and returns user info
            AccountService.prototype.checkAuthentication = function () {
                var _this = this;
                this.$http.get('/api/account/checkAuthentication')
                    .then(function (result) {
                    if (result.data) {
                        _this.storeUserInfo(result.data);
                    }
                });
            };
            AccountService.prototype.confirmEmail = function (userId, code) {
                var _this = this;
                return this.$q(function (resolve, reject) {
                    var data = {
                        userId: userId,
                        code: code
                    };
                    _this.$http.post('/api/account/confirmEmail', data).then(function (result) {
                        resolve(result.data);
                    }).catch(function (result) {
                        reject(result);
                    });
                });
            };
            // extract access token from response
            AccountService.prototype.parseOAuthResponse = function (token) {
                var results = {};
                token.split('&').forEach(function (item) {
                    var pair = item.split('=');
                    results[pair[0]] = pair[1];
                });
                return results;
            };
            AccountService.prototype.flattenValidation = function (modelState) {
                var messages = [];
                for (var prop in modelState) {
                    messages = messages.concat(modelState[prop]);
                }
                return messages;
            };
            return AccountService;
        }());
        Services.AccountService = AccountService;
        angular.module('GroupProjectStart').service('accountService', AccountService);
    })(Services = GroupProjectStart.Services || (GroupProjectStart.Services = {}));
})(GroupProjectStart || (GroupProjectStart = {}));
var GroupProjectStart;
(function (GroupProjectStart) {
    var Services;
    (function (Services) {
        var CarService = (function () {
            function CarService($resource) {
                this.$resource = $resource;
                this.carResource = this.$resource("/api/cars/:id");
            }
            CarService.prototype.getCars = function () {
                return this.carResource.query();
            };
            // Method that will get a single car
            CarService.prototype.getCar = function (id) {
                return this.carResource.get({ id: id });
            };
            CarService.prototype.saveCar = function (carToSave) {
                return this.carResource.save(carToSave).$promise;
            };
            CarService.prototype.deleteCar = function (id) {
                return this.carResource.delete({ id: id }).$promise;
            };
            return CarService;
        }());
        Services.CarService = CarService;
        angular.module("GroupProjectStart").service('carService', CarService);
    })(Services = GroupProjectStart.Services || (GroupProjectStart.Services = {}));
})(GroupProjectStart || (GroupProjectStart = {}));
var GroupProjectStart;
(function (GroupProjectStart) {
    var Services;
    (function (Services) {
        console.log("Test");
    })(Services = GroupProjectStart.Services || (GroupProjectStart.Services = {}));
})(GroupProjectStart || (GroupProjectStart = {}));
//# sourceMappingURL=all.js.map