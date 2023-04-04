namespace DataAccess.UnitOfWork;

public interface IUnitOfWork
{
	public Task<int> Save();

	public void Dispose();


}