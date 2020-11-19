using System.Net;

namespace WillEnergy.Application.Common.Exceptions
{
    public class ConflictException : AppException
    {
        private new const string RfcType = "https://tools.ietf.org/html/rfc7231#section-6.5.8";

        public ConflictException(string message)
            : base(HttpStatusCode.Conflict, RfcType, message)
        {
        }

        public ConflictException()
            : base(nameof(HttpStatusCode.Conflict))
        {
        }
    }
}
