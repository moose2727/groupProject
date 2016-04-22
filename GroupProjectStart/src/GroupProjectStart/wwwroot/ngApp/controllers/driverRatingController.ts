namespace GroupProjectStart.Controllers {

    export class DriverRatingController {
        public driverRatings;

        constructor(private driverRatingService: GroupProjectStart.Services.DriverRatingService) {
            this.driverRatings = this.driverRatingService.ratingList();
        }
    }

    export class DeleteDriverRatingController {
        public ratingToDelete;
        public user;

        constructor(
            private driverRatingService: GroupProjectStart.Services.DriverRatingService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.user = this.$stateParams['id'];
        }

        deleteRating() {
            this.driverRatingService.deleteRating(this.$stateParams['id']);
        }
    }

    export class CreateDriverRatingController {
        public ratingToCreate;
        public userId;

        constructor(
            private driverRatingService: GroupProjectStart.Services.DriverRatingService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {

        }

        saveRating() {
            this.driverRatingService.saveDriverRating(this.ratingToCreate);
        }
    }

    export class EditDriverRatingController {
        public ratingToEdit;
        public userId;

        constructor(
            private driverRatingService: GroupProjectStart.Services.DriverRatingService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.ratingToEdit = this.driverRatingService.getRating(this.$stateParams['id']);
        }

        editRating() {
            this.driverRatingService.saveDriverRating(this.ratingToEdit);
        }
    }

}