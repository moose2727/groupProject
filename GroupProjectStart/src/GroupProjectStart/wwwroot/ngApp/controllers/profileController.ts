namespace GroupProjectStart.Controllers {
    export class ProfilesController {
        public users;
        public loaners;

        constructor(
            private profileService: GroupProjectStart.Services.ProfileService) {
            this.users = this.profileService.getUsers();
            this.loaners = this.profileService.getLoaners();

        }
    }

    export class ProfileController {
        public user;
        public car;
        public image;
        public file;
        public carToAdd;

        constructor(
            private profileService: GroupProjectStart.Services.ProfileService,
            private carService: GroupProjectStart.Services.CarService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private $uibModal: ng.ui.bootstrap.IModalService,
            private filepickerService: any,
            private $scope: ng.IScope) {
            this.getUser();
        }

        //public addCarModal(id) {

        //    this.$uibModal.open({
        //        templateUrl: 'ngApp/views/modalViews/carAdd.html',
        //        controller: GroupProjectStart.Controllers.CarFormController,
        //        controllerAs: 'controller',
        //        resolve: {
        //            id: () => id,
        //        },

        //    });
        //}

        saveCar() {
            this.carToAdd.applicationUserId = this.user.id;
            this.carToAdd.image = this.image
            this.carService.saveCar(this.user.id, this.carToAdd).then(() => {
                this.$state.go('cars');
            });
        }

        public pickFile() {
            this.filepickerService.pick({
                mimetype: 'image/*',
            }, this.fileUploaded.bind(this));
        }

        private fileUploaded(file) {
            this.file = file;
            this.$scope.$apply();
            this.image = file.url;
        }
        

        public getUser() {
            let userId = this.$stateParams['id']
            this.user = this.profileService.getUser(userId);
        }


        public activateCar(id) {
            this.carService.getCar(id).then((car) => {
                //debugger;
                car.isActive = true;
                this.carService.saveCar(this.user.id, car).then((data) => {
                    this.$state.reload();
                })
            });
        }

        public deactivateCar(id) {
            //debugger;
            //let car = this.carService.getCar(id);
            //console.log(car);
            this.carService.getCar(id).then((car) => {
                //debugger;
                car.isActive = false;
                this.carService.saveCar(this.user.id, car).then((data) => {
                    this.$state.reload();
                })
            });
            //console.log(this.car)

            //this.getCar(id).then(() => {
            //    this.$state.reload();
            //})

            //this.carService.saveCar(this.car).then((data) => {
            //    this.$state.reload();
            //})
        }
    }
}