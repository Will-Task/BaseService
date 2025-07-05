using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BaseService.BaseData.DataDictionaryManagement.Dto;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BaseService.BaseData.DataDictionaryManagement
{
    public interface IDictionaryDetailAppService : IApplicationService
    {
        Task<PagedResultDto<DictionaryDetailDto>> GetAll(GetDictionaryDetailInputDto input);

        Task<ListResultDto<DictionaryDetailDto>> GetAllByDictionaryName(string name);

        Task<DictionaryDetailDto> Get(Guid id);

        Task<DictionaryDetailDto> Create(CreateOrUpdateDictionaryDetailDto input);

        Task<DictionaryDetailDto> Update(Guid id, CreateOrUpdateDictionaryDetailDto input);

        Task Delete(List<Guid> ids);
    }
}
