
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
    public interface IPoliciesonEmployeesService
    {
        void Save();
        int Add(PoliciesonEmployeesModelView view);
        bool Deleted(int id);
        PoliciesonEmployeesModelView GetPoliciesonEmployeesId(int PoliciesonEmployeesId,int requestId);
        //List<PoliciesModelView> GetAllPolicies();
    }

    public class PoliciesonEmployeesService : IPoliciesonEmployeesService
    {
        private readonly IPoliciesonEmployeesRepository _policiesonEmployeesRepository;
        private IUnitOfWork _unitOfWork;
        public PoliciesonEmployeesService(IPoliciesonEmployeesRepository policiesonEmployeesRepository,
            IUnitOfWork unitOfWork)
        {
            _policiesonEmployeesRepository = policiesonEmployeesRepository;
            _unitOfWork = unitOfWork;
        }
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public int Add(PoliciesonEmployeesModelView view)
        {
            try
            {
                if (view != null)
                {
                    var appPolicies = new PoliciesonEmployees
                    {                        
                        Empno = view.Empno,
                        PolcyId = view.PolcyId,
                        PolcyName = view.PolcyName,
                        PolicyAmount = view.PolicyAmount,
                        PolicyDuration = view.PolicyDuration,
                        PstartDate = view.PstartDate,
                        Penddate = view.Penddate,
                        CompanyId = view.CompanyId,
                        CompanyName = view.CompanyName,
                        Medical = view.Medical,
                        EMI = view.EMI
                    };
                    _policiesonEmployeesRepository.Add(appPolicies);
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
        public PoliciesonEmployeesModelView GetPoliciesonEmployeesId(int PoliciesonEmployeesId,int requestId)
        {
            if (PoliciesonEmployeesId > 0)
            {
                var data = _policiesonEmployeesRepository.FindAll().Where(p => p.Empno == PoliciesonEmployeesId).Select(p => new PoliciesonEmployeesModelView()
                {
                    Id = p.Id,
                    Empno = p.Empno,
                    PolcyId = p.PolcyId,
                    PolcyName = p.PolcyName,
                    PolicyAmount = p.PolicyAmount,
                    PolicyDuration = p.PolicyDuration,
                    PstartDate = p.PstartDate,
                    Penddate = p.Penddate,
                    CompanyId = p.CompanyId,
                    CompanyName = p.CompanyName,
                    Medical = p.Medical
                }).FirstOrDefault();
                data.RequestId = requestId;
                return data;
            }
            return null;
        }
        public bool Deleted(int id)
        {
            try
            {
                var dataServer = _policiesonEmployeesRepository.FindAll().Where(e => e.Id == id).FirstOrDefault();
                if (dataServer != null)
                {
                    _policiesonEmployeesRepository.Remove(dataServer);
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
