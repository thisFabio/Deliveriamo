
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
