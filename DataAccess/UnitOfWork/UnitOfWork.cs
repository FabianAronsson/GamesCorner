using DataAccess.DataContext.Data;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.UnitOfWork;

public class UnitOfWork :IDisposable, IUnitOfWork
{

	private readonly StoreContext _context;
	private readonly IProductRepository? _productRepository;
	private readonly IOrderRepository? _orderRepository;
	private readonly IEventRepository _eventRepository;

    public UnitOfWork(StoreContext context, IProductRepository productRepository, IOrderRepository orderRepository, IEventRepository eventRepository)
	{
		_context = context;
		_productRepository = productRepository;
		_orderRepository = orderRepository;
		_eventRepository = eventRepository;
    }

	public IProductRepository ProductRepository => _productRepository;
	public IOrderRepository OrderRepository => _orderRepository;

	public IEventRepository EventRepository => _eventRepository;

    public async Task<int> Save()
	{
		return await _context.SaveChangesAsync();
	}

	private bool _disposed;

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				_context.Dispose();
			}
		}
		_disposed = true;
	}
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}
