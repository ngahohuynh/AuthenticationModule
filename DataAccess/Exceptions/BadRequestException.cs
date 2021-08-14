using System.Net;

namespace DataAccess.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string msg) : base(HttpStatusCode.BadRequest, msg)
        {
        }
    }
}
