namespace GroupProjectStart.Controllers {

    export class HomeController {
        public registerUser;
        public validationMessages;
        public file;
        public image;

        public register() {
            debugger;
            this.registerUser.image = this.image;
            this.accountService.register(this.registerUser).then(() => {
                //this.registerUser.image = this.image;
                this.$location.path('/');
                //this.ok();
            }).catch((results) => {
                this.validationMessages = results;
            });
        }
        constructor(private accountService: GroupProjectStart.Services.AccountService,
            private $location: ng.ILocationService) {

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
