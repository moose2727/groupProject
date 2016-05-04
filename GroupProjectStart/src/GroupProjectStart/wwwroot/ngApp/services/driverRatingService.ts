namespace GroupProjectStart.Services {

    export class DriverRatingService {
        public driverRatingResource;

        constructor(private $resource: ng.resource.IResourceService) {
            this.driverRatingResource = this.$resource('/api/driverRatings/:id');
        }

        ratingList() {
            return this.driverRatingResource.query();
        }

        saveDriverRating(id, ratingToSave) {
            return this.driverRatingResource.save({ id: id }, ratingToSave).$promise;
        }

        getRating(id) {
            return this.driverRatingResource.delete({ id: id }).$promise;
        }

        deleteRating(id) {
            return this.driverRatingResource.delete({ id: id }).$promise;
        }
    }


    angular.module("GroupProjectStart").service("driverRatingService", DriverRatingService);
}