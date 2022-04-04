using Dal.Repository;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Concrete
{
    public class OdaRepository : BaseRepository<Oda>, IOdaRepository
    {
        public OdaRepository(DiasContext diasContext) : base(diasContext)
        {

        }
    }
}
