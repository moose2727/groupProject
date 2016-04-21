namespace GroupProjectStart.Controllers {

    export class CarsController {
        public cars;
       

        constructor(private carService: GroupProjectStart.Services.CarService,
            private $uibModal: ng.ui.bootstrap.IModalService) {
            this.cars = this.carService.getCars();
           
        }

        public carRateModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/rateCar.html',
                controller: GroupProjectStart.Controllers.CreateCarRatingController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }

    }

    export class CarFormController {
        public carToAdd;

        constructor(
            private carService: GroupProjectStart.Services.CarService,
            private $state: ng.ui.IStateService) {
            
        }

        saveCar() {
            this.carService.saveCar(this.carToAdd).then(() => {
                this.$state.go('cars');
            });
        }

        cancel() {
            this.$state.go('cars');
        }
    }


}