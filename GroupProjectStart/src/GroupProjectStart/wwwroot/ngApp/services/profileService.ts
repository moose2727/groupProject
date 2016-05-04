namespace GroupProjectStart.Services {
    export class ProfileService {
        public profileResource;
        constructor(private $resource: ng.resource.IResourceService) {
            this.profileResource = $resource('/api/profile/:id', null, {
                getLoaners: {
                    method: 'GET',
                    url: '/api/profile/getLoaners',
                    isArray: true
                }
            });
        }
        public getUsers() {
            return this.profileResource.query();
        }

        public getUser(id) {
           
            return this.profileResource.get({ id: id });
        }

        public updateUser(userToUpdate) {
            return this.profileResource.save(userToUpdate);
        }
    }
    angular.module('GroupProjectStart').service('profileService', ProfileService);
}