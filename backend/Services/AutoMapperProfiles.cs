using AutoMapper;
using Challenge_n5.Models;
using Challenge_n5.Views;
using System.Collections.Generic;

namespace Challenge_n5.Services
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PermisoDTO, Permiso>();
            CreateMap<PermisoConsultaDTO, Permiso>();
            CreateMap<Permiso, PermisoConsultaDTO>();
            CreateMap<Permiso, PermisoDTO>();
            CreateMap<TipoPermisoDTO, TipoPermiso>();            
            CreateMap<TipoPermiso, TipoPermisoDTO>();
            CreateMap<TipoPermisoCreacionDTO,TipoPermiso>();
            CreateMap<PermisoCreacionDTO, Permiso>();

        }

       
      
    }
}

