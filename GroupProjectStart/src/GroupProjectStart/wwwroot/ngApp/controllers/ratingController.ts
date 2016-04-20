namespace GroupProjectStart.Controllers {

    export class RatingController {

    // Ratings List Controller

        public ratings;

        constructor(private ratingsService: GroupProjectStart .Services.RatingService) {

            // using the listRating method within the RatingsService to get a list of rating
            this.ratings = this.ratingsService.listRatings();
        }
    }
}


    
