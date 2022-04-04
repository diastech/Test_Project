using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dto.Entities
{
    public class OdaDTO :BaseDTO
    {
        [Required(ErrorMessage = "Numara alanı boş olamaz")]
        public int Numara { get; set; }
        public int BinaID { get; set; }
        public BinaDTO Bina { get; set; }
        
    }
}
