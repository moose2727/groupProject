namespace GroupProjectStart.Controllers {

    export class CarDetailController {
        public carDetail;

        constructor(
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private carService: GroupProjectStart.Services.CarService
        ) {
            
            this.getCar();
        }

        getCar() {


            let carId = this.$stateParams['id'];
            this.carDetail = this.carService.getCar(carId);
            
        }

    }

}