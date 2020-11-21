using System;
using RestSharp;

namespace WillEnergy.Infrastructure.Client
{
    public class NewtonSoftRestRequest : RestRequest
    {
        public NewtonSoftRestRequest() : base()
        {
            SetOwnSerializer();
        }

        public NewtonSoftRestRequest(Uri resource) : base(resource)
        {
            SetOwnSerializer();
        }
        public NewtonSoftRestRequest(string resource) : base(resource)
        {
            SetOwnSerializer();
        }

        public NewtonSoftRestRequest(Method method) : base(method)
        {
            SetOwnSerializer();
        }

        public NewtonSoftRestRequest(Uri resource, Method method) : base(resource, method)
        {
            SetOwnSerializer();
        }
        public NewtonSoftRestRequest(string resource, Method method) : base(resource, method)
        {
            SetOwnSerializer();
        }

        private void SetOwnSerializer()
        {
            RequestFormat = DataFormat.Json;
            JsonSerializer = new NewtonsoftJsonSerializer();
        }
    }

}
