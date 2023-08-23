using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteJaar.Infra.Context;
using TesteJaar.Infra.Repository;

namespace TesteJaar.Infra.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        IRepositoryAsync<TEntity> GetRepositoryAsync<TEntity>() where TEntity : class;

        ClientContext Context { get; }
        int Save();
        Task<int> SaveAsync();
    }

}
