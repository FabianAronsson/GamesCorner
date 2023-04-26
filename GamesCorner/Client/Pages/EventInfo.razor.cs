
using System.Net.Http.Json;
using GamesCorner.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace GamesCorner.Client.Pages;

public partial class EventInfo : ComponentBase
{
	[Parameter] public string EventId { get; set; }
	public EventDto Event { get; set; } = new();
	private string EmailUser { get; set; }
	private string PhoneUser { get; set; }
	private string NameUser { get; set; }
	private bool showSuccesPage { get; set; } = false;
	protected override async Task OnParametersSetAsync()
	{
		await GetEvent();
	}
	private async Task GetEvent()
	{
		var GuidFromString = new Guid(EventId);
		var client = HttpClientFactory.CreateClient("public");
		var response = await client.GetAsync($"getEvent?id={GuidFromString}");

		if (response.IsSuccessStatusCode)
		{
			Event = await response.Content.ReadFromJsonAsync<EventDto>();
		}
		StateHasChanged();
	}
	private async Task HandleSubmit()
	{
		var userEvent = new UserEventDto
		{
			Id = new Guid().ToString(),
			EventId = EventId,
			Email= EmailUser,
			Name = NameUser,
			Phone = PhoneUser
		};
		var client = HttpClientFactory.CreateClient("public");
		var response = await client.PostAsJsonAsync("addUserToEvent", userEvent);

		if (response.IsSuccessStatusCode)
		{
			var url = "https://prod-04.northeurope.logic.azure.com:443/workflows/20e461c9d4724a64a4719abd3fb70e76/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=dF_OnxPHmKi1j8Ji5FEhL8q1c20NmQpYgVGrDue6PXI";
			var payload = $"{{\"to\": \"{userEvent.Email}\", \"subject\": \"{Event.Name} Event\", \"body\": " +
			              $"\"<h1>{NameUser}, Welcome to the {Event.Name} Event!</h1><p><b>Description:</b> " +
			              $"{Event.Description}</p><p> <h1>Information:</h1><strong>{Event.Name} event will be celebrated on {Event.Date} " +
			              $"at {Event.Location}.</strong></p><p>The price of the event is {Event.Price} Kr and can be paid on location.</p>\"}}";
			var content = new StringContent(payload, Encoding.UTF8, "application/json");
			var response2 = await HttpClient.PostAsync(url, content);
			showSuccesPage = true;
			
		}
	}

	
	


	
}