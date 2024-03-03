using System.ComponentModel.DataAnnotations.Schema;

namespace CloudHRMS.Models.DataModels
{
    public class DailyAttendanceEntity : BaseEntity
    {
        public DateOnly AttendanceDate { get; set; }
        public TimeOnly InTime { get; set; }
        public TimeOnly OutTime { get; set; }

        [ForeignKey("EmployeeId")]
        public string EmployeeId { get; set; }

        [ForeignKey("DepartmentId")]
        public string DepartmentId { get; set; }
    }
}