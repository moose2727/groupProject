namespace GroupProjectStart.Controllers {

    export class CarsController {
        public cars;

        constructor(private carService: GroupProjectStart.Services.CarService) {
            this.cars = this.carService.getCars();

        }

    }

   
}