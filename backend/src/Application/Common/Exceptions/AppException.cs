using System;
using System.Net;

namespace WillEnergy.Application.Common.Exceptions
{
    public abstract class AppException : Exception
    {
        private const string InternalRfcType = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
        public HttpStatusCode Status { get; }
        public string RfcType { get; }

        public AppException(HttpStatusCode status, string rfcType, string message)
            : base(message)
        {
            Status = status;
            RfcType = rfcType;
        }

        public AppException(string message)
            : base(message)
        {
            Status = HttpStatusCode.InternalServerError;
            RfcType = InternalRfcType;
        }

        public AppException()
            : base(nameof(HttpStatusCode.InternalServerError))
        {
            Status = HttpStatusCode.InternalServerError;
            RfcType = InternalRfcType;
        }
    }
}
