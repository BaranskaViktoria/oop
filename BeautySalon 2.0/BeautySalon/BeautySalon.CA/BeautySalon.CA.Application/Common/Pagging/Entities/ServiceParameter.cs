﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.CA.Application.Common.Pagging.Entities
{
    public class ServiceParameter : BaseParameter
    {
        public ServiceParameter()
        {
            OrderBy = "ServiceId"; // default sorting
        }
 
    }
}
