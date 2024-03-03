using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repostories;

namespace CloudHRMS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public void Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var IsEmployeeCodeAlreadyExists = _employeeRepository.GetAll().Where(w => w.Code == employeeViewModel.Code).Any();
                if (IsEmployeeCodeAlreadyExists)
                {
                    throw new Exception("Code already exists in the system.");
                }
                //Data exchange from view model to data model
                var employee = new EmployeeEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = employeeViewModel.Code,
                    Name = employeeViewModel.Name,
                    Email = employeeViewModel.Email,
                    Phone = employeeViewModel.Phone,
                    DOB = employeeViewModel.DOB,
                    DOE = employeeViewModel.DOE,
                    Address = employeeViewModel.Address,
                    ProfilePicture = "uniqueFileName",
                    BasicSalary = employeeViewModel.BasicSalary,
                    Gender = employeeViewModel.Gender,
                    DepartmentId = employeeViewModel.DepartmentId,
                    PositionId = employeeViewModel.PositionId
                };
                _employeeRepository.Create(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string id)
        {
            _employeeRepository.Delete(id);
        }

        public IList<EmployeeViewModel> GetAll()
        {
            return _employeeRepository.GetAll().Select(
                 s => new EmployeeViewModel
                 {
                     Id = s.Id,
                     Code = s.Code,
                     Name = s.Name,
                     Email = s.Email,
                     Phone = s.Phone,
                     DOB = s.DOB,
                     DOE = s.DOE,
                     Address = s.Address,
                     ProfilePicture = "uniqueFileName",
                     BasicSalary = s.BasicSalary,
                     Gender = s.Gender,
                     DepartmentId = s.DepartmentId,
                     PositionId = s.PositionId
                 }).ToList();
        }

        public EmployeeViewModel GetById(string id)
        {
            var employeeEntity = _employeeRepository.GetById(id);
            return new EmployeeViewModel()
            {
                Id = employeeEntity.Id,
                Code = employeeEntity.Code,
                Name = employeeEntity.Name,
                Email = employeeEntity.Email,
                Phone = employeeEntity.Phone,
                DOB = employeeEntity.DOB,
                DOE = employeeEntity.DOE,
                Address = employeeEntity.Address,
                ProfilePicture = "uniqueFileName",
                BasicSalary = employeeEntity.BasicSalary,
                Gender = employeeEntity.Gender,
                DepartmentId = employeeEntity.DepartmentId,
                PositionId = employeeEntity.PositionId
            };
        }

        public void Update(EmployeeViewModel employeeViewModel)
        {
            var employee = new EmployeeEntity()
            {
                Id = employeeViewModel.Id,
                Code = employeeViewModel.Code,
                Name = employeeViewModel.Name,
                Email = employeeViewModel.Email,
                Phone = employeeViewModel.Phone,
                DOB = employeeViewModel.DOB,
                DOE = employeeViewModel.DOE,
                Address = employeeViewModel.Address,
                ProfilePicture = "uniqueFileName",
                BasicSalary = employeeViewModel.BasicSalary,
                Gender = employeeViewModel.Gender,
                DepartmentId = employeeViewModel.DepartmentId,
                PositionId = employeeViewModel.PositionId,
                ModifiedAt = DateTime.Now
            };
            _employeeRepository.Update(employee);
        }
    }
}