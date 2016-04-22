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
        constructor(
            private profileService: GroupProjectStart.Services.ProfileService,
            private carService: GroupProjectStart.Services.CarService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.getUser();
        }

        public getUser() {
            let userId = this.$stateParams['id']
            this.user = this.profileService.getUser(userId);
        }

        public getCar(id) {
            this.car = this.carService.getCar(id);
            
        }

        public activateCar(id) {
            this.carService.getCar(id).then((car) => {
                debugger;
                car.isActive = true;
                this.carService.saveCar(car).then((data) => {
                    this.$state.reload();
                })
            });
        }

        public deactivateCar(id) {
            //debugger;
            //let car = this.carService.getCar(id);
            //console.log(car);
            this.carService.getCar(id).then((car) => {
                debugger;
                car.isActive = false;
                this.carService.saveCar(car).then((data) => {
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