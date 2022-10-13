
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECH.Areas.Admin.Models.Search;
using TECH.Data.DatabaseEntity;
using TECH.Models;
using TECH.Reponsitory;
using TECH.Utilities;

namespace TECH.Service
{
    public interface IContractService
    {
        void Save();
        int Add(ContractModelView view);
    }

    public class ContractService : IContractService
    {
        private readonly IContractRepository _contractRepository;
        private IUnitOfWork _unitOfWork;
        public ContractService(IContractRepository contractRepository,
            IUnitOfWork unitOfWork)
        {
            _contractRepository = contractRepository;
            _unitOfWork = unitOfWork;
        }       
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public int Add(ContractModelView view)
        {
            try
            {
                if (view != null)
                {
                    var appPolicies = new Contract
                    {
                        EmailId = view.EmailId,
                        ContractNo = view.ContractNo,
                        Subject = view.Subject,
                        Message = view.Message
                    };
                    _contractRepository.Add(appPolicies);
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
