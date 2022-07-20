using Deliveriamo.DTOs.Register;
using DeliveriamoRepository.Entity;
namespace Deliveriamo.DTOs
{
    public static class ExtensionsMethods
    {

        public static DeliveriamoRepository.Entity.User ToEntity(this RegisterRequestDto request,string hashedPassword)
        {
            return new DeliveriamoRepository.Entity.User()
            {
                Username = request.Username.ToLower(),
                Password = hashedPassword,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Dob = Convert.ToDateTime(request.Dob),
                RoleId = 2,
                Gender = request.Gender,
                Enabled = true
            };
        }
    }
}
