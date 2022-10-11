
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
        //List<PoliciesModelView> GetPoliciesByEmployId(int employId);
        //List<PoliciesModelView> GetAllPolicies();
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
        //public List<PoliciesModelView> GetPoliciesByEmployId(int employId)
        //{
        //    if (employId > 0)
        //    {
        //        var model = _empRegisterRepository.FindAll().Where(e=>e.Empno == employId).FirstOrDefault();
        //        if (model != null && model.PolicyId > 0)
        //        {
        //            var data = _policiesRepository.FindAll().Where(p => p.PolicyId == model.PolicyId).Select(p=> new PoliciesModelView()
        //            {
        //                PolicyId = p.PolicyId,
        //                PolicyName = p.PolicyName,
        //                PolicyDesc = p.PolicyDesc,
        //                Amount = p.Amount,
        //                Emi = p.Emi,
        //                CompanyId = p.CompanyId,
        //                HospitalId = p.HospitalId,
        //            }).ToList();
        //            return data;
        //        }
        //    }
        //    return null;
        //}
        //public List<PoliciesModelView> GetAllPolicies()
        //{
        //    var data = _policiesRepository.FindAll().Select(p => new PoliciesModelView()
        //    {
        //        PolicyId = p.PolicyId,
        //        PolicyName = p.PolicyName,
        //        PolicyDesc = p.PolicyDesc,
        //        Amount = p.Amount,
        //        Emi = p.Emi,
        //        CompanyId = p.CompanyId,
        //        HospitalId = p.HospitalId,
        //    }).ToList();
        //    if (data != null && data.Count> 0)
        //    {
        //        foreach (var item in data)
        //        {
        //            if (item.CompanyId.HasValue && item.CompanyId.Value > 0)
        //            {
        //                item.CompanyDetails = _companyDetailsService.GetByid(item.CompanyId.Value);
        //            }
        //        }
        //    }
        //    return data;
        //}

    }
}
