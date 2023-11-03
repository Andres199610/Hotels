using Hotel.Shared.Responses;

namespace Hotel.API.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }

}
