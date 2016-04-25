namespace GroupProjectStart.Services {
    export class UserCarsService {
        public userCarsResource;

        constructor(private $resource: ng.resource.IResourceService) {
        
            this.userCarsResource = $resource("/api/userCars/:id");
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