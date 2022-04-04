using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class User : BaseEntity,IEntity
    {
        public string KullaniciAdi { get; set; }
        public string Password { get; set; }
    }
}
