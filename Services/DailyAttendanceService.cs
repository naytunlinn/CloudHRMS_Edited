using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Repostories;

namespace CloudHRMS.Services
{
    public class DailyAttendanceService : IDailyAttendanceService
    {
        private readonly IDailyAttendanceRepository _dailyattendanceRepository;

        public DailyAttendanceService(IDailyAttendanceRepository dailyattendanceRepository)
        {
            this._dailyattendanceRepository = dailyattendanceRepository;
        }

        public void Create(DailyAttendanceViewModel dailyattendanceViewModel)
        {
            try
            {
                //var IsDailyAttendanceCodeAlreadyExists = _dailyattendanceRepository.GetAll().Where(w => w.Code == dailyattendanceViewModel.Code).Any();
                //if (IsDailyAttendanceCodeAlreadyExists)
                //{
                //    throw new Exception("Code already exists in the system.");
                //}
                //Data exchange from view model to data model
                var dailyattendance = new DailyAttendanceEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    AttendanceDate = dailyattendanceViewModel.AttendanceDate,
                    InTime = dailyattendanceViewModel.InTime,
                    OutTime = dailyattendanceViewModel.OutTime,
                    DepartmentId = dailyattendanceViewModel.DepartmentId,
                    EmployeeId = dailyattendanceViewModel.EmployeeId,
                };
                _dailyattendanceRepository.Create(dailyattendance);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(string id)
        {
            _dailyattendanceRepository.Delete(id);
        }

        public IList<DailyAttendanceViewModel> GetAll()
        {
            return _dailyattendanceRepository.GetAll().Select(
                 s => new DailyAttendanceViewModel
                 {
                     Id = s.Id,
                     AttendanceDate = s.AttendanceDate,
                     InTime = s.InTime,
                     OutTime = s.OutTime,
                     DepartmentId = s.DepartmentId,
                     EmployeeId = s.EmployeeId,
                 }).ToList();
        }

        public DailyAttendanceViewModel GetById(string id)
        {
            var dailyattendanceEntity = _dailyattendanceRepository.GetById(id);
            return new DailyAttendanceViewModel()
            {
                Id = dailyattendanceEntity.Id,
                AttendanceDate = dailyattendanceEntity.AttendanceDate,
                InTime = dailyattendanceEntity.InTime,
                OutTime = dailyattendanceEntity.OutTime,
                DepartmentId = dailyattendanceEntity.DepartmentId,
                EmployeeId = dailyattendanceEntity.EmployeeId,
            };
        }

        public void Update(DailyAttendanceViewModel dailyattendanceViewModel)
        {
            var dailyattendance = new DailyAttendanceEntity()
            {
                Id = dailyattendanceViewModel.Id,
                AttendanceDate = dailyattendanceViewModel.AttendanceDate,
                InTime = dailyattendanceViewModel.InTime,
                OutTime = dailyattendanceViewModel.OutTime,
                DepartmentId = dailyattendanceViewModel.DepartmentId,
                EmployeeId = dailyattendanceViewModel.EmployeeId,
                ModifiedAt = DateTime.Now
            };
            _dailyattendanceRepository.Update(dailyattendance);
        }
    }
}