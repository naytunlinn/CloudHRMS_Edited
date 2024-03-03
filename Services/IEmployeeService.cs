using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IEmployeeService
    {
        void Create(EmployeeViewModel employeeViewModel);

        IList<EmployeeViewModel> GetAll();

        EmployeeViewModel GetById(string id);

        void Update(EmployeeViewModel employeeViewModel);

        void Delete(string id);
    }
}