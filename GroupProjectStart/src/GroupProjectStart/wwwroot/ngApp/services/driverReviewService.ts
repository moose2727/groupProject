namespace GroupProjectStart.Services {

    export class DriverReviewService {
        private reviewResource;

        constructor(private $resource: angular.resource.IResourceService) {
            this.reviewResource = this.$resource("/api/driverReviews/:id");


        }
        getDriverReviews() {
            return this.reviewResource.query()
        }


        getDriverReview(id) {
            return this.reviewResource.get({ id: id }).$promise;
        }

        saveDriverReview(id, reviewToSave) {
            return this.reviewResource.save({ id: id }, reviewToSave).$promise;
        }


        deleteDriverReview(id) {
            return this.reviewResource.delete({ id: id }).$promise;
        }
    }
    angular.module("GroupProjectStart").service('driverReviewService', DriverReviewService);
}