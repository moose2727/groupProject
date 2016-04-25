namespace GroupProjectStart.Controllers {

    export class UserCarsController {
        public users;

        constructor(
            private userCarsService: GroupProjectStart.Services.UserCarsService, private $uibModal: ng.ui.bootstrap.IModalService) {
            this.users = this.userCarsService.getUserCars();
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

        public driverRateModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/rateDriver.html',
                controller: GroupProjectStart.Controllers.CreateDriverRatingController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }
    }

    export class UserCarController {
        public user;
        public car;

        constructor(
            private userCarsService: GroupProjectStart.Services.UserCarsService,
            private carService: GroupProjectStart.Services.CarService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.getUser();
        }

        public getUser() {
            let userId = this.$stateParams['user'];
            let carId = this.$stateParams['car'];
            this.user = this.userCarsService.getUser(userId);
            this.car = this.carService.getCar(carId);
        }
    }
}