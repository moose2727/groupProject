namespace GroupProjectStart.Services {

    export class CarReviewService {
        private reviewResource;

        constructor(private $resource: angular.resource.IResourceService) {
            this.reviewResource = this.$resource("/api/carReviews/:id");


        }
        getCarReviews() {
            return this.reviewResource.query()
        }

        
        getCarReview(id) {
            return this.reviewResource.get({ id: id }).$promise;
        }

        saveCarReview(id, reviewToSave) {
            return this.reviewResource.save({ id: id }, reviewToSave).$promise;
        }


        deleteCarReview(id) {
            return this.reviewResource.delete({ id: id }).$promise;
        }
    }
    angular.module("GroupProjectStart").service('carReviewService', CarReviewService);
}