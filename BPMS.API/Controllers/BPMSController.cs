using BPMS.BasicAuthentication;
using BPMS.Business.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BPMSController : ControllerBase
    {
        private readonly IDsaudctService _dsaudctService;
        private readonly IDsauddtService _dsauddtService;
        private readonly IDsaudmtService _dsaudmtService;
        private readonly IDsddertService _dsddertService;
        private readonly IDsiradtService _dsiradtService;
        private readonly IDsisdstService _dsisdstService;

        public BPMSController(IDsaudctService dsaudctService, IDsauddtService dsauddtService, IDsaudmtService dsaudmtService, IDsddertService dsddertService, IDsiradtService dsiradtService, IDsisdstService dsisdstService)
        {
            _dsaudctService = dsaudctService;
            _dsauddtService = dsauddtService;
            _dsaudmtService = dsaudmtService;
            _dsddertService = dsddertService;
            _dsiradtService = dsiradtService;
            _dsisdstService = dsisdstService;

        }




        [HttpGet("[action]"), BasicAuthorization]
        public IActionResult GetAllDsaudct()
        {
            var ListOfDsaudct = _dsaudctService.GetAll();
            if (ListOfDsaudct == null)
            {
                return NotFound();
                //return BadRequest("omid you faced a problem");
            }
            else
            {
                return Ok(ListOfDsaudct);
            }
        }


        [HttpGet("[action]"), BasicAuthorization]
        public IActionResult GetAllDsauddt()
        {
            var ListOfDsauddt = _dsauddtService.GetAll();
            if (ListOfDsauddt == null)
            {
                return NotFound();
                //return BadRequest("omid you faced a problem");
            }
            else
            {
                return Ok(ListOfDsauddt);
            }
        }


        [HttpGet("[action]"), BasicAuthorization]
        public IActionResult GetAllDsaudmt()
        {
            var ListOfDsaudmt = _dsaudmtService.GetAll();
            if (ListOfDsaudmt == null)
            {
                return NotFound();
                //return BadRequest("omid you faced a problem");
            }
            else
            {
                return Ok(ListOfDsaudmt);
            }
        }


        [HttpGet("[action]"), BasicAuthorization]
        public IActionResult GetAllDsddert()
        {
            var ListOfDsddert = _dsddertService.GetAll();
            if (ListOfDsddert == null)
            {
                return NotFound();
                //return BadRequest("omid you faced a problem");
            }
            else
            {
                return Ok(ListOfDsddert);
            }
        }


        [HttpGet("[action]"), BasicAuthorization]
        public IActionResult GetAllDsiradt()
        {
            var ListOfDsiradt = _dsiradtService.GetAll();
            if (ListOfDsiradt == null)
            {
                return NotFound();
                //return BadRequest("omid you faced a problem");
            }
            else
            {
                return Ok(ListOfDsiradt);
            }
        }


        [HttpGet("[action]"), BasicAuthorization]
        public IActionResult GetAllDsisdst()
        {
            var ListOfDsisdst = _dsisdstService.GetAll();
            if (ListOfDsisdst == null)
            {
                return NotFound();
                //return BadRequest("omid you faced a problem");
            }
            else
            {
                return Ok(ListOfDsisdst);
            }
        }



    }
}
