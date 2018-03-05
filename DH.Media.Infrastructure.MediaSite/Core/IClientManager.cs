using RestSharp;

namespace DH.Media.Infrastructure.Media.Core
{
    public interface IClientManager
    {
        RestClient Client { get; }       
    }
}
