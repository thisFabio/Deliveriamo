using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnittestDeliveriamo.Entity;

namespace UnitTest.Deliveriamo
{
    public class RepositoryServiceTests
    {

        ///
        /// 
        ///
        [Fact]
        public async void AddUser_Should_return_valid_User()
        {
                //Arrange
                var mockedRole = new Role() { Id = 1, RoleName = "admin" };
                var mockedUser = new UserBuilder()
                    .WithId(1)
                    .WithFirstname("pippo")
                    .WithLastname("pluto")
                    .WithGender('f')
                    .WithPassword("bluemoon")
                    .WithDob(DateTime.Now)
                    .WithRole(mockedRole)
                    .WithUsername("marione90")
                    .WithRoleId(mockedRole.Id).Build();

            // create a test db in memoria -- not a mocked one
            var optionsDb = new DbContextOptionsBuilder<DeliveriamoContext>().UseInMemoryDatabase("TestDeliveriamo").Options;
            var dbContext = new DeliveriamoContext(optionsDb);
            
            var repositoryService = new RepositoryService(dbContext);
                
             
            
            //Act
            repositoryService.AddUser(mockedUser);
            repositoryService.SaveChanges();

            //Assert
            var dbUser = dbContext.User.FirstOrDefault(x => x.Id == mockedUser.Id);

            Assert.NotNull(dbUser);
        }

        public async void CheckLogin_Test_Should_Return_Valid_logins(string username, string password, bool result)
        {
            //Arrange
            var mockedRole = new Role() { Id = 1, RoleName = "admin" };
            var mockedUser = new UserBuilder()
                .WithId(1)
                .WithFirstname("pippo")
                .WithLastname("pluto")
                .WithGender('f')
                .WithPassword("b1f3676cce8d9cb94e3a8e152f78c713")
                .WithDob(DateTime.Now)
                .WithRole(mockedRole)
                .WithUsername("marione90")
                .WithRoleId(mockedRole.Id).Build();

            // create a test db in memoria -- not a mocked one
            var optionsDb = new DbContextOptionsBuilder<DeliveriamoContext>().UseInMemoryDatabase("TestDeliveriamo").Options;
            var dbContext = new DeliveriamoContext(optionsDb);

            var repositoryService = new RepositoryService(dbContext);
            repositoryService.AddUser(mockedUser);
            repositoryService.SaveChanges();

            //Act
            var response = repositoryService.CheckLogin(mockedUser.Username, mockedUser.Password);

            //Assert
            
        }
        [Fact]
        public async void AddUser_Should_return_valid_User_2 ()
        {
            //Arrange
            var mockedRole = new Role() { Id = 1, RoleName = "admin" };
            var mockedUser = new UserBuilder()
                .WithId(1)
                .WithFirstname("pippo")
                .WithLastname("pluto")
                .WithGender('f')
                .WithPassword("bluemoon")
                .WithDob(DateTime.Now)
                .WithRole(mockedRole)
                .WithUsername("marione90")
                .WithRoleId(mockedRole.Id).Build();

            // create a test db in memoria -- not a mocked one

            var mockSet = new Mock<DeliveriamoContext>();
            IList<User> userentity = new List<User>() { mockedUser };
            mockSet.Setup(x => x.User).ReturnsDbSet(userentity);

            var repositoryService = new RepositoryService(mockSet.Object);



            //Act
            repositoryService.AddUser(mockedUser);
            repositoryService.SaveChanges();

            //Assert
            mockSet.Verify(x => x.AddAsync(It.IsAny<User>(), new CancellationToken()), Times.Once());
            
        }
    }


}
