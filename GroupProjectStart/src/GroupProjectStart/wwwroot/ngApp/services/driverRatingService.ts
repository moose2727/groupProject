namespace GroupProjectStart.Services {

    export class DriverRatingService {
        public driverRatingResource;

        constructor(private $resource: ng.resource.IResourceService) {
            this.driverRatingResource = this.$resource('/api/driverRatings/:id');
        }

        ratingList() {
            return this.driverRatingResource.query();
        }

        saveDriverRating(ratingToSave) {
            return this.driverRatingResource.save().$promise;
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