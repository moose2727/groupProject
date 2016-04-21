namespace GroupProjectStart.Services {

    export class RatingService {
       

        
            private RatingsResource;

            constructor(private $resource: ng.resource.IResourceService) {
                // adds an object that has connectiong to /api/Ratings/:id to this.RatingResource so that it can utilize the $resource methods such as get(), query(), save(), delete().
                this.RatingsResource = this.$resource('/api/ratings/:id');
            }

            // Method that queries a list of Rating - returns an array of Ratings
            listRatings() {
                return this.RatingsResource.query();
            }

            // Method that will let you save a Rating - sends the data to the serverside action method which will actually save the rating to the database
            save(data) {
                return this.RatingsResource.save(data).$promise;
            }

            // Method that will get a single movie
            getRating(id) {
                return this.RatingsResource.get({ id: id });
            }

            // Method that will delete a movie
            deleteRating(id) {
                return this.RatingsResource.delete({ id: id }).$promise;
            }


    }

    angular.module("GroupProjectStart").service("ratingService", RatingService);
}