﻿
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
    public interface IEmpRegisterService
    {
        void Save();
        EmpRegisterModelView Login(string username, string password);
        EmpRegisterModelView GetByid(int id);
    }

    public class EmpRegisterService : IEmpRegisterService
    {
        private readonly IEmpRegisterRepository _empRegisterRepository;
        private IUnitOfWork _unitOfWork;
        public EmpRegisterService(IEmpRegisterRepository empRegisterRepository,
            IUnitOfWork unitOfWork)
        {
            _empRegisterRepository = empRegisterRepository;
            _unitOfWork = unitOfWork;
        }       
        public void Save()
        {
            _unitOfWork.Commit();
        }
        public EmpRegisterModelView Login(string username, string password)
        {
            
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
               var model =  _empRegisterRepository.FindAll(e => e.UserName.Trim().ToLower() == username.Trim().ToLower() &&
                                                  e.PassWord.Trim().ToLower() == password.Trim().ToLower()).Select(m=> new EmpRegisterModelView()
                                                  {
                                                      Empno = m.Empno,
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

        public EmpRegisterModelView GetByid(int id)
        {
            var data = _empRegisterRepository.FindAll(p => p.Empno == id).FirstOrDefault();
            if (data != null)
            {
                var model = new EmpRegisterModelView()
                {
                    Empno = data.Empno,
                    Designation = data.Designation,
                    JoinDate = data.JoinDate,
                    Salary = data.Salary,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    UserName = data.UserName,
                    PassWord = data.PassWord,
                    Address = data.Address,
                    ContactNo = data.ContactNo,
                    State = data.State,
                    Country = data.Country,
                    City = data.City,
                    PolicyStatus = data.PolicyStatus,
                    PolicyId = data.PolicyId
                };
                return model;
            }
            return null;
        }
    }
}