namespace DataAccess.Models
{
    public class User : Trackable
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
