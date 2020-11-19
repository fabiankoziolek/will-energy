using System.Net;

namespace WillEnergy.Application.Common.Exceptions
{
    public class BadRequestException : AppException
    {
        private new const string RfcType = "https://tools.ietf.org/html/rfc7231#section-6.5.1";

        public BadRequestException(string message)
            : base(HttpStatusCode.BadRequest, RfcType, message)
        {
        }

        public BadRequestException()
            : base(nameof(HttpStatusCode.BadRequest))
        {
        }
    }
}
