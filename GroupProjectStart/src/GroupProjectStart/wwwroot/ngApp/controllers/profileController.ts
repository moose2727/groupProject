﻿namespace GroupProjectStart.Controllers {
    export class ProfilesController {
        public users;
        public loaners;

        constructor(
            private profileService: GroupProjectStart.Services.ProfileService) {
            this.users = this.profileService.getUsers();
            this.loaners = this.profileService.getLoaners();

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

        saveCar() {
            this.carToAdd.applicationUserId = this.user.id;
            this.carToAdd.image = this.image
            this.carService.saveCar(this.user.id, this.carToAdd).then(() => {
                this.$state.reload();
            }).catch((err) => {
                this.errorMessages = err.data;
            });              
        }

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
        

        public getUser() {
            let userId = this.$stateParams['id']
            this.user = this.profileService.getUser(userId);
        }


        public activateCar(id) {
            this.carService.getCar(id).$promise.then((car) => {
                car.isActive = true;
                this.carService.saveCar(this.user.id, car).then((data) => {
                    this.$state.reload();
                })
            });
        }

        

        public deactivateCar(id) {
            //debugger;
            //let car = this.carService.getCar(id);
            //console.log(car);
            this.carService.getCar(id).$promise.then((car) => {
                car.isActive = false;
                this.carService.saveCar(this.user.id, car).then((data) => {
                    this.$state.reload();
                })
            });
            //console.log(this.car)

            //this.getCar(id).then(() => {
            //    this.$state.reload();
            //})

            //this.carService.saveCar(this.car).then((data) => {
            //    this.$state.reload();
            //})
        }

        public deactivateLoaner() {
            debugger;
            this.user.isLoaner = false;
            this.profileService.updateUser(this.user);
        }

        public upgradeUser() {
            debugger;
            if (!this.accountService.getClaim('isLoaner') && this.user.isLoaner == false){
                this.user.isLoaner = true;
                this.profileService.updateUser(this.user);
                this.accountService.upgradeUser(this.user.id);
            }
            else if (this.accountService.getClaim('isLoaner') && this.user.isLoaner == false) {
                this.user.isLoaner = true;
                this.profileService.updateUser(this.user);
            }
            else if (!this.accountService.getClaim('isLoaner') && this.user.isLoaner == true){
                this.accountService.upgradeUser(this.user.id);
            }
            
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

        editUser() {
            this.profileService.updateUser(this.user)
            this.$state.reload();
            this.close();
        }

        close() {
            this.$uibModalInstance.close()
        }
    }
}