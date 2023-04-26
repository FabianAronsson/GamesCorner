using DataAccess.DataContext.Data;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;

namespace GamesCorner.Tests;

public class OrderRepository_VerifyChangedOrder
{
    [Fact]
    public async Task UpdateAsyncOrder_ReturnSameObject()
    {
        //Arrange
        var options = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "StoreDatabase")
            .Options;

        var orderModel = A.Fake<OrderModel>();
        var orderRepository = A.Fake<IOrderRepository>();
        var productRepository = A.Fake<IProductRepository>();
        var eventRepository = A.Fake<IEventRepository>();
        var reviewRepository = A.Fake<IReviewRepository>();
        var interestedUserEvent = A.Fake<IInterestedUserEventRepository>();
        A.CallTo(() => orderRepository.UpdateAsync(orderModel)).Returns(orderModel);


        //Act
        await using var context = new StoreContext(options);
        var sut = new UnitOfWork(context, productRepository, orderRepository, eventRepository, interestedUserEvent, reviewRepository);
        var result = await sut.OrderRepository.UpdateAsync(orderModel);

        //Assert
        Assert.Equivalent(orderModel, result);
    }
}