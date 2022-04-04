using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Entities
{
    public class BaseDTO
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public bool SilindiMi { get; set; }
    }
}
