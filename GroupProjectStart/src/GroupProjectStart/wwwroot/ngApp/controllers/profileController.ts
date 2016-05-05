namespace GroupProjectStart.Controllers {
    export class ProfilesController {
        public users;
        public loaners;

        constructor(
            private profileService: GroupProjectStart.Services.ProfileService) {
            this.users = this.profileService.getUsers();

        }
    }

    export class ProfileController {
        public user;
        public car;
        public image;
        public file;
        public carToAdd;
        public errorMessages;

        constructor(
            private profileService: GroupProjectStart.Services.ProfileService,
            private carService: GroupProjectStart.Services.CarService,
            private accountService: GroupProjectStart.Services.AccountService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private $uibModal: ng.ui.bootstrap.IModalService,
            private filepickerService: any,
            private $scope: ng.IScope) {
            this.getUser();
        }

        //opens modal to become loaner
        public becomeLoanerModal(id) {
            if (!this.accountService.getClaim('isLoaner')) {
                this.accountService.upgradeUser(this.user.id);
            }
            this.$uibModal.open({
                templateUrl: 'ngApp/views/modalViews/becomeLoaner.html',
                controller: GroupProjectStart.Controllers.BecomeLoanerController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,
                },
                size: 'md'
            });
        }

        //opens modal to remove loaner
        public removeLoanerModal(id) {
            this.accountService.downgradeUser(this.user.id);
            this.$uibModal.open({
                templateUrl: 'ngApp/views/modalViews/removeLoaner.html',
                controller: GroupProjectStart.Controllers.RemoveLoanerController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,
                },
                size: 'md'
            });
        }

        //opens modal to edit profile
        public editProfileModal(id) {
            this.$uibModal.open({
                templateUrl: 'ngApp/views/modalViews/editProfile.html',
                controller: GroupProjectStart.Controllers.EditProfileController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,
                },
                size: 'lg'
            });
        }

        //opens modal to delete car
        public removeCarModal(id) {
            this.$uibModal.open({
                templateUrl: 'ngApp/views/modalViews/deleteCar.html',
                controller: GroupProjectStart.Controllers.DeleteCarController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,
                },
                size: 'md'
            });
        }

        //opens modal to edit car
        public editCarModal(id) {
            this.$uibModal.open({
                templateUrl: 'ngApp/views/modalViews/carEdit.html',
                controller: GroupProjectStart.Controllers.CarsEditController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,
                },
                size: 'lg'
            });
        }

        //saves a car to the database
        saveCar() {
            this.carToAdd.applicationUserId = this.user.id;
            this.carToAdd.image = this.image
            this.carService.saveCar(this.user.id, this.carToAdd).then(() => {
                this.$state.reload();
            }).catch((err) => {
                this.errorMessages = err.data;
            });
        }

        //filepicker methods//
        public pickFile() {
            this.filepickerService.pick({
                mimetype: 'image/*',
            }, this.fileUploaded.bind(this));
        }

        private fileUploaded(file) {
            this.file = file;
            this.$scope.$apply();
            this.image = file.url;
        }
        //


        //gets a single user
        public getUser() {
            let userId = this.$stateParams['id']
            this.user = this.profileService.getUser(userId);
        }

        //changes isActive bool to true
        public activateCar(id) {
            this.carService.getCar(id).$promise.then((car) => {
                car.isActive = true;
                this.carService.saveCar(this.user.id, car).then((data) => {
                    this.$state.reload();
                })
            });
        }

        //changes isActive bool to false
        public deactivateCar(id) {
            this.carService.getCar(id).$promise.then((car) => {
                car.isActive = false;
                this.carService.saveCar(this.user.id, car).then((data) => {
                    this.$state.reload();
                })
            });
        }
    }



    export class EditProfileController {

        public userId
        public user;

        constructor(
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService,
            private profileService: GroupProjectStart.Services.ProfileService,
            private $uibModalInstance: ng.ui.bootstrap.IModalServiceInstance,
            private id) {
            this.userId = this.id;
            this.user = this.profileService.getUser(this.userId)

        }

        //updates users info
        editUser() {
            this.profileService.updateUser(this.user)
            this.$state.reload();
            this.close();
        }

        //closes modal
        close() {
            this.$uibModalInstance.close()
        }
    }
}