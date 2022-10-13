
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TECH.Areas.Admin.Models;
using TECH.Areas.Admin.Models.Search;
using TECH.Data.DatabaseEntity;
using TECH.Reponsitory;
using TECH.Utilities;

namespace TECH.Service
{
    public interface IPolicyRequestDetailsService
    {
        void Save();
        int Add(PolicyRequestDetailsModelView view);
        List<PolicyRequestDetailsModelView> GetAllPoliciesRequest();
        PolicyRequestDetailsModelView GetPoliciesRequestId(int Id);
        bool Deleted(int id);
    }

    public class PolicyRequestDetailsService : IPolicyRequestDetailsService
    {
        private readonly IPolicyRequestDetailsRepository _policyRequestDetailsRepository;
        private IUnitOfWork _unitOfWork;
        public PolicyRequestDetailsService(IPolicyRequestDetailsRepository policyRequestDetailsRepository,
            IUnitOfWork unitOfWork)
        {
            _policyRequestDetailsRepository = policyRequestDetailsRepository;
            _unitOfWork = unitOfWork;
        }       
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public int Add(PolicyRequestDetailsModelView view)
        {
            try
            {
                if (view != null)
                {
                    var policyRequestDetails = new PolicyRequestDetails
                    {
                        PoicyId = view.PoicyId,
                        RequestDate = view.RequestDate,
                        PolicyName = view.PolicyName,
                        Empno = view.Empno,
                        PolicyAmount = view.PolicyAmount,
                        Emi = view.Emi,
                        CompanyId = view.CompanyId,
                        CompanyName = view.CompanyName,
                        Status = view.Status
                    };
                    _policyRequestDetailsRepository.Add(policyRequestDetails);
                    Save();
                    return policyRequestDetails.RequestId;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;

        }

        public PolicyRequestDetailsModelView GetPoliciesRequestId(int id)
        {
            if (id > 0)
            {
                var data = _policyRequestDetailsRepository.FindAll().Where(p => p.RequestId == id).Select(p => new PolicyRequestDetailsModelView()
                {
                    RequestId = p.RequestId,
                    PoicyId = p.PoicyId,
                    RequestDate = p.RequestDate,
                    PolicyName = p.PolicyName,
                    Empno = p.Empno,
                    PolicyAmount = p.PolicyAmount,
                    Emi = p.Emi,
                    CompanyId = p.CompanyId,
                    CompanyName = p.CompanyName,
                    Status = p.Status
                }).FirstOrDefault();
                return data;
            }
            return null;
        }

        public List<PolicyRequestDetailsModelView> GetAllPoliciesRequest()
        {
            var data = _policyRequestDetailsRepository.FindAll().Select(p => new PolicyRequestDetailsModelView()
            {
                RequestId =p.RequestId,
                PoicyId = p.PoicyId,
                RequestDate = p.RequestDate,
                PolicyName = p.PolicyName,
                Empno = p.Empno,
                PolicyAmount = p.PolicyAmount,
                Emi = p.Emi,
                CompanyId = p.CompanyId,
                CompanyName = p.CompanyName,
                Status = p.Status
            }).ToList();
            
            return data;
        }
        public bool Deleted(int id)
        {
            try
            {
                var dataServer = _policyRequestDetailsRepository.FindAll().Where(e => e.RequestId == id).FirstOrDefault();
                if (dataServer != null)
                {
                    _policyRequestDetailsRepository.Remove(dataServer);
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return false;
        }

    }
}
