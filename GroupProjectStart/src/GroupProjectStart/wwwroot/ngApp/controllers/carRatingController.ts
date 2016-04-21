namespace GroupProjectStart.Controllers {

    export class CarRatingController {
    // Ratings List Controller
        public ratings;

        constructor(private carRatingService: GroupProjectStart.Services.CarRatingService) {
            // using the listRating method within the RatingsService to get a list of rating
            this.ratings = this.carRatingService.listRatings();
        }
    }

    export class DeleteCarRatingController {
        public ratingToDelete;
        public user;

        constructor(
            private carRatingService: GroupProjectStart.Services.DriverRatingService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService
        ) {
            this.user = this.$stateParams['id'];
        }

        deleteRating() {
            this.carRatingService.deleteRating(this.$stateParams['id']);
        }
    }

    export class CreateCarRatingController {
        public ratingToCreate;
        public userId;

        constructor(
            private carRatingService: GroupProjectStart.Services.DriverRatingService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {

        }

        saveRating() {
            this.carRatingService.saveDriverRating(this.ratingToCreate);
        }
    }

    export class EditCarRatingController {
        public ratingToEdit;
        public userId;

        constructor(
            private carRatingService: GroupProjectStart.Services.DriverRatingService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $state: ng.ui.IStateService,
            private $stateParams: ng.ui.IStateParamsService
        ) {
            this.ratingToEdit = this.carRatingService.getRating(this.$stateParams['id']);
        }

        editRating() {
            this.carRatingService.saveDriverRating(this.ratingToEdit);
        }
    }
}


    
