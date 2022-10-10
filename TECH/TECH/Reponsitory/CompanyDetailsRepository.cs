using Microsoft.EntityFrameworkCore;
using System;
using TECH.Data.DatabaseEntity;

namespace TECH.Reponsitory
{
    public interface ICompanyDetailsRepository : IRepository<CompanyDetails>
    {

    }

    public class CompanyDetailsRepository : EFRepository<CompanyDetails>, ICompanyDetailsRepository
    {
        public CompanyDetailsRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
