﻿using System;
using System.Drawing;
using car_app.Models;

namespace car_app
{
    public class CarService
    {
        private readonly CarRepository _carRepository;

        public CarService(CarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public List<Car> GetAllCars()
        {
            return _carRepository.GetAllCars();
        }

        public Car GetCarById(int id)
        {
            return _carRepository.GetCarById(id);
        }

        public void AddCar(string make, string model, int year, decimal price, int horsepower, string color)
        {
            var car = new Car
            {
                Make = make,
                Model = model,
                Year = year,
                Price = price,
                Horsepower = horsepower,
                Color = color,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            _carRepository.AddCar(car);
        }

        public void UpdateCar(int id, string make, string model, int year, decimal price, int horsepower, string color)
        {
            var existingCar = _carRepository.GetCarById(id);
            if (existingCar != null)
            {
                existingCar.Make = make;
                existingCar.Model = model;
                existingCar.Year = year;
                existingCar.Price = price;
                existingCar.Horsepower = horsepower;
                existingCar.Color = color;
                existingCar.ModifiedAt = DateTime.Now;

                _carRepository.UpdateCar(existingCar);
            }
        }

        public void DeleteCar(int id)
        {
            _carRepository.DeleteCar(id);
        }


    }
}

