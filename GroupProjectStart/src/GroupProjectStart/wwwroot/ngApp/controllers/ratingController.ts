namespace GroupProjectStart.Controllers {

    export class RatingController {

    // Ratings List Controller

        public ratings;

        constructor(private ratingsService: GroupProjectStart.Services.RatingService) {

            // using the listRating method within the RatingsService to get a list of rating
            this.ratings = this.ratingsService.listRatings();
        }
        // Method that queries a list of Rating - returns an array of Ratings
        listRatings() {
            this.ratings = this.ratingsService.listRatings;
        }
      
        // Method that will let you save a Rating - sends the data to the serverside action method which will actually save the rating to the database
        save(data) {
             this.ratingsService.save(data).$promise;
        }
        // Method that will delete a rating
        deleteRating(id) {
             this.ratingsService.deleteRating({ id: id }).$promise;
        }

    }
}


    
