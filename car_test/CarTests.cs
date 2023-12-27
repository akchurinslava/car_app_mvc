using System;
using car_app;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Xunit;

namespace car_test
{
    [Collection("DatabaseCollection")]
    public class CarTests : IClassFixture<TestDatabaseFixture>
    {
        private readonly TestDatabaseFixture _fixture;

        public CarTests(TestDatabaseFixture fixture)
        {
            _fixture = fixture;
            _fixture.ClearDatabase();
        }

        //Test check, can we add new car
        [Fact]
        public void CanAddCar()
        {

            var carRepository = new CarRepository(_fixture.DbContext);
            var carService = new CarService(carRepository);

           

            carService.AddCar("BMW", "X5", 2005);


            var cars = carService.GetAllCars();
            Assert.Single(cars);
            Assert.Equal("BMW", cars[0].Make);
            Assert.Equal("X5", cars[0].Model);
            Assert.Equal(2005, cars[0].Year);
        }

        //Test check, can we update car
        [Fact]
        public void CanUpdateCar()
        {

            var carRepository = new CarRepository(_fixture.DbContext);
            var carService = new CarService(carRepository);

          

            carService.AddCar("Porsche", "Panamera", 2020);
            var carsBeforeUpdate = carService.GetAllCars();
            carService.UpdateCar(carsBeforeUpdate[0].Id, "Porsche", "Panamera", 2021);


            var carsAfterUpdate = carService.GetAllCars();
            Assert.Single(carsAfterUpdate);
            Assert.Equal("Porsche", carsAfterUpdate[0].Make);
            Assert.Equal("Panamera", carsAfterUpdate[0].Model);
            Assert.Equal(2021, carsAfterUpdate[0].Year);
        }

        //Test check can we delete car
        [Fact]
        public void CanDeleteCar()
        {

            var carRepository = new CarRepository(_fixture.DbContext);
            var carService = new CarService(carRepository);

            _fixture.ClearDatabase();

            carService.AddCar("Audi", "A7", 2008);
            var carsBeforeDelete = carService.GetAllCars();
            carService.DeleteCar(carsBeforeDelete[0].Id);


            var carsAfterDelete = carService.GetAllCars();
            Assert.Empty(carsAfterDelete);
        }

        //Test check can we get information about car
        [Fact]
        public void CanGetCarById()
        {

            var carRepository = new CarRepository(_fixture.DbContext);
            var carService = new CarService(carRepository);

      

            carService.AddCar("BMW", "X5", 2005);
            var cars = carService.GetAllCars();
            var carById = carService.GetCarById(cars[0].Id);


            Assert.NotNull(carById);
            Assert.Equal("BMW", carById.Make);
            Assert.Equal("X5", carById.Model);
            Assert.Equal(2005, carById.Year);
        }
    }
}

