using AutoMapper;
using Ganesha.Core.Entities;
using Ganesha.Web.Models;

namespace Ganesha.Web.Mappings {
    public class DomainToViewModelMappingProfile : Profile {
        public override string ProfileName => GetType().Name;
        public DomainToViewModelMappingProfile() {
            CreateMap<Formation, FormationViewModel>();
        }
    }
}