using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class UrunYolu : BaseEntity,IEntity
    {
        public string Envanteradi { get; set; }
        public int OdaId { get; set; }
        public int EnvanterId { get; set; }
        public Oda Oda { get; set; }
        public Envanter Envanter { get; set; }
    }
}
