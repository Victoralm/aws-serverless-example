using CoreWebApi.Models;

namespace CoreWebApi.Repositories;

public interface IDol2RealRepository
{
    Task<Response> GetDol2Real();
}
