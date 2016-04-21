namespace GroupProjectStart.Controllers {

    export class AccountController {
        public externalLogins;

        public getUserName() {
            return this.accountService.getUserName();
        }

        public getClaim(type) {
            return this.accountService.getClaim(type);
        }

        public isLoggedIn() {
            return this.accountService.isLoggedIn();
        }

        public logout() {
            this.accountService.logout();
            this.$location.path('/');
        }

        public getExternalLogins() {
            return this.accountService.getExternalLogins();
        }

        public showSignInModal(x) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/login.html',
                controller: GroupProjectStart.Controllers.LoginController,
                controllerAs: 'controller',
                resolve: {
                    x: () => x,

                },
                size: 'lg'
            });

        }
        public showSignUpModal(x) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/signUp.html',
                controller: GroupProjectStart.Controllers.RegisterController,
                controllerAs: 'controller',
                resolve: {
                    x: () => x,

                },
                size: 'lg'
            });

        }



        constructor(private accountService: GroupProjectStart.Services.AccountService, private $location: ng.ILocationService, private $uibModal: ng.ui.bootstrap.IModalService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService) {
            this.getExternalLogins().then((results) => {
                this.externalLogins = results;
            });
        }
        cancel() {

            this.$state.go('/');
        }
    }

    angular.module('GroupProjectStart').controller('AccountController', AccountController);


    export class LoginController {
        public loginUser;
        public validationMessages;

        public login() {
            this.accountService.login(this.loginUser).then(() => {
                this.$location.path('/');
                this.ok();
            }).catch((results) => {
                this.validationMessages = results;
            });
        }

        public ok() {

            this.$uibModalInstance.close();

        }

        constructor(private accountService: GroupProjectStart.Services.AccountService, private $location: ng.ILocationService, private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance, private $state: ng.ui.IStateService, private x, private $stateParams: ng.ui.IStateParamsService) { }
    }


    export class RegisterController {
        public registerUser;
        public validationMessages;
        public file;
        public image;

        public register() {
            debugger;
            this.registerUser.image = "https://process.filepicker.io/Ay0qe4wR6efe0Ua2XZC5wz/resize=width:400,height:200/" + this.image;
            this.accountService.register(this.registerUser).then(() => {
                //this.registerUser.image = this.image;
                this.$location.path('/');
                //this.ok();
            }).catch((results) => {
                this.validationMessages = results;
            });
        }

        //public ok() {

        //    this.$uibModalInstance.close();

        //}

        public pickFile() {
            this.filepickerService.pick({
                mimetype: 'image/*',
                cropRatio: 4/4,
            }, this.fileUploaded.bind(this));
        }

        private fileUploaded(file) {
            this.file = file;
            this.$scope.$apply();
            this.image = file.url;
        }

        constructor(
            private accountService: GroupProjectStart.Services.AccountService,
            private $location: ng.ILocationService,
            //private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            //private x,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private filepickerService: any,
            private $scope: ng.IScope) { }
    }





    export class ExternalRegisterController {
        public registerUser;
        public validationMessages;

        public register() {
            this.accountService.registerExternal(this.registerUser.email)
                .then((result) => {
                    this.$location.path('/');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }

        constructor(private accountService: GroupProjectStart.Services.AccountService, private $location: ng.ILocationService) {}

    }

    export class ConfirmEmailController {
        public validationMessages;

        constructor(
            private accountService: GroupProjectStart.Services.AccountService,
            private $http: ng.IHttpService,
            private $stateParams: ng.ui.IStateParamsService,
            private $location: ng.ILocationService
        ) {
            let userId = $stateParams['userId'];
            let code = $stateParams['code'];
            accountService.confirmEmail(userId, code)
                .then((result) => {
                    this.$location.path('/');
                }).catch((result) => {
                    this.validationMessages = result;
                });
        }
    }

}
