using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiasProject.Enum
{
    public enum EnvanterDurumEnum
    {
        [Display(Name = "DEPODA")] depo = 0,
        [Display(Name = "ODADA")] oda = 1,
        
    }
}
