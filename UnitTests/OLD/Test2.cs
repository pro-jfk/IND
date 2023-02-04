// using Core.Entities;
// using Data;
// using Data.Repositories.Impl;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.ChangeTracking;
//
// namespace UnitTests
// {
//     public class Test2
//     {
//
//         private IndContext _indContext;
//
//         public Test2()
//         {
//             DbContextOptionsBuilder<IndContext> dbOptions =
//                 new DbContextOptionsBuilder<IndContext>().UseInMemoryDatabase(
//                     Guid.NewGuid()
//                         .ToString());
//             _indContext = new IndContext(dbOptions.Options);
//         }
//
//
//         [Fact]
//         public async void TestGetFirstAsync()
//         {
//             // Arrange
//
//             // var mockDbContext = new Mock<IndContext>();
//             var mockDbSet = new Mock<DbSet<Message>>();
//
//             // mockDbContext.Setup(c => c.Set<Message>()).Returns(mockDbSet.Object);
//
//             // var repository = new BaseRepository<Message>(mockDbContext.Object);
//             var repository = new BaseRepository<Message>(_indContext);
//
//             var entity = new Message { Id = 1 };
//             var entityList = new List<Message> { entity };
//
//             mockDbSet.As<IQueryable<Message>>().Setup(m => m.Provider).Returns(entityList.AsQueryable().Provider);
//             mockDbSet.As<IQueryable<Message>>().Setup(m => m.Expression).Returns(entityList.AsQueryable().Expression);
//             mockDbSet.As<IQueryable<Message>>().Setup(m => m.ElementType).Returns(entityList.AsQueryable().ElementType);
//             mockDbSet.As<IQueryable<Message>>().Setup(m => m.GetEnumerator())
//                 .Returns(() => entityList.AsQueryable().GetEnumerator());
//
//             // Act
//             var result = await repository.GetFirstASync(e => e.Id == 1);
//
//             // Assert
//             Assert.Equal(entity, result);
//         }
//
//         [Fact]
//         public async void TestDeleteAsync()
//         {
//             // Arrange
//             var mockDbContext = new Mock<IndContext>(new DbContextOptions<IndContext>());
//             var mockDbSet = new Mock<DbSet<Message>>();
//
//             mockDbContext.Setup(c => c.Set<Message>()).Returns(mockDbSet.Object);
//             mockDbContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
//
//             var repository = new MessageRepository(mockDbContext.Object);
//
//             var message = new Message { Id = 1 };
//
//             mockDbSet.Setup(m => m.AddAsync(It.IsAny<Message>(), It.IsAny<CancellationToken>())).Returns(
//                 (Message m, CancellationToken ct) =>
//                 {
//                     // Create an EntityEntry<Message> object with the provided Message object as its Entity property
//                     var entityEntry = new EntityEntry<Message>(m);
//                     entityEntry.Entity = m;
//                     return Task.FromResult(entityEntry);
//                 });
//             // Act
//             var result = await repository.DeleteAsync(message);
//
//             // Assert
//             Assert.Equal(message, result);
//         }
//     }
// }
//     

