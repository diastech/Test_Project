using Dal.Repository;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Concrete
{
    public class UrunYoluRepository : BaseRepository<UrunYolu>, IUrunYoluRepository
    {
        public UrunYoluRepository(DiasContext diasContext) : base(diasContext)
        {

        }
    }
}
