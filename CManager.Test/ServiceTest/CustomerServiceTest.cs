using CManager.App.Services;
using CManager.dom.Models;
using CManager.repo.Repos;
using Moq;

namespace CManager.Test.ServiceTest;

public class CustomerServiceTest
{

    [Fact]
    public void CreateCustomer_ShouldReturnTrue_WhenCustomerIsCreatedSuccessfully()
    {
        // Arrange
        var mockCustomerRepo = new Mock<ICustomerRepo>();
        mockCustomerRepo.Setup(repo => repo.GetCustomers()).Returns(new List<CustomerModel>());
        mockCustomerRepo.Setup(repo => repo.SaveCustomerModel(It.IsAny<List<CustomerModel>>())).Returns(true);
        var customerService = new CustomerService(mockCustomerRepo.Object);

        // Act
        var result = customerService.CreateCustomer("aaa", "eee", "em@gmail.com", "1234567890", "123", "12345", "Cccc");

        // Assert
        Assert.True(result);
    }

}

