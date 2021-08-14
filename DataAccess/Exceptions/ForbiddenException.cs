using System.Net;

namespace DataAccess.Exceptions
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(string msg) : base(HttpStatusCode.Forbidden, msg)
        {
        }
    }
}
