namespace GroupProjectStart.Controllers {



    export class CarsEditController {

        public carToEdit;
        public userId;

        constructor(
            private carService: GroupProjectStart.Services.CarService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private profileService: GroupProjectStart.Services.ProfileService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id) {

            // extracts the car id from the url using $stateParams
            this.userId == this.$stateParams['id']
            this.carToEdit = this.carService.getCar(this.id);
            
        }
        editCar() {
            this.carService.saveCar(this.$stateParams['id'], this.carToEdit).then(() => {
                this.close();
                this.$state.reload();
            });
        }
        close() {
            this.$uibModalInstance.close();
        }
    }
}