namespace GroupProjectStart.Controllers {



    export class CarsEditController {

        public carToEdit;
        public userId;

        constructor(
            private carService: GroupProjectStart.Services.CarService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private profileService: GroupProjectStart.Services.ProfileService) {

            // extracts the car id from the url using $stateParams
            let carid = this.$stateParams['id'];
            this.carToEdit = this.carService.getCar(carid);
        }
        editCar() {
            this.carService.saveCar(this.userId, this.carToEdit).then(() => {
                this.$state.go('cars');
            });
        }
    }
}