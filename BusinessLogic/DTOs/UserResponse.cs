using DataAccess.Enums;

namespace BusinessLogic.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public UserType Type { get; set; }
    }

    public class TokenResponse
    {
        public string Token { get; set; }

        public UserResponse User { get; set; }
    }
}
