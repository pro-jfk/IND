// namespace UnitTests.Repositories;
//
// public class Example
// {
//     [Fact]
//     public void GetByIdAsync_Returns_Product(){
//     
//         //Setup DbContext and DbSet mock
//         var dbContextMock = new Mock<ProductsDbContext>();
//         var dbSetMock=new Mock<DbSet<Product>>();
//         dbSetMock.Setup(s=>s.FindAsync(It.IsAny<Guid>())).Returns(Task.FromResult(newProduct()));
//         dbContextMock.Setup(s=>s.Set<Product>()).Returns(dbSetMock.Object);
//
//         //Execute method of SUT(ProductsRepository
//         var productRepository= new ProductsRepository(dbContextMock.Object);
//         var product= productRepository.GetByIdAsync(Guid.NewGuid()).Result;
//
//         //Assert
//         Assert.NotNull(product);
//         Assert.IsAssignableFrom<Product>(product);
//     }
// }

