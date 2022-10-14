using AutoMapper;
using APIFilmes.Data.Dtos;
using APIFilmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFilmes.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>();
            CreateMap<Filme, ReadFilmeDto>();
            CreateMap<UpdateFilmeDto, Filme>();
        }
    }
}
