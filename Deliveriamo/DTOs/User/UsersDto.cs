namespace Deliveriamo.DTOs.User
{
    public class UsersDto
    {
        public UsersDto(int id, string username, string firstname, string lastname)
        {
            Id = id;
            Username = username;
            Firstname = firstname;
            Lastname = lastname;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
