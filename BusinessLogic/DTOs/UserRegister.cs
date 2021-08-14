using DataAccess.Enums;

namespace BusinessLogic.DTOs
{
    public class UserRegister
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserType Type { get; set; }
    }
}
