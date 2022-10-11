
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
    public interface ICompanyDetailsService
    {
        void Save();
        int Add(CompanyDetailsModelView view);
        CompanyDetailsModelView GetByid(int id);
        List<CompanyDetailsModelView> GetAll();
    }

    public class CompanyDetailsService : ICompanyDetailsService
    {
        private readonly ICompanyDetailsRepository _companyDetailsRepository;
        private IUnitOfWork _unitOfWork;
        public CompanyDetailsService(ICompanyDetailsRepository companyDetailsRepository,
            IUnitOfWork unitOfWork)
        {
            _companyDetailsRepository = companyDetailsRepository;
            _unitOfWork = unitOfWork;
        }       
        public void Save()
        {
            _unitOfWork.Commit();
        }

        public CompanyDetailsModelView GetByid(int id)
        {
            var data = _companyDetailsRepository.FindAll(p => p.CompanyId == id).FirstOrDefault();
            if (data != null)
            {
                var model = new CompanyDetailsModelView()
                {
                    CompanyId = data.CompanyId,
                    CompanyName = data.CompanyName,
                    Address = data.Address,
                    Phone = data.Phone,
                    CompanyURL = data.CompanyURL
                };
                return model;
            }
            return null;
        }
        public int Add(CompanyDetailsModelView view)
        {
            try
            {
                if (view != null)
                {
                    var appUser = new CompanyDetails
                    {
                        CompanyName = view.CompanyName,
                        Address = view.Address,
                        Phone = view.Phone,
                        CompanyURL = view.CompanyURL
                    };
                    _companyDetailsRepository.Add(appUser);

                    Save();

                    return appUser.CompanyId;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;

        }
        public List<CompanyDetailsModelView> GetAll()
        {
            var data = _companyDetailsRepository.FindAll().Select(c=> new CompanyDetailsModelView()
            {
                CompanyId = c.CompanyId,
                CompanyName = c.CompanyName
            }).ToList();
            
            return data;
        }
    }
}
