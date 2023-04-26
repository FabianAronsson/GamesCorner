namespace GamesCorner.Client.Services.MessageService
{
	public interface IMessageService
	{
		event Action<int> OnChange;
		void UpdateCartAmount(int amount);
	}
}
