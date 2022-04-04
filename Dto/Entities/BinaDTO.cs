using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dto.Entities
{
    public class BinaDTO : BaseDTO
    {
        [Required(ErrorMessage = "Ad alanı boş olamaz")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Numara alanı boş olamaz")]
        public int Numara { get; set; }
        public int OdaID { get; set; }

        public List<OdaDTO> Odas { get; set; }
    }
}
