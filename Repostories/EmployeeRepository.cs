﻿using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;

namespace CloudHRMS.Repostories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public void Create(EmployeeEntity employeeEntity)
        {
            _applicationDbContext.Employees.Add(employeeEntity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            if (null != id)
            {
                var employee = _applicationDbContext.Employees.Find(id);
                if (employee is not null)
                {
                    _applicationDbContext.Remove(employee);
                    _applicationDbContext.SaveChanges();
                }
            }
        }

        public IList<EmployeeEntity> GetAll()
        {
            return _applicationDbContext.Employees.ToList();
        }

        public EmployeeEntity GetById(string id)
        {
            return _applicationDbContext.Employees.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Update(EmployeeEntity employeeEntity)
        {
            _applicationDbContext.Employees.Update(employeeEntity);
            _applicationDbContext.SaveChanges();
        }
    }
}