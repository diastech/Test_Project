using Dal.Repository;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Concrete
{
    public class IsEmriRepository : BaseRepository<IsEmri>, IIsEmriRepository
    {
        public IsEmriRepository(DiasContext diasContext) : base(diasContext)
        {

        }
    }
}
