using AutoMapper;
using Ganesha.Core.Entities;
using Ganesha.Web.Models;

namespace Ganesha.Web.Mappings {
    public class ViewModelToDomainMappingProfile : Profile {
        public override string ProfileName => GetType().Name;
        public ViewModelToDomainMappingProfile() {
            CreateMap<FormationViewModel, Formation>();
        }
    }
}