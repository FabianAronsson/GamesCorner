using System.Drawing.Text;
using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GamesCorner.Server.Areas.Identity.Pages.order
{
	public class OrdersModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public OrdersModel(IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
		{
			_unitOfWork = unitOfWork;
			_signInManager = signInManager;
			_userManager = userManager;
			_httpContextAccessor = httpContextAccessor;
			User = _httpContextAccessor.HttpContext.User;
		}

		public System.Security.Claims.ClaimsPrincipal User { get; set; }
		public List<OrderModel> Orders { get; set; }

		public string ProductName { get; set; }
		public string GetProductName(Guid productId)
		{
			var product = _unitOfWork.ProductRepository.GetAsync(productId);
			ProductName = product.Result.Name;
			return ProductName;
		}
		public async Task<IActionResult> OnGetAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"Unable to load the user with '{_userManager.GetUserId(User)}'.");
			}
			Orders = _unitOfWork.OrderRepository.GetAllAsync().Result.ToList();
			Orders = Orders.FindAll(u => u.CustomerEmail == user.Email);
			return Page();

		}


		
	}
}