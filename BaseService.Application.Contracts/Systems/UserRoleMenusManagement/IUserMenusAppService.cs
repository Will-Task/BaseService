using System.Threading.Tasks;
using BaseService.Systems.UserRoleMenusManagement.Dto;
using Volo.Abp.Application.Services;

namespace BaseService.Systems.UserRoleMenusManagement
{
    public interface IUserMenusAppService : IApplicationService
    {
        Task<UserMenuPermissionsDto> GetUserMenuPermission();
    }
}
