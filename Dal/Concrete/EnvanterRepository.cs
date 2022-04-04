using Dal.Repository;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Concrete
{
    public class EnvanterRepository : BaseRepository<Envanter>, IEnvanterRepository
    {
        public EnvanterRepository(DiasContext diasContext) : base(diasContext)
        {

        }
    }
}
