namespace Deliveriamo.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Dob { get; set; }
        public char Gender { get; set; }
        public int Role { get; set; }
        public bool Enabled { get; set; }
    }
}
