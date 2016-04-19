﻿namespace GroupProjectStart.Services {

    export class CarService {
        private carResource;

        constructor(private $resource: angular.resource.IResourceService) {
            this.carResource = this.$resource("/api/cars/:id");

           
        }
        getCars() {
            return this.carResource.query()
        }

        // Method that will get a single car
        getCar(id) {
            return this.carResource.get({ id: id });
        }

        saveCar(carToSave) {
            return this.carResource.save(carToSave).$promise;
        }

        deleteCar(id) {
            return this.carResource.delete({ id: id }).$promise;
        }
    } 
    angular.module("GroupProjectStart").service('carService', CarService);
}