﻿using BPMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPMS.Business.IServices
{
    public interface IDsaudmtService
    {
        IEnumerable<Dsaudmt> GetAll();
    }
}
