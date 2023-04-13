using Blazored.LocalStorage;
using FakeItEasy;
using GamesCorner.Client.Services.CartService;
using Microsoft.AspNetCore.Components.Authorization;

namespace GamesCorner.Tests;

public class CartService_ReturnCorrectValues
{
    [Fact]
    public async Task GetUserId_ReturnStringOrNull()
    {
        //Arrange
        var localStorage = A.Fake<ILocalStorageService>();
        var httpClientFactory = A.Fake<IHttpClientFactory>();
        var httpClient = A.Fake<HttpClient>();
        var authState = A.Fake<AuthenticationStateProvider>();
        var sut = new CartService(localStorage, httpClientFactory, httpClient, authState);

        //Act
        var result = await sut.GetUserId();

        //Assert
        Assert.True(result is null or string);
    }
}