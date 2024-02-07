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
    public class DsaudctService : IDsaudctService
    {
        private readonly IGenericRepository<Dsaudct> _dsaudctRepository;

        public DsaudctService(IGenericRepository<Dsaudct> DsaudctRepository)
        {
            _dsaudctRepository = DsaudctRepository;
        }

        public IEnumerable<Dsaudct> GetAll()
        {
            try
            {
                return _dsaudctRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
