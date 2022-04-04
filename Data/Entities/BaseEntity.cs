using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public bool SilindiMi { get; set; }
    }
}
