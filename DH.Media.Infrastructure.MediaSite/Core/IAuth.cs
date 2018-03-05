using RestSharp;

namespace DH.Media.Infrastructure.Media.Core
{
    internal interface IAuth
    {
        void Authenticate(IRestClient client, IRestRequest request);
    }
}
