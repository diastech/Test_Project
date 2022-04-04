using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Envanter : BaseEntity,IEntity
    {
        public string Ad { get; set; }
        public int Numara { get; set; }
        public int Durum { get; set; }

        public List<Depo> Depos{ get; set; }
        public List<UrunYolu> UrunYolus { get; set; }
    }
}
