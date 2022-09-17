using Deliveriamo.DTOs;
using Deliveriamo.DTOs.Register;
using Deliveriamo.Services.Exceptions;
using Deliveriamo.Services.Implementations;
using Deliveriamo.Services.Interfaces;
using DeliveriamoRepository;
using DeliveriamoRepository.Entity;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnittestDeliveriamo.Entity;
using Xunit;

namespace UnitTest.Deliveriamo
{
    public class RegisterServiceTests
    {

        /// <summary>
        ///     Testing AddUser() Method and all possible entries into CREATE Operation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="expected"></param>
        [Theory]
        //[InlineData(1, null, "Teodorio", "1976-04-27", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        //[InlineData(1, "Giovanni", null, "1976-04-27", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        //[InlineData(1, "Giovanni", "Teodorio", null, 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        //[InlineData(1, "Giovanni", "Teodorio", "1976-04-27", null, "giovaTEO@protonmail.com", "GattoMatto", false)]
        //[InlineData(1, "Giovanni", "Teodorio", "1976-04-27", 'M', null, "GattoMatto", false)]
        //[InlineData(1, "Giovanni", "Teodorio", "1976-04-27", 'M', "giovaTEO@protonmail.com", null, false)]
        ////empty string values 
        //[InlineData(1, "", "Teodorio", "1976-04-27", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        //[InlineData(1, "Giovanni", "", "1976-04-27", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        //[InlineData(1, "Giovanni", "Teodorio", "", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        //[InlineData(1, "Giovanni", "Teodorio", "1976-04-27", 'M', "", "GattoMatto", false)]
        //[InlineData(1, "Giovanni", "Teodorio", "1976-04-27", 'M', "giovaTEO@protonmail.com", "", false)]
        //// wrong charachter
        //[InlineData(1, "Giovanni", "Teodorio", "1976-04-27", '1', "giovaTEO@protonmail.com", "GattoMatto", false)]
        ////not valid datetime
        //[InlineData(1, "Giovanni", "Teodorio", "1", 'M', "giovaTEO@protonmail.com", "GattoMatto", false)]
        // correct insert
        [InlineData(1, "Giovanni", "Teodorio", "1976 - 04 - 27", 'M', "giovaTEO@protonmail.com", "GattoMatto", true)]
        
        public async void AddUser_Should_ThrowExceptionWhenUserAlreadyExist(
            int id,
            string firstname,
            string lastname,
            string dob,
            char gender,
            string username,
            string password,
            bool expected
            )
        {
            // Arrange:
            var _cryptoService = new CryptoService();
            var _repositoryService = new Mock<IRepositoryService>();

            DateTime DOB;
            DateTime.TryParse(dob, out DOB);

            var fakeRequest = new RegisterRequestDto()
            {
                Firstname = firstname,
                Lastname = lastname,
                Dob = DOB,
                Gender = gender,
                Username = username,
                Password = password

            };


            // DRIVERS :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // 
            // fai finta che... quando chiamo il metodo USernameAlreadyExist --> return expected.
            _repositoryService.Setup(x => x.UsernameAlreadyExist(username)).Returns(Task.FromResult(expected));


            var _fakeRegisterService = new RegisterService(_cryptoService, _repositoryService.Object);

            //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // Act:

            // catch dell'eccezione - controlla che l'eccezione useralreadyexistexception sia stata lanciata e salva il risultato   
            // nella variabile result.
            var result = await Assert.ThrowsAsync<UserAlreadyExistException>(() => _fakeRegisterService.AddUser(fakeRequest));

            //Assert:
            // verifico che il messaggio salvato nella variabile result e quello indicato nel metodo siano identici
            Assert.True(result.Message == $"username {username} already exist.");


        }


        // 1. verificare che quando chiamo AddUserShop() tutti i campi esercente vengano compilati e salvati nel DB.
        [Fact]
        public async void AddUserShop_Should_Return_Full_User()
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
                .WithShopKeeper(true)
                .WithPhoneNumber("0456789")
                .WithBusinessTypeId(1)
                .WithExtendedCompanyName("Sorbillo srl")
                .WithBusinessName("Da Sorbillo")
                .WithVatNumber("123456789")
                .WithCompanyStreetAddress("Corso Italia")
                .WithCompanyCivicNumber("1")
                .WithCompanyCity("Napoli")
                .WithCompanyPostalCode("12345")
                .WithCompanyCountry("Italia")
                .Build();

            // create a test db in memoria -- not a mocked one
            var optionsDb = new DbContextOptionsBuilder<DeliveriamoContext>().UseInMemoryDatabase("TestDeliveriamo").Options;
            var dbContext = new DeliveriamoContext(optionsDb);

            var repositoryService = new RepositoryService(dbContext);

            //Act
            var result = await repositoryService.AddUserShop(mockedUser);
            repositoryService.SaveChanges();

            //Assert
            //verificare che ci sia il match delle nuove proprietà.
            result.Id.Should().Be(mockedUser.Id);
        }

        [Fact]
        public async void AddUserShop_Should_Populate_DB()
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
                .WithShopKeeper(true)
                .WithPhoneNumber("0456789")
                .WithBusinessTypeId(1)
                .WithExtendedCompanyName("Sorbillo srl")
                .WithBusinessName("Da Sorbillo")
                .WithVatNumber("123456789")
                .WithCompanyStreetAddress("Corso Italia")
                .WithCompanyCivicNumber("1")
                .WithCompanyCity("Napoli")
                .WithCompanyPostalCode("12345")
                .WithCompanyCountry("Italia")
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

        // 2. verificare che quando chiamo AddUSerShop() con campi mancanti, faccia una throwExeption
        //    di una eccezione gestita Assert.Throws<MyCustomException>(() => repo.AddShop(fakeShop)
        [Fact]
        public async void AddUserShop_When_MissingInfo_Throws_CustomExeption()
        {
            //Arrange
            // creo la fake shop keeper request 
            var fakeRequest = new RegisterShopRequestDto()
            {
                Username = null,
                Password = "prova",
                Firstname = "pro",
                Lastname = "va",
                Gender = 'F',
                Dob = DateTime.Now,
                ShopKeeper = true,
                BusinessTypeId = 2,
                BusinessName = "provazienda",
                ExtendedCompanyName = "prova azienda srl",
                PhoneNumber = "0987654321",
                VatNumber = "987654321",
                CompanyStreetAddress = "via delle rose",
                CompanyCivicNumber = "11",
                CompanyPostalCode = "0000",
                CompanyCity = "Livigno",
                CompanyCountry = "Italy"


            };
            // creo la variabile booleana che vado a confrontare
            bool expected = true;

            // creo il fake service
            var _cryptoService = new CryptoService();
            var _repositoryService = new Mock<IRepositoryService>();

            var _fakeRegisterService = new RegisterService(_cryptoService, _repositoryService.Object);

            //Act
            //incapsulo nella variabile le eccezioni che vengono generate in seguito alla chiamata di AddUserShop
            var result = await Assert.ThrowsAsync<InvalidOperationException>(() => _fakeRegisterService.AddUserShop(fakeRequest));

            //Assert
            if (expected) // se è vero che mi genera una eccezione quando passo un valore nullo.
            {
                result.Should().NotBeNull(); // allora la variabile result deve essere popolata.
            }
            else
            {
                result.Should().BeNull(); // altrimenti la variabile result è vuota perchè non ci sono state eccezioni.
            }


        }
        [Fact]
        // 3. verificare In AddUserShopTest che venga controllato se esiste già la partita iva o meno (se flaggato esercente)
        public async void AddUserShop_When_PIVA_AlreadyExist_Throws_PIVA_Exeptions()
        {
            //Arrange
            var _cryptoService = new CryptoService();
            var _repositoryService = new Mock<IRepositoryService>();

            // creo la fake shop keeper request 
            var fakeRequest = new RegisterShopRequestDto()
            {
                Username = "prova44@gmail.com",
                Password = "prova",
                Firstname = "pro",
                Lastname = "va",
                Gender = 'F',
                Dob = DateTime.Now,
                ShopKeeper = true,
                BusinessTypeId = 2,
                BusinessName = "provazienda",
                ExtendedCompanyName = "prova azienda srl",
                VatNumber = "987654321",
                CompanyStreetAddress = "via delle rose",
                CompanyCivicNumber = "11",
                CompanyPostalCode = "0000",
                CompanyCity = "Livigno",
                CompanyCountry = "Italy"
            };
           
            // fai finta che... quando chiamo il metodo USernameAlreadyExist --> return expected.
            _repositoryService.Setup(x => x.UsernameAlreadyExist(fakeRequest.Username)).Returns(Task.FromResult(true));


            var _fakeRegisterService = new RegisterService(_cryptoService, _repositoryService.Object);

            //Act
            var result = await Assert.ThrowsAsync<UserAlreadyExistException>(() => _fakeRegisterService.AddUserShop(fakeRequest));

            //Assert
            // verifico che il messaggio salvato nella variabile result e quello indicato nel metodo siano identici
            Assert.True(result.Message == $"username {fakeRequest.Username} already exist.");

        }

    }
}
