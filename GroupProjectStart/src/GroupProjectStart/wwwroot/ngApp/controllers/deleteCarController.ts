namespace GroupProjectStart.Controllers {

    export class DeleteCarController {
        public carToDelete;
        public carId;

        constructor(
            private carService: GroupProjectStart.Services.CarService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id) {
         
        }

        

        deleteCar() {
            this.carService.deleteCar(this.id).then(() => {
                this.ok();
                this.$state.reload();
            });
        }

        public ok() {
            this.$uibModalInstance.close();
        }

        public cancel() {
            this.$uibModalInstance.close();
        }
    }

}