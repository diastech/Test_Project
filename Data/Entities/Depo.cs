using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Depo : BaseEntity,IEntity
    {
        public string Ad { get; set; }
        public int EnvanterID { get; set; }

        public Envanter Envanter { get; set; }
    }
}
