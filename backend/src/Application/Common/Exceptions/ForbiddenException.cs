using System.Net;

namespace WillEnergy.Application.Common.Exceptions
{
    public class ForbiddenException : AppException
    {
        private new const string RfcType = "https://tools.ietf.org/html/rfc7231#section-6.5.3";

        public ForbiddenException(string message)
            : base(HttpStatusCode.Forbidden, RfcType, message)
        {
        }

        public ForbiddenException()
            : base(nameof(HttpStatusCode.Forbidden))
        {
        }
    }
}
