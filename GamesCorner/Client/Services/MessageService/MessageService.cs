namespace GamesCorner.Client.Services.MessageService;

public class MessageService : IMessageService
{
	public event Action<int>? OnChange;
	public void UpdateCartAmount(int amount)
	{
		OnChange?.Invoke(amount);
	}
}