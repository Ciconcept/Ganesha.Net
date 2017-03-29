﻿using AutoMapper;

namespace Ganesha.Web.Mappings {
    public class AutoMapperConfiguration {
        public static void Configure() {
            Mapper.Initialize(x => {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}