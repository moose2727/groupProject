namespace GroupProjectStart.Controllers {

    export class CarsController {
        public cars;

        constructor(private carService: GroupProjectStart.Services.CarService) {
            this.cars = this.carService.getCars();

        }

    }

    export class CarFormController {
        public carToAdd;

        constructor(
            private carService: GroupProjectStart.Services.CarService,
            private $state: ng.ui.IStateService) {
            
        }

        saveCar() {
            this.carService.saveCar(this.carToAdd).then(() =>
                this.$state.go('cars'));
        }

        cancel() {
            this.$state.go('cars');
        }
    }


}