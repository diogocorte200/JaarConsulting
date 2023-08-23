using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteJaar.Infra.Context;
using TesteJaar.Infra.Entity;
using TesteJaar.Infra.Repositories.Interfaces;

namespace TesteJaar.Infra.Repositories
{
    public class VeiculoRepository : RepositoryGeneric<Veiculo>, IveiculoRepository
    {
        private ClientContext _appContext => (ClientContext)_context;

        public VeiculoRepository(ClientContext context) : base(context)
        { }

    }
}
