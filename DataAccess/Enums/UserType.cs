using System.Text.Json.Serialization;

namespace DataAccess.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserType
    {
        Admin,
        Seller,
        Buyer
    }
}
