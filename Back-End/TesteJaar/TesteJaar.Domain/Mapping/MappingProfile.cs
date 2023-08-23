using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteJaar.Domain.Domain;
using TesteJaar.Infra.Entity;

namespace TesteJaar.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VeiculoModel, Veiculo>();
            CreateMap<Veiculo, VeiculoModel>();
            CreateMap<Guid, int>();
            CreateMap<int, Guid>();
        }
    }
}
