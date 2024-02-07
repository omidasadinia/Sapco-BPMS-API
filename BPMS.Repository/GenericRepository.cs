using BPMS.Domain.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private BPMS_Context _db;
        private static DbSet<TEntity> _dbSet;

        public GenericRepository(BPMS_Context context)
        {
            _db = context;
            _dbSet = _db.Set<TEntity>();

        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }
    }
}
