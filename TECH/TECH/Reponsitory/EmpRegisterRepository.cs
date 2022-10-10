using Microsoft.EntityFrameworkCore;
using System;
using TECH.Data.DatabaseEntity;

namespace TECH.Reponsitory
{
    public interface IEmpRegisterRepository : IRepository<EmpRegister>
    {

    }

    public class EmpRegisterRepository : EFRepository<EmpRegister>, IEmpRegisterRepository
    {
        public EmpRegisterRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
