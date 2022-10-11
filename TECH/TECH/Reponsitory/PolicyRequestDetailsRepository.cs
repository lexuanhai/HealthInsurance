using Microsoft.EntityFrameworkCore;
using System;
using TECH.Data.DatabaseEntity;

namespace TECH.Reponsitory
{
    public interface IPolicyRequestDetailsRepository : IRepository<PolicyRequestDetails>
    {
    }

    public class PolicyRequestDetailsRepository : EFRepository<PolicyRequestDetails>, IPolicyRequestDetailsRepository
    {
        public PolicyRequestDetailsRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
