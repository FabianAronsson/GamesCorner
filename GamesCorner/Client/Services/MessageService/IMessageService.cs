namespace GamesCorner.Client.Services.MessageService
{
	public interface IMessageService
	{
		//create message service that will send an int from the shopping cart to the navbar to update the cart amount

		event Action<int> OnChange;
		void UpdateCartAmount(int amount);


	}
}
