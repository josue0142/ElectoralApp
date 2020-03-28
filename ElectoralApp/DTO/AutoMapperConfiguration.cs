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
            ConfigureCandidato();
            ConfigurePartido();
        }

        private void ConfigureCandidato()
        {
            CreateMap<CandidatosDTO, Candidatos>();

            CreateMap<Candidatos, CandidatosDTO>().ForMember(dest => dest.FotoDePerfil, opt => opt.Ignore());
        }

        private void ConfigurePartido()
        {
            CreateMap<PartidosDTO, Partidos>();

            CreateMap<Partidos, PartidosDTO>().ForMember(dest => dest.LogoDelPartido, opt => opt.Ignore());
        }
    }
}
