using StoriesReadingAPI.Models;
using StoriesReadingAPI.Services.ServiceModels;

namespace StoriesReadingAPI.Services.Interfaces
{
    public interface IAdminService
    {
        void PostText(TextAdminServiceModel textAdminServiceModel);
    }
}
