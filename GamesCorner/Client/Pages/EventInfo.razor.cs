using System.Net.Http.Json;
using GamesCorner.Shared.Dtos;
using Microsoft.AspNetCore.Components;

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
			showSuccesPage = true;
		}
	}
}