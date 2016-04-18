namespace GroupProjectStart.Services {

    export class CarService {
        private carResource;

        constructor(private $resource: angular.resource.IResourceService) {
            this.carResource = this.$resource("/api/cars/:id");

           
        }
        getCars() {
            return this.carResource.query()
        }  
    } 
    angular.module("GroupProjectStart").service('carService', CarService);
}