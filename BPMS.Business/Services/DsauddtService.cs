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
    public class DsauddtService : IDsauddtService
    {
        private readonly IGenericRepository<Dsauddt> _dsauddtRepository;

        public DsauddtService(IGenericRepository<Dsauddt> DsauddtRepository)
        {
            _dsauddtRepository = DsauddtRepository;
        }

        public IEnumerable<Dsauddt> GetAll()
        {
            try
            {
                return _dsauddtRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
