﻿namespace GroupProjectStart.Controllers {
    export class ProfilesController {
        public users;

        constructor(
            private profileService: GroupProjectStart.Services.ProfileService) {
            this.users = this.profileService.getUsers();

        }
    }

    export class ProfileController {
        public user;
        constructor(
            private profileService: GroupProjectStart.Services.ProfileService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.getUser();
        }

        public getUser() {
            let userId = this.$stateParams['id']
            this.user = this.profileService.getUser(userId);
        }
    }
}