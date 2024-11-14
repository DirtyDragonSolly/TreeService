using AutoMapper;
using TreeService.Models.Entities;
using TreeService.Models.Responses.FolderModels;

namespace TreeService.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Folder, GetFolderResponse>();
        }
    }
}
