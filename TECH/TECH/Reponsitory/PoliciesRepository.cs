using Microsoft.EntityFrameworkCore;
using System;
using TECH.Data.DatabaseEntity;

namespace TECH.Reponsitory
{
    public interface IPoliciesRepository : IRepository<Policies>
    {
    }

    public class PoliciesRepository : EFRepository<Policies>, IPoliciesRepository
    {
        public PoliciesRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
