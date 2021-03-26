using AutoMapper;
using RallyDakar.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyDaka.API.Mapper
{
    public class PilotoProfile:Profile
    {
        public PilotoProfile()
        {
            CreateMap<Piloto, PilotoProfile>().ReverseMap();
        }
    }
}
