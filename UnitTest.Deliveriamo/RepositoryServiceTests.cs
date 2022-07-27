using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
using FluentAssertions;
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
using Xunit;

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
                    .WithRoleId(1)
                    .WithUsername("marione90")
                    .Build();

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

        //b1f3676cce8d9cb94e3a8e152f78c713 bluemoon
        [Theory]
        [InlineData("ciccio", "b1f3676cce8d9cb94e3a8e152f78c713", true)]
        [InlineData("CICCIO", "b1f3676cce8d9CB94e3a8e152f78c713", true)]
        [InlineData("ciccio", "", false)]
        [InlineData("", "b1f3676cce8d9cb94e3a8e152f78c713", false)]
        [InlineData("PROVA", "PROVA", false)]

        [InlineData(null, null, false)]
        [InlineData(null, "b1f3676cce8d9cb94e3a8e152f78c713", false)]
        [InlineData("ciccio", null, false)]

        public async void CheckLogin_Test_Should_Return_Valid_logins(string username, string password, bool expected)
        {
            //Arrange
            bool actual = false;
            var mockedRole = new Role() { Id = 1, RoleName = "admin" };
            var mockedUser = new UserBuilder()
                .WithId(1)
                .WithFirstname("pippo")
                .WithLastname("pluto")
                .WithGender('f')
                .WithPassword("b1f3676cce8d9cb94e3a8e152f78c713")
                .WithDob(DateTime.Now)
                .WithRole(mockedRole)
                .WithUsername("ciccio")
                .Build();

            // create a test db in memoria -- not a mocked one
            var optionsDb = new DbContextOptionsBuilder<DeliveriamoContext>().UseInMemoryDatabase("TestDeliveriamo").Options;
            var dbContext = new DeliveriamoContext(optionsDb);

            var repositoryService = new RepositoryService(dbContext);
            repositoryService.AddUser(mockedUser);
            repositoryService.SaveChanges();

            //Act
            var response = await repositoryService.CheckLogin(username, password);

            //Assert
            if (expected)
            {
                response.Should().NotBeNull();

            }
            else
            {
                response.Should().BeNull();
            }

        }

        // 1. verificare che quando chiamo AddUserShop() tutti i campi esercente vengano compilati e salvati nel DB.
        [Theory]
        [InlineData()]
        public async void AddUserShop_Should_Return_Full_User(User user)
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
                .WithRoleId(1)
                .WithUsername("marione90")
                //.WithIsShop(true)
               // .With()// TODO CF7 - AGGIUNGERE CAMPI
                .Build();

            // create a test db in memoria -- not a mocked one
            var optionsDb = new DbContextOptionsBuilder<DeliveriamoContext>().UseInMemoryDatabase("TestDeliveriamo").Options;
            var dbContext = new DeliveriamoContext(optionsDb);

            var repositoryService = new RepositoryService(dbContext);

            //Act
            var result = await repositoryService.AddUserShop(mockedUser);
            repositoryService.SaveChanges();

            //Assert
            //TODO - verificare che ci sia il match delle nuove proprietà.
            result.Id.Should().Be(mockedUser.Id);
        }

        [Fact]
        public async void AddUserShop_Should_Populate_DB(User user)
        {

        }

        // 2. verificare che quando chiamo AddUSerShop() con campi mancanti, faccia una throwExeption
        //    di una eccezione gestita Assert.Throws<MyCustomException>(() => repo.AddShop(fakeShop)
        [Fact]
        public async void AddUserShop_When_MissingInfo_Throws_CustomExeption(User user)
        {

        }
        // 3. verificare In AddUserTest che venga controllato se esiste già la partita iva o meno (se flaggato esercente)
        [Fact]
        public async void AddUserShop_When_PIVA_AlreadyExist_Throws_PIVA_Exeptions(User user)
        {

        }
    }


}
