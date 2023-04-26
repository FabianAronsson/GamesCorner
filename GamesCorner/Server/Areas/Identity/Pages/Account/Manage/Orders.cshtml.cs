using DataAccess.Models;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesCorner.Server.Areas.Identity.Pages.Account.Manage
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
		public IEnumerable<OrderModel> Orders { get; set; }
		public List<ProductModel> ProductsInOrder { get; set; } = new List<ProductModel>();
		
		public double ProductTotalPrice { get; set; }

		public double OrderTotalPrice { get; set; }

		

		public ProductModel GetProductModel(Guid id)
		{
			return _unitOfWork.ProductRepository.GetAsync(id).Result;
		}

		public double GetOrderTotalPrice(Guid id)
		{
			var order = _unitOfWork.OrderRepository.GetAsync(id).Result;
			double totalPrice = 0;
			foreach (var item in order.Products)
			{
				totalPrice += GetProductModel(item.ProductId).Price * item.Amount;
			}
			return totalPrice;
		}

		public async Task<IActionResult> OnGetAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"Unable to load the user with '{_userManager.GetUserId(User)}'.");
			}
			Orders = await  _unitOfWork.OrderRepository.GetAllAsync();
			Orders = Orders.Where(u => u.CustomerEmail == user.Email);

			foreach (var order in Orders)
			{

				var orderItems = await _unitOfWork.OrderRepository.GetAsync(order.Id);

				if (orderItems != null)
				{
					
					OrderTotalPrice = 0;
					foreach (var product in orderItems.Products)
					{
						var productInOrder = await _unitOfWork.ProductRepository.GetAsync(product.ProductId);
						if (productInOrder != null)
						{
							ProductsInOrder.Add(productInOrder);
						}
					}
					foreach (var pro in order.Products)
					{
						ProductTotalPrice = 0;
						

						foreach (var product in ProductsInOrder)
						{
							if (pro.ProductId == product.Id)
							{
								ProductTotalPrice += (product.Price * pro.Amount);
							}
						}
						OrderTotalPrice += ProductTotalPrice;
					}
				}
			}

			return Page();
		}
	}
}