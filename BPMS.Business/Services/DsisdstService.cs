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
    public class DsisdstService : IDsisdstService
    {
        private readonly IGenericRepository<Dsisdst> _dsisdstRepository;

        public DsisdstService(IGenericRepository<Dsisdst> DsisdstRepository)
        {
            _dsisdstRepository = DsisdstRepository;
        }

        public IEnumerable<Dsisdst> GetAll()
        {
            try
            {
                return _dsisdstRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
