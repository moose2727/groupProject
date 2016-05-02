namespace GroupProjectStart.Controllers {

    export class CarsController {
        public cars;
        public totalItems;
        public currentPage = 1;
        public maxSize = 3;
        public itemsPerPage = 4;

        constructor(private carService: GroupProjectStart.Services.CarService,
            private $uibModal: ng.ui.bootstrap.IModalService,
            public $stateParams: ng.ui.IStateParamsService) {

            console.log(this.currentPage);

            //this.carService.getCarsShortList(this.currentPage).$promise.then((data) => {

            //    //this.totalItems = this.cars.length;
            //    this.cars = data;
            //    console.log(this.totalItems);
            //});

            this.totalItems = 0;
            this.getCars();



            //this.carService.getCars(this.currentPage).then((data) => {
            //    this.cars = data.cars;
            //    this.totalItems = data.totalCount;
            //});
        }

        getCars() {
            this.carService.getCarsAmount().then((data) => {
                this.totalItems = data.length;
                console.log(data.length);
            });
            this.carService.getCarsShortList(this.currentPage).then((data) => {
                this.cars = data;
                console.log(data);
            });
        }

        setPage(pageNo) {

            this.currentPage = pageNo;
        }

        public nextpage() {
            this.getCars();
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