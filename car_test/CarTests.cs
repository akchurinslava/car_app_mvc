using System;
using car_app;
using car_app_application_services;
using car_app_application_services.Services;
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

        // Test check, can we add a new car
        [Fact]
        public void CanAddCar()
        {
            var carRepository = new CarRepository(_fixture.DbContext);
            var carService = new CarService(carRepository);

            carService.AddCar("BMW", "X5", 2005, 50000, 300, "Blue");

            var cars = carService.GetAllCars();
            Assert.Single(cars);
            Assert.Equal("BMW", cars[0].Make);
            Assert.Equal("X5", cars[0].Model);
            Assert.Equal(2005, cars[0].Year);
            Assert.Equal(50000, cars[0].Price);
            Assert.Equal(300, cars[0].Horsepower);
            Assert.Equal("Blue", cars[0].Color);
           
           
            
            

            
        }

        // Test check, can we update a car
        [Fact]
        public void CanUpdateCar()
        {
            var carRepository = new CarRepository(_fixture.DbContext);
            var carService = new CarService(carRepository);

            carService.AddCar("Porsche", "Panamera", 2020, 80000, 400, "Blue");
            var carsBeforeUpdate = carService.GetAllCars();
            carService.UpdateCar(carsBeforeUpdate[0].Id, "Porsche", "Panamera", 2021, 85000, 450, "Blue");

            var carsAfterUpdate = carService.GetAllCars();
            Assert.Single(carsAfterUpdate);
            Assert.Equal("Porsche", carsAfterUpdate[0].Make);
            Assert.Equal("Panamera", carsAfterUpdate[0].Model);
            Assert.Equal(2021, carsAfterUpdate[0].Year);
            Assert.Equal(85000, carsAfterUpdate[0].Price);
            Assert.Equal(450, carsAfterUpdate[0].Horsepower);
            Assert.Equal("Blue", carsAfterUpdate[0].Color);
            
            
        }

        // Test check, can we delete a car
        [Fact]
        public void CanDeleteCar()
        {
            var carRepository = new CarRepository(_fixture.DbContext);
            var carService = new CarService(carRepository);

            carService.AddCar("Audi", "A7", 2008, 60000, 350, "Black");
            var carsBeforeDelete = carService.GetAllCars();
            carService.DeleteCar(carsBeforeDelete[0].Id);

            var carsAfterDelete = carService.GetAllCars();
            Assert.Empty(carsAfterDelete);
        }

        // Test check, can we get information about a car
        [Fact]
        public void CanGetCarById()
        {
            var carRepository = new CarRepository(_fixture.DbContext);
            var carService = new CarService(carRepository);

            carService.AddCar("BMW", "X5", 2005, 55000, 320, "White");
            var cars = carService.GetAllCars();
            var carById = carService.GetCarById(cars[0].Id);

            Assert.NotNull(carById);
            Assert.Equal("BMW", carById.Make);
            Assert.Equal("X5", carById.Model);
            Assert.Equal(2005, carById.Year);
            Assert.Equal(55000, carById.Price);
            Assert.Equal(320, carById.Horsepower);
            Assert.Equal("White", carById.Color);

        }
    }
}
