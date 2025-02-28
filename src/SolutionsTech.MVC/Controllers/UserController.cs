using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolutionsTech.Business.Entity;
using SolutionsTech.Data.Context;
using SolutionsTech.MVC.Dto;

namespace SolutionsTech.MVC.Controllers
{
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
		public UserController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			var users = await _context.Users.Where(x => x.Active).ToListAsync();

			if (users is not null && users.Any())
			{
				foreach (var item in users)
				{
					item.UserType = await _context.UserType.Where(x => x.IdUserType == item.IdUserType).FirstOrDefaultAsync();
				}
			}

			return View(_mapper.Map<List<UserDto>>(users));
		}

		public async Task<IActionResult> Details(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var user = await _context.Users
				.FirstOrDefaultAsync(m => m.IdUser == id);
			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

		public async Task<IActionResult> Create() //=> View(_mapper.Map<List<UserTypeDto>>(await _context.UserType.Where(x => x.Active).ToListAsync()));
		{
			var userDto = new UserDto();

			var userTypes = await _context.UserType.ToListAsync();
			var userTypesDto = _mapper.Map<List<UserTypeDto>>(userTypes);

			userDto.UserTypes = userTypesDto;

			return View(userDto);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(UserDto userDto)
		{
			if (ModelState.IsValid)
			{
				_context.Add(_mapper.Map<User>(userDto));
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			return View(userDto);
		}

		public async Task<IActionResult> Edit(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var user = _mapper.Map<UserDto>(await _context.Users.FindAsync(id));

			if (user == null)
			{
				return NotFound();
			}

			var userTypes = _mapper.Map<List<UserTypeDto>>(await _context.UserType.ToListAsync());
			user.UserTypes = userTypes;	

			return View(user);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(long id, UserDto userDto)
		{
			if (id != userDto.IdUser)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(_mapper.Map<User>(userDto));
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!UserExists(userDto.IdUser))
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
			return View(userDto);
		}

		public async Task<IActionResult> Delete(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var user = await _context.Users
				.FirstOrDefaultAsync(m => m.IdUser == id);
			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(long id)
		{
			if (id == 0)
			{
				return NotFound();
			}

			var user = await _context.Users.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool UserExists(long id)
		{
			return _context.Users.Any(e => e.IdUser == id);
		}
	}
}
