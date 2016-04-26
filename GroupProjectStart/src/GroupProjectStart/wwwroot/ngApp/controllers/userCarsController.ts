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
        public carReviews;
        public userReviews;

        constructor(
            private userCarsService: GroupProjectStart.Services.UserCarsService,
            private carReviewService: GroupProjectStart.Services.CarReviewService,
            private carService: GroupProjectStart.Services.CarService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private $uibModal: ng.ui.bootstrap.IModalService
        ) {
            this.getUser();
        }

        public getUser() {
            
            let userId = this.$stateParams['user'];
            let carId = this.$stateParams['car'];
            this.user = this.userCarsService.getUser(userId);
            this.car = this.carService.getCar(carId);
        }

        public carReviewModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/carReviewAdd.html',
                controller: GroupProjectStart.Controllers.CreateCarReviewController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }

        public driverReviewModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/driverReviewAdd.html',
                controller: GroupProjectStart.Controllers.CreateDriverReviewController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }
    }
}