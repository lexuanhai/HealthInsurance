
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TECH.Data.DatabaseEntity;
using TECH.Models;
using TECH.Reponsitory;

namespace TECH.Service
{
    public interface IFeedBackService
    {
        void Save();
        int Add(FeedBackModelView view);
    }

    public class FeedBackService : IFeedBackService
    {
        private readonly IFeedBackRepository _feedBackRepository;
        private IUnitOfWork _unitOfWork;
        public FeedBackService(IFeedBackRepository feedBackRepository,
            IUnitOfWork unitOfWork)
        {
            _feedBackRepository = feedBackRepository;
            _unitOfWork = unitOfWork;
        }       
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public int Add(FeedBackModelView view)
        {
            try
            {
                if (view != null)
                {
                    var appPolicies = new FeedBack
                    {
                        UserName = view.UserName,
                        EmailId = view.EmailId,
                        Feedback = view.Feedback,
                    };
                    _feedBackRepository.Add(appPolicies);
                    Save();
                    return appPolicies.Id;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;

        }      

    }
}
