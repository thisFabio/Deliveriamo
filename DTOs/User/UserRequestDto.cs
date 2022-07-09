namespace Deliveriamo.DTOs.User
{
    public class UserRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Dob { get; set; }
        public char Gender { get; set; }
        public int Role { get; set; }

    }
}
