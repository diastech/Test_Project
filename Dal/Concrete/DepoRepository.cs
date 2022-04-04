using Dal.Repository;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Concrete
{
    public class DepoRepository : BaseRepository<Depo>, IDepoRepository
    {
        public DepoRepository(DiasContext diasContext) : base(diasContext)
        {

        }
    }
}
