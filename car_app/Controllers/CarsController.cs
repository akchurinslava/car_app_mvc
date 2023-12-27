using System;
using car_app.Models;
using Microsoft.AspNetCore.Mvc;

namespace car_app.Controllers
{
	public class CarsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CarsController(ApplicationDbContext context)
		{
			_context = context;
		}
	}
}

