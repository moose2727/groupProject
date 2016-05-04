namespace GroupProjectStart.Services {

    export class CarService {
        private carResource;

        constructor(private $resource: angular.resource.IResourceService)

        {
            this.carResource = $resource('/api/cars/:id');
        }

        getCarsShortList(num) {
            let randomResource = this.$resource('/api/cars/browse');
            return randomResource.query({ num: num }).$promise;
        }

        getCarsAmount() {
            let carResouce = this.$resource('/api/cars/totalcount');
            return carResouce.query().$promise;
        }

        // Method that will get a single car
      

        getCar(id) {
            return this.carResource.get({ id: id });
        }

        saveCar(id, carToSave) {
            return this.carResource.save({ id: id }, carToSave).$promise;

        }

        deleteCar(id) {
            return this.carResource.delete({ id: id }).$promise;
        }
    } 
    angular.module("GroupProjectStart").service('carService', CarService);
}