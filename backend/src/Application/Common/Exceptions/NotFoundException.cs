using System.Net;

namespace WillEnergy.Application.Common.Exceptions
{
    public class NotFoundException : AppException
    {
        private new const string RfcType = "https://tools.ietf.org/html/rfc7231#section-6.5.4";

        public NotFoundException(string name, object key)
            : base(HttpStatusCode.NotFound, RfcType, $"{name}(key={key}) not found.")
        {
        }

        public NotFoundException(string message)
            : base(HttpStatusCode.NotFound, RfcType, message)
        {
        }

        public NotFoundException()
            : base(nameof(HttpStatusCode.NotFound))
        {
        }
    }
}
