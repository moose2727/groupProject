namespace GroupProjectStart.Controllers {

    export class BecomeLoanerController {

        public user;
        public userId;

        constructor(
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private profileService: GroupProjectStart.Services.ProfileService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id,
            private $window: ng.IWindowService) {
            this.userId = this.id;
            this.user = this.profileService.getUser(this.userId);
        }

        public upgradeUser() {
            debugger;
            this.user.isLoaner = true;
            this.profileService.updateUser(this.user);
            this.close();
        }

        public close() {
            this.$uibModalInstance.close();
            this.$window.location.reload();

        }
    }

    export class RemoveLoanerController {
        public user;
        public userId;

        constructor(
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private profileService: GroupProjectStart.Services.ProfileService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id,
            private $window: ng.IWindowService) {
            this.userId = this.id;
            this.user = this.profileService.getUser(this.userId);
        }

        public downgradeUser() {
            debugger;
            this.user.isLoaner = false;
            this.profileService.updateUser(this.user);
            this.close();
        }

        public close() {
            this.$uibModalInstance.close();
            this.$window.location.reload();
        }
    }
}