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
    public class DsiradtService : IDsiradtService
    {
        private readonly IGenericRepository<Dsiradt> _dsiradtRepository;

        public DsiradtService(IGenericRepository<Dsiradt> DsiradtRepository)
        {
            _dsiradtRepository = DsiradtRepository;
        }

        public IEnumerable<Dsiradt> GetAll()
        {
            try
            {
                return _dsiradtRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
