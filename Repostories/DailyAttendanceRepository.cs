using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;

namespace CloudHRMS.Repostories
{
    public class DailyAttendanceRepository : IDailyAttendanceRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DailyAttendanceRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public void Create(DailyAttendanceEntity dailyattendanceEntity)
        {
            _applicationDbContext.DailyAttendances.Add(dailyattendanceEntity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(string id)
        {
            if (null != id)
            {
                var dailyattendance = _applicationDbContext.DailyAttendances.Find(id);
                if (dailyattendance is not null)
                {
                    _applicationDbContext.Remove(dailyattendance);
                    _applicationDbContext.SaveChanges();
                }
            }
        }

        public IList<DailyAttendanceEntity> GetAll()
        {
            return _applicationDbContext.DailyAttendances.ToList();
        }

        public DailyAttendanceEntity GetById(string id)
        {
            return _applicationDbContext.DailyAttendances.Where(w => w.Id == id).SingleOrDefault();
        }

        public void Update(DailyAttendanceEntity dailyattendanceEntity)
        {
            _applicationDbContext.DailyAttendances.Update(dailyattendanceEntity);
            _applicationDbContext.SaveChanges();
        }
    }
}