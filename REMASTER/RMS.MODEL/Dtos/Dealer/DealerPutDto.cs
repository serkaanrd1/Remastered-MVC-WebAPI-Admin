﻿using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Dtos.Dealer
{
    public class DealerPutDto : IDto
    {


        public int DealerID { get; set; }
        public string? DealerName { get; set; }

        public string? DealerCity { get; set; }

        public string? DealerNumber { get; set; }
        public bool? IsActive { get; set; }
        public int? DealerCapacty { get; set; }






    }
}