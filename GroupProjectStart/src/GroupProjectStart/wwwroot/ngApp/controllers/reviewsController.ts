namespace GroupProjectStart.Controllers {

    export class CreateCarReviewController {
        public reviewToCreate;
        public carId;

        constructor(
            private carReviewService: GroupProjectStart.Services.CarReviewService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id
        ) {
            this.carId = this.$stateParams['id'];
       
        }

        public ok() {
            this.$uibModalInstance.close();
        }

      

        saveCarReview() {
            
            this.carReviewService.saveCarReview(this.id, this.reviewToCreate).then(() => {
                
                this.ok();
                this.$state.reload();
            });
        }
    }

    export class CreateDriverReviewController {
        public reviewToCreate;
        public userId;

        constructor(
            private driverReviewService: GroupProjectStart.Services.DriverReviewService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id
        ) {
            this.userId = this.$stateParams['id'];
        }

        public ok() {
            this.$uibModalInstance.close();
        }

        saveDriverReview() {
            this.driverReviewService.saveDriverReview(this.id, this.reviewToCreate).then(() => {
                this.ok();
                this.$state.reload();
            });
        }
    }

    export class DeleteCarReviewController {
        public ratingToDelete;
        public carId;

        constructor(
            private carReviewService: GroupProjectStart.Services.CarReviewService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.carId = this.$stateParams['id'];
        }

        deleteCarReview() {
            this.carReviewService.deleteCarReview(this.$stateParams['id']);
        }
    }

    export class DeleteDriverReviewController {
        public ratingToDelete;
        public userId;

        constructor(
            private driverReviewService: GroupProjectStart.Services.DriverReviewService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.userId = this.$stateParams['id'];
        }

        deleteDriverReview() {
            this.driverReviewService.deleteDriverReview(this.$stateParams['id']);
        }
    }

}