using System;
namespace car_app.Models.CarApp
{
	public class car_app_details_view_model
	{
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int Horsepower { get; set; }
        public string Color { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}

