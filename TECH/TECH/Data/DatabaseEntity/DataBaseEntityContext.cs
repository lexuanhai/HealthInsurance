using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TECH.Data.DatabaseEntity
{
    public class DataBaseEntityContext : DbContext
    {
        public DataBaseEntityContext(DbContextOptions<DataBaseEntityContext> options) : base(options) { }

        public DbSet<AdminLogin> AdminLogin { set; get; }
        public DbSet<CompanyDetails> CompanyDetails { set; get; }
        public DbSet<Contract> Contract { set; get; }
        public DbSet<FeedBack> FeedBack { set; get; }
        public DbSet<EmpRegister> EmpRegister { set; get; }
        public DbSet<HospitalInfo> HospitalInfo { set; get; }
        public DbSet<Policies> Policies { set; get; }
        public DbSet<PoliciesonEmployees> PoliciesonEmployees { set; get; }
        public DbSet<PolicyApprovalDetails> PolicyApprovalDetails { set; get; }
        public DbSet<PolicyRequestDetails> PolicyRequestDetails { set; get; }
        public DbSet<PolicyTotalDescription> PolicyTotalDescription { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);            
        }
    }
}
