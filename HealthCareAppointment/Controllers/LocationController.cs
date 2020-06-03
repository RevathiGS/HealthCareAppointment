using HealthCareAppointment.HealthCare_BLL;
using HealthCareAppointment.HealthCare_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HealthCareAppointment.Controllers
{
    public class LocationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Location
        public async Task<ActionResult> Location()
        {
            var locations = new Locations();
            var statelist = await _unitOfWork.States.GetAll();
            locations.StateList = statelist.ToList();
            return View(locations);
        }

        //public ActionResult Location()
        //{
        //    var locations = new Locations();
        //    //locations.StateList =  _unitOfWork.States.GetStates.to
        //    return View(locations);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LocationSave()
        {
            //if (ModelState.IsValid)
            //{
            //    _unitOfWork.UserRegisters.Add(new UserRegisters()
            //    {
            //        UserName = registerObj.UserName,
            //        Password = registerObj.Password,
            //        ConfirmPassword = registerObj.ConfirmPassword,
            //        RoleId = registerObj.RoleId
            //    });
            //    _unitOfWork.Complete();

            //}
            return RedirectToAction("Login");

        }
    }
}