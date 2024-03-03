using CloudHRMS.Models.DataModels;

namespace CloudHRMS.Repostories
{
    public interface IDailyAttendanceRepository
    {
        void Create(DailyAttendanceEntity dailyattendanceEntity);

        IList<DailyAttendanceEntity> GetAll();

        DailyAttendanceEntity GetById(string id);

        void Update(DailyAttendanceEntity dailyattendanceEntity);

        void Delete(string id);
    }
}