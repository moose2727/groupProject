namespace GroupProjectStart.Services {

    export class ReviewService {
        private reviewResource;

        constructor(private $resource: angular.resource.IResourceService) {
            this.reviewResource = this.$resource("/api/reviews/:id");


        }
        getReviews() {
            return this.reviewResource.query()
        }

        
        getReview(id) {
            return this.reviewResource.get({ id: id }).$promise;
        }

        saveCarReview(id, reviewToSave) {
            return this.reviewResource.save(id, reviewToSave).$promise;
        }

        saveDriverReview(id, reviewToSave) {
            return this.reviewResource.save(reviewToSave).$promise;
        }

        deleteReview(id) {
            return this.reviewResource.delete({ id: id }).$promise;
        }
    }
    angular.module("GroupProjectStart").service('reviewService', ReviewService);
}