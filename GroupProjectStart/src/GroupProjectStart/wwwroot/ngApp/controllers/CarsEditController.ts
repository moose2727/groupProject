namespace GroupProjectStart.Controllers {



    export class CarsEditController {

        public carToEdit;

        constructor(private carService: GroupProjectStart.Services.CarService,
            private $stateParams: ng.ui.IStateParamsService) {

            // extracts the car id from the url using $stateParams
            let carid = this.$stateParams['id'];
            this.carToEdit = this.carService.getCar(carid);

        }
    }
}