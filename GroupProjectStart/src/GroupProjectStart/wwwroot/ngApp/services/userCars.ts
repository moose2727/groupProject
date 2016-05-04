namespace GroupProjectStart.Services {
    export class UserCarsService {
        public userCarsResource;

        constructor(private $resource: ng.resource.IResourceService) {
        
            this.userCarsResource = $resource("/api/userCars/:id");
        }

        getCarPage(page) {
            let randomResource = this.$resource('/api/userCars/browse');
            return randomResource.query({ page: page }).$promise;
        }

        getTotalCars() {
            let carResource = this.$resource('/api/userCars/totalcount');
            return carResource.query().$promise;
        }

        public getUserCars() {
            return this.userCarsResource.query();
        }

        public getUser(id) {

            return this.userCarsResource.get({ id: id });
        }

       
    }
    angular.module('GroupProjectStart').service('userCarsService', UserCarsService);
}