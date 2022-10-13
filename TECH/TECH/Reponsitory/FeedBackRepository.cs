using Microsoft.EntityFrameworkCore;
using System;
using TECH.Data.DatabaseEntity;

namespace TECH.Reponsitory
{
    public interface IFeedBackRepository : IRepository<FeedBack>
    {

    }

    public class FeedBackRepository : EFRepository<FeedBack>, IFeedBackRepository
    {
        public FeedBackRepository(DataBaseEntityContext context) : base(context)
        {
        }
    }
}
