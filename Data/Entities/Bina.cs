using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Bina : BaseEntity,IEntity
    {
        public string Ad { get; set; }
        public int Numara { get; set; }

        List<Oda> Odas { get; set; }
        public List<UrunYolu> UrunYolus { get; set; }
    }
}
