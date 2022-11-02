
using Cookie_MVC.Models;

namespace Cookie_MVC.Services.Interfaces
{
    public interface ICookieService
    {

        Task<IEnumerable<Cookie>> FindAll();

        Task<Cookie> FindOne(int id);
    }
}
