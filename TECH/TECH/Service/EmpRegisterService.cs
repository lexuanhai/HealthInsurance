
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
    public interface IEmpRegisterService
    {
        void Save();
        EmpRegisterModelView Login(string username, string password);
        EmpRegisterModelView GetByid(int id);
        bool Update(EmpRegisterModelView empRegisterModelView);
        bool UpdateChangePassword(int id,string newpassword);
        bool Deleted(int id);
        List<EmpRegisterModelView> GetAllEmployee();
        int Add(EmpRegisterModelView view);
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
        public bool UpdateChangePassword(int id, string newpassword)
        {
            var data = _empRegisterRepository.FindAll(p => p.Empno == id).FirstOrDefault();
            if (data != null)
            {
                data.PassWord = newpassword;
                _empRegisterRepository.Update(data);
                Save();
                return true;
            }
            return false;
        }
        public bool Update(EmpRegisterModelView view)
        {
            if (view != null && view.Empno > 0)
            {
                var dataServer = _empRegisterRepository.FindAll(p => p.Empno == view.Empno).FirstOrDefault();
                if (dataServer != null)
                {
                    dataServer.FirstName = view.FirstName;
                    dataServer.LastName = view.LastName;
                    dataServer.UserName = view.UserName;
                    dataServer.PassWord = view.PassWord;
                    dataServer.Address = view.Address;
                    dataServer.ContactNo = view.ContactNo;
                    dataServer.State = view.State;
                    dataServer.City = view.City;
                    _empRegisterRepository.Update(dataServer);
                    Save();
                    return true;
                }
            }
            return false;
           
        }

        public int Add(EmpRegisterModelView view)
        {
            try
            {
                if (view != null)
                {
                    var appUser = new EmpRegister
                    {
                        FirstName = view.FirstName,
                        LastName = view.LastName,
                        UserName = view.UserName,
                        PassWord = view.PassWord,
                        Address = view.Address,
                        ContactNo = view.ContactNo,
                        State = view.State,
                        City = view.City,
                        Designation = view.Designation,
                        JoinDate = view.JoinDate,
                        Salary = view.Salary
                };
                    _empRegisterRepository.Add(appUser);

                    Save();

                    return appUser.Empno;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 0;

        }

        public List<EmpRegisterModelView> GetAllEmployee()
        {
            var data = _empRegisterRepository.FindAll().Select(p => new EmpRegisterModelView()
            {
                Empno = p.Empno,
                LastName = p.LastName,
                ContactNo = p.ContactNo,
                Address = p.Address,
                JoinDate = p.JoinDate,
                Designation = p.Designation,
                Salary = p.Salary,
            }).ToList();            
            return data;
        }
        public bool Deleted(int id)
        {
            try
            {
                var dataServer = _empRegisterRepository.FindAll().Where(e=>e.Empno ==id).FirstOrDefault();
                if (dataServer != null)
                {
                    _empRegisterRepository.Remove(dataServer);
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
