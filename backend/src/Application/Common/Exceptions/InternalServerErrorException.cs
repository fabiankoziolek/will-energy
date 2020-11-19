using System.Net;

namespace WillEnergy.Application.Common.Exceptions
{
    public class InternalServerErrorException : AppException
    {
        private new const string RfcType = "https://tools.ietf.org/html/rfc7231#section-6.6.1";

        public InternalServerErrorException(string message)
            : base(HttpStatusCode.InternalServerError, RfcType, message)
        {
        }

        public InternalServerErrorException()
            : base(nameof(HttpStatusCode.InternalServerError))
        {
        }
    }
}
