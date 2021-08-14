using DataAccess.Enums;
using DataAccess.Utils;
using System;

namespace DataAccess.Models
{
    public class User : Trackable
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserType Type { get; set; }

        public static User[] InitUserData()
        {
            return new User[]
            {
                new User() { Id = 1, Name = "Admin", Username = "admin", Password = "admin123".EncodePassword(), Type = UserType.Admin, CreatedDate = DateTime.Now, Valid = true },               
                new User() { Id = 2, Name = "Seller 1", Username = "seller1", Password = "seller123".EncodePassword(), Type = UserType.Seller, CreatedDate = DateTime.Now, Valid = true },               
                new User() { Id = 3, Name = "Buyer 1", Username = "buyer1", Password = "buyer123".EncodePassword(), Type = UserType.Buyer, CreatedDate = DateTime.Now, Valid = true },               
            };
        }
    }
}
