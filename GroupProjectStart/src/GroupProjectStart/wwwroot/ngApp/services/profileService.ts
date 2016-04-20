namespace GroupProjectStart.Services {
    export class ProfileService {
        public profileResource;
        constructor(private $resource: ng.resource.IResourceService) {
            this.profileResource = $resource('/api/profile/:id');
        }
        public getUsers() {
            return this.profileResource.query();
        }

        public getUser(id) {
           
            return this.profileResource.get({ id: id });
        }

    }
    angular.module('GroupProjectStart').service('profileService', ProfileService);
}