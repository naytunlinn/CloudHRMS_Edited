using CloudHRMS.Models.DataModels;

namespace CloudHRMS.Repostories
{
    public interface IEmployeeRepository
    {
        void Create(EmployeeEntity employeeEntity);

        IList<EmployeeEntity> GetAll();

        EmployeeEntity GetById(string id);

        void Update(EmployeeEntity employeeEntity);

        void Delete(string id);
    }
}