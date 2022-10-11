using Microsoft.EntityFrameworkCore;
using System;
using TECH.Data.DatabaseEntity;

namespace TECH.Reponsitory
{
    public interface IAdminLoginRepository : IRepository<AdminLogin>
    {

    }

    public class AdminLoginRepository : EFRepository<AdminLogin>, IAdminLoginRepository
    {
        public AdminLoginRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
