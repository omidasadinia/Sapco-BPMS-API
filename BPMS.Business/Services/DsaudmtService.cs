using BPMS.Business.IServices;
using BPMS.Domain.Entities;
using BPMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Business.Services
{
    public class DsaudmtService : IDsaudmtService
    {
        private readonly IGenericRepository<Dsaudmt> _dsaudmtRepository;

        public DsaudmtService(IGenericRepository<Dsaudmt> DsaudmtRepository)
        {
            _dsaudmtRepository = DsaudmtRepository;
        }

        public IEnumerable<Dsaudmt> GetAll()
        {
            try
            {
                return _dsaudmtRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
