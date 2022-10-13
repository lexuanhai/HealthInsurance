using Microsoft.EntityFrameworkCore;
using System;
using TECH.Data.DatabaseEntity;

namespace TECH.Reponsitory
{
    public interface IContractRepository : IRepository<Contract>
    {

    }

    public class ContractRepository : EFRepository<Contract>, IContractRepository
    {
        public ContractRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
