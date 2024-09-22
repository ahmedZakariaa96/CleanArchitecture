using Application.DTO;

namespace Application.Handlers.LookupsFeature.Services
{
    public interface IHelperService
    {
        Task<DropDownsDTO> FillDropDowns(List<int> PagesID);

    }
}
