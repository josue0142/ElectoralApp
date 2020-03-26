using AutoMapper;
using ElectoralApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectoralApp.DTO
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            ConfigureCiudadano();
        }

        private void ConfigureCiudadano()
        {
            CreateMap<Ciudadanos, CiudadanosDTO>();
        }
    }
}
