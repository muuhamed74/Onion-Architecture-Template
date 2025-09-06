using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionTemplate.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity> Reposit<TEntity>() where TEntity : Entities.BaseEntity;
        Task<int> CompleteAsync();

    }
}
