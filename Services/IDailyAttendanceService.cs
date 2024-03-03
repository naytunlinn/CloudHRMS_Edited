using CloudHRMS.Models.ViewModels;

namespace CloudHRMS.Services
{
    public interface IDailyAttendanceService
    {
        void Create(DailyAttendanceViewModel dailyattendanceViewModel);

        IList<DailyAttendanceViewModel> GetAll();

        DailyAttendanceViewModel GetById(string id);

        void Update(DailyAttendanceViewModel dailyattendanceViewModel);

        void Delete(string id);
    }
}