using System;
using car_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using car_app_core.Domain;
using car_app_data;

namespace car_app.Controllers
{
	public class CarsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CarsController(ApplicationDbContext context)
		{
			_context = context;
		}


        public IActionResult YourAction()
        {
			var cars = new List<car_app_core.Dto.Car>();

            return View(cars);
        }


        //Get for Cats
        public async Task<IActionResult> Index()
		{
			var cars = await _context.Cars.ToListAsync();
			return View(cars);
		}

		//Get for Cars/Details
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
			if (car == null)
			{
				return NotFound();

			}

			return View(car);
		}

		//Get for Cars/Create
		public IActionResult Create()
		{
			return View();
		}

		//Post for Cars/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Make,Model,Year,Price,Horsepower,Color,CreatedAt,ModifiedAt")] Car car)
		{
			if (ModelState.IsValid)
			{
				car.CreatedAt = DateTime.Now;
				car.ModifiedAt = DateTime.Now;
				_context.Add(car);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(car);
		}

		//Get Cars/Edit
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();

			}
			var car = await _context.Cars.FindAsync(id);
			if (car == null)
			{
				return NotFound();
			}

			return View(car);
		}

		//Post Cars/Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Make,Model,Year,Price,Horsepower,Color,CreatedAt,ModifiedAt")] Car car)
		{
			if (id != car.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					car.ModifiedAt = DateTime.Now;
					_context.Update(car);
					await _context.SaveChangesAsync();
				}

				catch (DbUpdateConcurrencyException)
				{
					if (!CarExists(car.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(car);

		}
		//Get Cars/Delete
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
			if (car == null)
			{
				return NotFound();
			}

			return View(car);

		}

		//Post for Cars/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var car = await _context.Cars.FindAsync(id);
			_context.Cars.Remove(car);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		
		



		private bool CarExists(int id)
		{
			return _context.Cars.Any(e => e.Id == id);
		}
	}
}
