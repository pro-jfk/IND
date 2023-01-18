using System.Text;
using App.MappingProfile;
using App.Models;
using App.Services;
using App.Services.impl;
using AutoMapper;
using Core.Exceptions;
using Data;
using Data.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.New;

public class CustomerServiceTests
{

    [Fact]
    public async Task CreateCustomer_Successful()
    {
        // Arrange
        DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
            .UseInMemoryDatabase(databaseName: "CreateCustomer_AddCustomer")
            .Options;
        using (IndContext context = new IndContext(options))
        {
            var hashedFingerprint = Encoding.UTF8.GetBytes("fingerprintandsalt");
            var hashServiceMock = new Mock<IHashService>();
            hashServiceMock.Setup(h => h.Hash(It.IsAny<string>(), It.IsAny<byte[]>())).ReturnsAsync(hashedFingerprint);


            var customerRepository = new CustomerRepository(context);
            var config = new MapperConfiguration(cfg => { cfg.AddProfile<CustomerProfile>(); });
            var mapper = new Mapper(config);
            var customerService = new CustomerService(customerRepository, mapper, hashServiceMock.Object);

            var customer = new CreateCustomer
            {
                Id = 1234567890,
                FirstName = "John",
                LastName = "Doe",
                LanguagesSpoken = "English",
                Origin = "Canada",
                PhoneNumber = "+1-613-555-0149 ",
                EmergencyShelterId = 1
            };
            // Act
            var createdCustomer = await customerService.CreateCustomer(customer);
            var getCustomer = await customerService.GetCustomer(1234567890);
            // Assert
            Assert.Equal(customer.Id, getCustomer.Id);
            Assert.Equal(customer.Origin, getCustomer.Origin);
        }
    }

            
        [Fact]
        public async Task UpdateCustomer_ChangeFirstName_Successful()
        {
            // Arrange
            DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
                .UseInMemoryDatabase(databaseName: "UpdateCustomer_ChangeId_Successful")
                .Options;
            using (IndContext context = new IndContext(options))
            {
                var hashedFingerprint = Encoding.UTF8.GetBytes("fingerprintandsalt");
                var hashServiceMock = new Mock<IHashService>();
                hashServiceMock.Setup(h => h.Hash(It.IsAny<string>(), It.IsAny<byte []>())).ReturnsAsync(hashedFingerprint);
            
                var customerRepository = new CustomerRepository(context);
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile<CustomerProfile>();
                });
                var mapper = new Mapper(config);
                var customerService = new CustomerService(customerRepository, mapper, hashServiceMock.Object);
            
                var customer = new CreateCustomer
                {
                    Id = 1234567890,
                    FirstName = "John",
                    LastName = "Doe",
                    LanguagesSpoken = "English",
                    Origin = "Canada",
                    PhoneNumber = "+1-613-555-0149 ",
                    EmergencyShelterId = 1
                };
                await customerService.CreateCustomer(customer);
                
                
                //Act
                var existingCustomer = await customerRepository.GetFirstASync(c => c.Id == 1234567890);
                existingCustomer.FirstName = "Tom";
                await customerRepository.UpdateAsync(existingCustomer);
                var updatedCustomer = await customerService.GetCustomer(1234567890);
             
              
                // Assert
                Assert.Equal("Tom", updatedCustomer.FirstName);
            }
        }
    [Fact]
        public async Task DeleteMessage_Successful()
        {
            // Arrange
            DbContextOptions<IndContext> options = new DbContextOptionsBuilder<IndContext>()
                .UseInMemoryDatabase(databaseName: "DeleteMessage_DeletesCorrectly")
                .Options;
            using (IndContext context = new IndContext(options))
            {
                var hashedFingerprint = Encoding.UTF8.GetBytes("fingerprintandsalt");
                var hashServiceMock = new Mock<IHashService>();
                hashServiceMock.Setup(h => h.Hash(It.IsAny<string>(), It.IsAny<byte []>())).ReturnsAsync(hashedFingerprint);
            
                var customerRepository = new CustomerRepository(context);
                var config = new MapperConfiguration(cfg => {
                    cfg.AddProfile<CustomerProfile>();
                });
                var mapper = new Mapper(config);
                var customerService = new CustomerService(customerRepository, mapper, hashServiceMock.Object);
            
                var customer = new CreateCustomer
                {
                    Id = 1234567890,
                    FirstName = "John",
                    LastName = "Doe",
                    LanguagesSpoken = "English",
                    Origin = "Canada",
                    PhoneNumber = "+1-613-555-0149 ",
                    EmergencyShelterId = 1
                };
                await customerService.CreateCustomer(customer);
                // Act
                await customerService.DeleteCustomer(1234567890);
                // Assert
            
                await Assert.ThrowsAsync<ResourceNotFoundException>(async () => await customerRepository.GetFirstASync(m => m.Id == 1));
            }
        }
}