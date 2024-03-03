using CloudHRMS.Models.ViewModels;
using CloudHRMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class DailyAttendanceController : Controller
    {
        private readonly IDailyAttendanceService _dailyattendanceService;

        public DailyAttendanceController(IDailyAttendanceService dailyattendanceService)
        {
            this._dailyattendanceService = dailyattendanceService;
        }

        public IActionResult List() //Show
        {
            return View(_dailyattendanceService.GetAll());
        }

        public IActionResult Edit(string id)
        {
            if (id != null)
            {
                return View(_dailyattendanceService.GetById(id));
            }
            else
            {
                return RedirectToAction("List");
            }
        }

        public IActionResult Delete(string id)
        {
            try
            {
                _dailyattendanceService.Delete(id);
                TempData["Info"] = "Save Successfully";
            }
            catch (Exception ex)
            {
                TempData["Info"] = "Error Occur When Deleting";
            }
            return RedirectToAction("List");
        }

        public IActionResult Entry() => View();

        [HttpPost]
        public IActionResult Entry(DailyAttendanceViewModel ui)
        {
            try
            {
                _dailyattendanceService.Create(ui);
                ViewBag.Info = "successfully save a record to the system";
            }
            catch (Exception ex)
            {
                ViewBag.Info = "Error occur when  saving a record  to the system";
            }
            return View();
        }
    }
}