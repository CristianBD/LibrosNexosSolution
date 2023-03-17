using AutoMapper;
using LibrosNexos.Domain.Entities;
using LibrosNexos.Infrastucture.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosNexos.Infrastucture.Mapping
{
    public class TBL_GENEROS_GenerosViewModel : Profile
    {
        public TBL_GENEROS_GenerosViewModel()
        {
            CreateMap<TBL_GENEROS, GeneroViewModel>().ReverseMap();
        }
    }
}
