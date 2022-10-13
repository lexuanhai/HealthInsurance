using Microsoft.EntityFrameworkCore;
using System;
using TECH.Data.DatabaseEntity;

namespace TECH.Reponsitory
{
    public interface IPoliciesonEmployeesRepository : IRepository<PoliciesonEmployees>
    {
    }

    public class PoliciesonEmployeesRepository : EFRepository<PoliciesonEmployees>, IPoliciesonEmployeesRepository
    {
        public PoliciesonEmployeesRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
