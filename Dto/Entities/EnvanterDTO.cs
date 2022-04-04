using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dto.Entities
{
    public class EnvanterDTO : BaseDTO
    {
        [Required(ErrorMessage = "Ad alanı boş olamaz")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Numara alanı boş olamaz")]
        public int Numara { get; set; }
        public int Durum { get; set; }
    }
}
