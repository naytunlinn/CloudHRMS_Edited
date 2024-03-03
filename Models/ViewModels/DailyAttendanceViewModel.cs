using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudHRMS.Models.ViewModels
{
    public class DailyAttendanceViewModel
    {
        public string Id { get; set; }//edit/update,delete

        [Required]
        public DateOnly AttendanceDate { get; set; }

        [Required]
        public TimeOnly InTime { get; set; }

        [Required]
        public TimeOnly OutTime { get; set; }

        [Required]
        public string EmployeeId { get; set; }

        [Required]
        public string DepartmentId { get; set; }

        public string EmployeeInfo { get; set; }

        public string DepartmentInfo { get; set; }
    }
}