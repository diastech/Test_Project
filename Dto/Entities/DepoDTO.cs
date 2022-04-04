using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Entities
{
    public class DepoDTO : BaseDTO
    {
        public string Ad { get; set; }
        public int EnvanterID { get; set; }

        public EnvanterDTO Envanter { get; set; }
    }
}
