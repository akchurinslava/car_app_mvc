using System;
using car_app_core.Domain;
using car_app_data;

namespace car_app_application_services
{
	public class CarRepository
	{
        private readonly ApplicationDbContext _dbContext;

        public CarRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Car> GetAllCars()
        {
            return _dbContext.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return _dbContext.Cars.FirstOrDefault(car => car.Id == id);
        }

        public void AddCar(Car car)
        {
            _dbContext.Cars.Add(car);
            _dbContext.SaveChanges();
        }

        public void UpdateCar(Car car)
        {
            _dbContext.Cars.Update(car);
            _dbContext.SaveChanges();
        }

        public void DeleteCar(int id)
        {
            var car = _dbContext.Cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                _dbContext.Cars.Remove(car);
                _dbContext.SaveChanges();
            }
        }
    }
}

