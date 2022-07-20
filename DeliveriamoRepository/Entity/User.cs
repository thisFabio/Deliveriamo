namespace DeliveriamoRepository.Entity
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
        public int RoleId { get; set; }
        public bool Enabled { get; set; }

        public Role Role { get; set; }
    }
}
