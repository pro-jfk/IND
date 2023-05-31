// using System.Text;
// using App.Models;
// using App.Services;
// using App.Services.impl;
// using AutoMapper;
// using Core.Entities;
// using Data.Repositories;
//
// namespace UnitTests.Services;
//
// public class CustomerServiceTest
// {
//     private readonly Mock<ICustomerRepository> _customerRepositoryMock;
//     private readonly Mock<IMapper> _mapperMock;
//     private readonly Mock<IHashService> _hashServiceMock;
//     private readonly CustomerService _customerService;
//     
//     public CustomerServiceTest()
//     {
//         _customerRepositoryMock = new Mock<ICustomerRepository>();
//         _mapperMock = new Mock<IMapper>();
//         _hashServiceMock = new Mock<IHashService>();
//         _customerService = new CustomerService(_customerRepositoryMock.Object, _mapperMock.Object, _hashServiceMock.Object);
//     }
//     
//     [Fact]
//     public async Task DeleteCustomer_CustomerDeleted()
//     {
//         // Arrange
//         var id = 1;
//         var customer = new Customer();
//         var customerResponse = new CustomerResponse();
//         _customerRepositoryMock.Setup(x => x.GetFirstASync(c => c.Id == id)).ReturnsAsync(customer);
//         _customerRepositoryMock.Setup(x => x.DeleteAsync(customer)).ReturnsAsync(customer);
//         _mapperMock.Setup(x => x.Map<CustomerResponse>(customer)).Returns(customerResponse);
//
//         // Act
//         var result = await _customerService.DeleteCustomer(id);
//
//         // Assert
//         _customerRepositoryMock.Verify(x => x.GetFirstASync(c => c.Id == id), Times.Once);
//         _customerRepositoryMock.Verify(x => x.DeleteAsync(customer), Times.Once);
//         _mapperMock.Verify(x => x.Map<CustomerResponse>(customer), Times.Once);
//         Assert.Equal(customerResponse, result);
//     }
//     
//     [Fact]
//     public async Task VerifyFingerprint_FingerprintMatched()
//     {
//         // Arrange
//         var id = 1;
//         var fingerprint = "fingerprint";
//         var customer = new Customer { Id = id,Salt = Encoding.UTF8.GetBytes("salt"), HashedFingerPrint = Encoding.UTF8.GetBytes("hashedFingerprint") };
//         _customerRepositoryMock.Setup(x => x.GetFirstASync(c => c.Id == id)).ReturnsAsync(customer);
//         _hashServiceMock.Setup(x => x.Verify(fingerprint, customer.Salt, customer.HashedFingerPrint)).ReturnsAsync(true);
//
//         // Act
//         var result = await _customerService.VerifyFingerprint(id, fingerprint);
//
//         // Assert
//         _customerRepositoryMock.Verify(x => x.GetFirstASync(c => c.Id == id), Times.Once);
//         _hashServiceMock.Verify(x => x.Verify(fingerprint, customer.Salt, customer.HashedFingerPrint), Times.Once);
//         Assert.True(result);
//     }
//     
//     [Fact]
//     public async Task VerifyFingerprint_Fails()
//     {
//         // Arrange
//         var id = 1;
//         var fingerprint = "fingerprint";
//         var customer = new Customer { Id = id, Salt = Encoding.UTF8.GetBytes("salt"), HashedFingerPrint = Encoding.UTF8.GetBytes("hashedFingerprint") };
//         _customerRepositoryMock.Setup(x => x.GetFirstASync(c => c.Id == id)).ReturnsAsync(customer);
//         _hashServiceMock.Setup(x => x.Verify(fingerprint, customer.Salt, customer.HashedFingerPrint)).ReturnsAsync(false);
//
//         // Act
//         var result = await _customerService.VerifyFingerprint(id, fingerprint);
//
//         // Assert
//         _customerRepositoryMock.Verify(x => x.GetFirstASync(c => c.Id == id), Times.Once);
//         _hashServiceMock.Verify(x => x.Verify(fingerprint, customer.Salt, customer.HashedFingerPrint), Times.Once);
//         Assert.False(result);
//     }
//
//     [Fact]
//   public void CustomerDoesntExist (){}
//   
//   
// }

