using VF_API.Models;
using VF_API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VF_API.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        LocalSkillDBContext GetContext();
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
