using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Add, AddForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    //p=>isMain de olabilir default verdik.
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.PhotoId == 1).Url);
                });
            CreateMap<Add, AddInfoDto>();

        }
    }
}
