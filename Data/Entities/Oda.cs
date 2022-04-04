using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Oda : BaseEntity, IEntity
    {
        public int Numara { get; set; }
        public int BinaID { get; set; }
        public Bina Bina { get; set; }

        public List<UrunYolu> UrunYolus {get;set;}
    }
}
