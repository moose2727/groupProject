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

        //gets all users
        public getUsers() {
            return this.profileResource.query();
        }

        //gets single user
        public getUser(id) {  
            return this.profileResource.get({ id: id });
        }

        //updates user info
        public updateUser(userToUpdate) {
            return this.profileResource.save(userToUpdate);
        }
    }
    angular.module('GroupProjectStart').service('profileService', ProfileService);
}