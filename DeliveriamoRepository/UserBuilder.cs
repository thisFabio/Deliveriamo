
using DeliveriamoRepository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnittestDeliveriamo.Entity
{
    public  class UserBuilder
    {
        private  User user = new ();

        public UserBuilder WithId(int Id)
        {
            user.Id = Id;
            return this;
        }

        public UserBuilder WithUsername(string Username)
        {
            user.Username = Username;
            return this;
        }

        public UserBuilder WithPassword(string Password)
        {
            user.Password = Password;
            return this;
        }

        public UserBuilder WithFirstname(string Firstname)
        {
            user.Firstname = Firstname;
            return this;
        }

        public UserBuilder WithLastname(string Lastname)
        {
            user.Lastname = Lastname;
            return this;
        }

        public UserBuilder WithDob(DateTime Dob)
        {
            user.Dob = Dob;
            return this;
        }

        public UserBuilder WithGender(char Gender)
        {
            user.Gender = Gender;
            return this;
        }
        public UserBuilder WithRoleId(int RoleId)
        {
            user.RoleId = RoleId;
            return this;
        }

        public UserBuilder WithEnabled(bool Enabled)
        {
            user.Enabled = Enabled;
            return this;
        }

        public UserBuilder WithRole(Role Role)
        {
            user.Role = Role;
            return this;
        }
        public UserBuilder WithPhoneNumber(string PhoneNumber)
        {
            user.PhoneNumber = PhoneNumber;
            return this;
        }

        public UserBuilder WithShopKeeper(bool ShopKeeper)
        {
            user.ShopKeeper = ShopKeeper;
            return this;
        }

        public UserBuilder WithBusinessTypeName(string BusinessTypeName)
        {
            user.BusinessTypeName = BusinessTypeName;
            return this;
        }
        public UserBuilder WithBusinessName(string BusinessName)
        {
            user.BusinessName = BusinessName;
            return this;
        }
        public UserBuilder WithExtendedCompanyName(string ExtendedCompanyName)
        {
            user.ExtendedCompanyName = ExtendedCompanyName;
            return this;
        }

        public UserBuilder WithVatNumber(string VatNumber)
        {
            user.VatNumber = VatNumber;
            return this;
        }

        public UserBuilder WithCompanyStreetAddress(string CompanyStreetAddress)
        {
            user.CompanyStreetAddress = CompanyStreetAddress;
            return this;
        }

        public UserBuilder WithCompanyCivicNumber(string CompanyCivicNumber)
        {
            user.CompanyCivicNumber = CompanyCivicNumber;
            return this;
        }

        public UserBuilder WithCompanyCity(string CompanyCity)
        {
            user.CompanyCity = CompanyCity;
            return this;
        }

        public UserBuilder WithCompanyPostalCode(string CompanyPostalCode)
        {
            user.CompanyPostalCode = CompanyPostalCode;
            return this;
        }
        public UserBuilder WithCompanyCountry(string CompanyCountry)
        {
            user.CompanyCountry = CompanyCountry;
            return this;
        }

        public User Build()
        {
            return user ;
        }

        public List<User> BuildMany(int number)
        {
            return Enumerable.Repeat(user, number).ToList();
        }

    }
}
