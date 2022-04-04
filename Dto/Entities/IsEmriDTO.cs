using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Entities
{
    public class IsEmriDTO : BaseDTO
    {
        public string Ad { get; set; }
        public int OdaId { get; set; }
        public int EnvanterId { get; set; }
        public OdaDTO Oda { get; set; }
        public EnvanterDTO Envanter { get; set; }

    }
}
