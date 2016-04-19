namespace GroupProjectStart.Controllers {

    export class DeleteCarController {
        public carToDelete;

        constructor(
            private carService: GroupProjectStart.Services.CarService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) { }

        deleteCar() {
            this.carService.deleteCar(this.$stateParams['id']).then(() => {
                this.$state.go('cars');
            });
        }
        cancel() {
            this.$state.go('controller');
        }
    }

}