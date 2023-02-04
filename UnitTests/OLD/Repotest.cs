// using Core.Common;
// using Core.Entities;
// using Data.Repositories;
// using Data.Repositories.Impl;
// using Microsoft.EntityFrameworkCore;
// using Moq;
// using System;
// using System.Linq.Expressions;
// using System.Threading.Tasks;
// using Core.Exceptions;
// using Data;
// using Xunit;
//
// namespace UnitTests
//
// {
//     public class Repotest
//     {
//         private readonly Mock<DbSet<Message>> _mockDbSet;
//         private readonly Mock<IndContext> _mockContext;
//         private readonly BaseRepository<Message> _baseRepository;
//
//         public Repotest()
//         {
//             _mockDbSet = new Mock<DbSet<Message>>();
//             _mockContext = new Mock<IndContext>();
//             _mockContext.Setup(c => c.Set<Message>()).Returns(_mockDbSet.Object);
//             _baseRepository = new BaseRepository<Message>(_mockContext.Object);
//         }
//
//         [Fact]
//         public async Task TestGetFirstASync()
//         {
//             // Arrange
//             Expression<Func<Message, bool>> predicate = m => m.CustomerId == 1;
//             Message message = new Message
//             {
//                 CustomerId = 1,
//                 FileURL = "Test message",
//                 DateSent = DateTime.Now
//             };
//             _mockDbSet.Setup(d => d.Where(predicate)).Returns(_mockDbSet.Object);
//             _mockDbSet.Setup(d => d.FirstOrDefaultAsync()).ReturnsAsync(message);
//
//             // Act
//             Message result = await _baseRepository.GetFirstASync(predicate);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(message, result);
//             _mockDbSet.Verify(d => d.Where(predicate), Times.Once());
//             _mockDbSet.Verify(d => d.FirstOrDefaultAsync(), Times.Once());
//         }
//
//         [Fact]
//         public async Task TestGetFirstASync_ThrowsResourceNotFoundException()
//         {
//             // Arrange
//             Expression<Func<Message, bool>> predicate = m => m.CustomerId == 1;
//             _mockDbSet.Setup(d => d.Where(predicate)).Returns(_mockDbSet.Object);
//             _mockDbSet.Setup(d => d.FirstOrDefaultAsync()).ReturnsAsync(default(Message));
//
//             // Act
//             Exception ex =
//                 await Assert.ThrowsAsync<ResourceNotFoundException>(() => _baseRepository.GetFirstASync(predicate));
//
//             // Assert
//             Assert.Equal(typeof(Message), ex.HResult);
//             _mockDbSet.Verify(d => d.Where(predicate), Times.Once());
//             _mockDbSet.Verify(d => d.FirstOrDefaultAsync(), Times.Once());
//         }
//
//         [Fact]
//         public async Task TestGetAllAsync()
//         {
//             // Arrange
//             // Arrange
//             List<Message> messages = new List<Message>
//             {
//                 new Message
//                 {
//                     CustomerId = 1,
//                     FileURL = "Test message",
//                     DateSent = DateTime.Now
//                 },
//                 new Message
//                 {
//                     CustomerId = 2,
//                     FileURL = "Test message 2",
//                     DateSent = DateTime.Now
//                 }
//             };
//             _mockDbSet.As<IAsyncEnumerable<Message>>().Setup(d => d.GetAsyncEnumerator())
//                 .Returns(  (messages.GetEnumerator()));
//             _mockDbSet.As<IQueryable<Message>>().Setup(d => d.Provider)
//                 .Returns(new TestAsyncQueryProvider<Message>(messages.AsQueryable().Provider));
//             _mockDbSet.As<IQueryable<Message>>().Setup(d => d.Expression).Returns(messages.AsQueryable().Expression);
//             _mockDbSet.As<IQueryable<Message>>().Setup(d => d.ElementType).Returns(messages.AsQueryable().ElementType);
//             _mockDbSet.As<IQueryable<Message>>().Setup(d => d.GetEnumerator())
//                 .Returns(messages.AsQueryable().GetEnumerator());
//
//             // Act
//             List<Message> result = await _baseRepository.GetAllAsync();
//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(2, result.Count);
//             Assert.Equal(messages, result);
//             _mockDbSet.Verify(d => d.ToListAsync(), Times.Once());
//         }
//
//         [Fact]
//         public async Task TestAddAsync()
//         {
//             // Arrange
//             Message message = new Message
//             {
//                 CustomerId = 1,
//                 FileURL = "Test message",
//                 DateSent = DateTime.Now
//             };
//             _mockDbSet.Setup(d => d.Add(message)).Returns(EntityEntryStub.Create(message, EntityState.Added));
//
//             // Act
//             Message result = await _baseRepository.AddAsync(message);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(message, result);
//             _mockDbSet.Verify(d => d.Add(message), Times.Once());
//             _mockContext.Verify(c => c.SaveChangesAsync(), Times.Once());
//         }
//
//         [Fact]
//         public async Task TestUpdateAsync()
//         {
//             // Arrange
//             Message message = new Message
//             {
//                 CustomerId = 1,
//                 FileURL = "Test message",
//                 DateSent = DateTime.Now
//             };
//             _mockDbSet.Setup(d => d.Update(message)).Returns(EntityEntryStub.Create(message, EntityState.Modified));
//
//             // Act
//             Message result = await _baseRepository.UpdateAsync(message);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(message, result);
//             _mockDbSet.Verify(d => d.Update(message), Times.Once());
//             _mockContext.Verify(c => c.SaveChangesAsync(), Times.Once());
//         }
//
//         [Fact]
//         public async Task TestDeleteAsync()
//         {
//             // Arrange
//             Message message = new Message
//             {
//                 CustomerId = 1,
//                 FileURL = "Test message",
//                 DateSent = DateTime.Now
//             };
//             _mockDbSet.Setup(d => d.Remove(message)).Returns(EntityEntryStub.Create(message, EntityState.Deleted));
//
//             // Act
//             Message result = await _baseRepository.DeleteAsync(message);
//
//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(message, result);
//             _mockDbSet.Verify(d => d.Remove(message), Times.Once());
//             _mockContext.Verify(c => c.SaveChangesAsync(), Times.Once());
//         }
//     }
// }
//
//
//
// //     public class MessageRepositoryTests
// //     {
// //         private readonly Mock<IndContext> _mockContext;
// //         private readonly MessageRepository _messageRepository;
// //
// //         public MessageRepositoryTests()
// //         {
// //             _mockContext = new Mock<IndContext>();
// //             _messageRepository = new MessageRepository(_mockContext.
// //
// //             public async Task TestGetFirstASync()
// //         {
// //             // Arrange
// //             Expression<Func<Message, bool>> predicate = m => m.CustomerId == 1;
// //             Message message = new Message
// //             {
// //                 CustomerId = 1,
// //                 MessageText = "Test message",
// //                 DateSent = DateTime.Now
// //             };
// //             _mockContext.Setup(c => c.Set<Message>().Where(predicate)).Returns(_mockContext.Object.Set<Message>());
// //             _mockContext.Setup(c => c.Set<Message>().FirstOrDefaultAsync()).ReturnsAsync(message);
// //
// //             // Act
// //             Message result = await _messageRepository.GetFirstASync(predicate);
// //
// //             // Assert
// //             Assert.NotNull(result);
// //             Assert.Equal(message, result);
// //             _mockContext.Verify(c => c.Set<Message>().Where(predicate), Times.Once());
// //             _mockContext.Verify(c => c.Set<Message>().FirstOrDefaultAsync(), Times.Once());
// //         }
// //
// //         [Fact]
// //         public async Task TestGetAllAsync()
// //         {
// //             // Arrange
// //             List<Message> messages = new List<Message>
// //             {
// //                 new Message
// //                 {
// //                     CustomerId = 1,
// //                     MessageText = "Test message",
// //                     DateSent = DateTime.Now
// //                 },
// //                 new Message
// //                 {
// //                     CustomerId = 2,
// //                     MessageText = "Test message 2",
// //                     DateSent = DateTime.Now
// //                 }
// //             };
// //             _mockContext.Setup(c => c.Set<Message>().ToListAsync()).ReturnsAsync(messages);
// //
// //             // Act
// //             List<Message> result = await _messageRepository.GetAllAsync();
// //
// //             // Assert
// //             Assert.NotNull(result);
// //             Assert.Equal(2, result.Count);
// //             Assert.Equal(messages, result);
// //             _mockContext.Verify(c => c.Set<Message>().ToListAsync(), Times.Once());
// //         }
// //
// //         [Fact]
// //         public async Task TestAddAsync()
// //         {
// //             // Arrange
// //             Message message = new Message
// //             {
// //                 CustomerId = 1,
// //                 MessageText = "Test message",
// //                 DateSent = DateTime.Now
// //             };
// //             _mockContext.Setup(c => c.Set<Message>().Add(message)).Returns(EntityEntryStub.Create(message, EntityState.Added));
// //
// //             // Act
// //             Message result = await _messageRepository.AddAsync(message);
// //
// //             // Assert
// //             Assert.NotNull(result);
// //             Assert.Equal(message, result);
// //             _mockContext.Verify(c => c.Set<Message>().Add(message), Times.Once());
// //             _mockContext.Verify(c => c.SaveChangesAsync(), Times.Once());
// //         }
// //
// //         [Fact]
// //         public async Task TestUpdateAsync()
// //         {
// //             // Arrange
// //             Message message = new Message
// //             {
// //                 CustomerId
// //                 Assert.NotNull(result);
// //                 Assert.Equal(message, result);
// //                 _mockContext.Verify(c => c.Set<Message>().Update(message), Times.Once());
// //                 _mockContext.Verify(c => c.SaveChangesAsync(), Times.Once());
// //             }
// //
// //             [Fact]
// //             public async Task TestDeleteAsync()
// //             {
// //                 // Arrange
// //                 Message message = new Message
// //                 {
// //                     CustomerId = 1,
// //                     MessageText = "Test message",
// //                     DateSent = DateTime.Now
// //                 };
// //                 _mockContext.Setup(c => c.Set<Message>().Remove(message)).Returns(EntityEntryStub.Create(message, EntityState.Deleted));
// //
// //                 // Act
// //                 Message result = await _messageRepository.DeleteAsync(message);
// //
// //                 // Assert
// //                 Assert.NotNull(result);
// //                 Assert.Equal(message, result);
// //                 _mockContext.Verify(c => c.Set<Message>().Remove(message), Times.Once());
// //                 _mockContext.Verify(c => c.SaveChangesAsync(), Times.Once());
// //             }
// //         }
//     }
//
// }

