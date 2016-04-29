namespace GroupProjectStart.Controllers {

    export class CarsController {
        public cars;
        public totalItems;
        public currentPage = this.$stateParams;
        public maxSize = 3;
        public itemsPerPage = 4;

        constructor(private carService: GroupProjectStart.Services.CarService,
            private $uibModal: ng.ui.bootstrap.IModalService,
            public $stateParams : ng.ui.IStateParamsService) {
            this.carService.getCars(this.$stateParams['page']).then((data) => {
                this.cars = data.cars;
                this.totalItems = data.totalCount;
            });
        }

        public carRateModal(id) {

            this.$uibModal.open({
                templateUrl: '/ngApp/views/modalViews/rateCar.html',
                controller: GroupProjectStart.Controllers.CreateCarRatingController,
                controllerAs: 'controller',
                resolve: {
                    id: () => id,

                },
                size: 'lg'
            });

        }

    }

    export class CarFormController {
        public carToAdd;
        public file;
        public image;
        public userId;

        constructor(
            private carService: GroupProjectStart.Services.CarService,
            private $state: ng.ui.IStateService,
            private filepickerService: any,
            private $scope: ng.IScope) {
            
        }

        saveCar(id, carToAdd) {
            this.carToAdd.image = this.image
            this.carService.saveCar(this.userId, this.carToAdd).then(() => {
                this.$state.go('cars');
            });
        }

        cancel() {
            this.$state.go('cars');
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

        
    }


}