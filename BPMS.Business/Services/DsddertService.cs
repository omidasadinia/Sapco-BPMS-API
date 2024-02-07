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
    public class DsddertService : IDsddertService
    {
        private readonly IGenericRepository<Dsddert> _dsddertRepository;

        public DsddertService(IGenericRepository<Dsddert> DsddertRepository)
        {
            _dsddertRepository = DsddertRepository;
        }

        public IEnumerable<Dsddert> GetAll()
        {
            try
            {
                return _dsddertRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
