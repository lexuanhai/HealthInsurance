
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TECH.Data.DatabaseEntity;
using TECH.Models;
using TECH.Reponsitory;


namespace TECH.Service
{
    public interface IAdminLoginService
    {
        void Save();
        AdminLoginModelView Login(string username, string password);     
    }

    public class AdminLoginService : IAdminLoginService
    {
        private readonly IAdminLoginRepository _adminLoginRepository;
        private IUnitOfWork _unitOfWork;
        public AdminLoginService(IAdminLoginRepository adminLoginRepository,
            IUnitOfWork unitOfWork)
        {
            _adminLoginRepository = adminLoginRepository;
            _unitOfWork = unitOfWork;
        }       
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public AdminLoginModelView Login(string username, string password)
        {            
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
               var model = _adminLoginRepository.FindAll(e => e.UserName.Trim().ToLower() == username.Trim().ToLower() &&
                                                  e.PassWord.Trim().ToLower() == password.Trim().ToLower()).Select(m=> new AdminLoginModelView()
                                                  {
                                                      PassWord = m.PassWord,
                                                      UserName = m.UserName,
                                                  }).FirstOrDefault();
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }
    }
}
