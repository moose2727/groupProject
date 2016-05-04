namespace GroupProjectStart.Services {

    export class CarRatingService {
       

        
            private carRatingsResource;

            constructor(private $resource: ng.resource.IResourceService) {
                // adds an object that has connectiong to /api/Ratings/:id to this.RatingResource so that it can utilize the $resource methods such as get(), query(), save(), delete().
                this.carRatingsResource = this.$resource('/api/carRatings/:id');
            }

            // Method that queries a list of Rating - returns an array of Ratings
            listRatings() {
                return this.carRatingsResource.query();
            }

            // Method that will let you save a Rating - sends the data to the serverside action method which will actually save the rating to the database
            saveCarRating(id, ratingToSave) {
                return this.carRatingsResource.save({ id: id }, ratingToSave).$promise;
            }

            // Method that will get a single movie
            getRating(id) {
                return this.carRatingsResource.get({ id: id });
            }

            // Method that will delete a movie
            deleteRating(id) {
                return this.carRatingsResource.delete({ id: id }).$promise;
            }


    }

    angular.module("GroupProjectStart").service("carRatingService", CarRatingService);
}