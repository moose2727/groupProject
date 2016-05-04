namespace GroupProjectStart.Controllers {

    export class HomeController {
        public registerUser;
        public validationMessages;
        public file;
        public image;

        public register() {

            this.registerUser.image = this.image;
            this.accountService.register(this.registerUser).then(() => {
                this.$location.path('/');
                this.$state.go('userCars')
            }).catch((results) => {
                this.validationMessages = results;
            });
        }

        public pickFile() {
            this.filepickerService.pick({
                mimetype: 'image/*',
                cropRatio: 4 / 4,
            }, this.fileUploaded.bind(this));
        }

        private fileUploaded(file) {
            this.file = file;
            this.$scope.$apply();
            this.image = file.url;
        }

        constructor(private accountService: GroupProjectStart.Services.AccountService,
            private $location: ng.ILocationService, private filepickerService: any,
            private $scope: ng.IScope,
            private $state: ng.ui.IStateService) {

        }

    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }
    export class ContactController {
        public contact;


    }



    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
