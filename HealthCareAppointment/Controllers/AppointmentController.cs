using HealthCareAppointment.HealthCare_BLL;
using HealthCareAppointment.HealthCare_BLL.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using System;

namespace HealthCareAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Appointmentdashboard()
        {
            var appointments = await _unitOfWork.Appointment.GetAllAppointments();
            return View(appointments);
        }

        // GET: Appointment
        public async Task<ActionResult> Appointment()
        {
            var appointment = new Appointment();
            var statelist = await _unitOfWork.States.GetAll();
            appointment.StateList = statelist.ToList();
            var locationlist = await _unitOfWork.Locations.GetAll();
            appointment.LocationList = locationlist.ToList();
            var doctorlist = await _unitOfWork.Doctors.GetAll();
            appointment.DoctorList = doctorlist.ToList();
            var patientlist = await _unitOfWork.Patient.GetAll();
            appointment.PatientList = patientlist.ToList();
            var timeslot = await _unitOfWork.TimeSlot.GetAll();
            appointment.TimeSlotList = timeslot.ToList();
            var specializationlist = await _unitOfWork.Specialization.GetAll();
            appointment.SpecializationList = specializationlist.ToList();
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AppointmentSave(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Appointment.Add(new Appointment()
                {
                    AppointmentDate = appointment.AppointmentDate,
                    StateId = appointment.StateId,
                    LocationId = appointment.LocationId,
                    DoctorId = appointment.DoctorId,
                    PatientId = appointment.PatientId,
                    TimeSlotId = appointment.TimeSlotId,
                    Status = 1,
                    SpecializationId = appointment.SpecializationId
                });
                _unitOfWork.Complete();

            }
            return RedirectToAction("Appointment");

        }

        public async Task<ActionResult> Edit(int id)
        {
            Appointment appointment = new Appointment();
            appointment = await _unitOfWork.Appointment.GetAppointmentById(id);
            var statelist = await _unitOfWork.States.GetAll();
            appointment.StateList = statelist.ToList();
            var locationlist = await _unitOfWork.Locations.GetAll();
            appointment.LocationList = locationlist.ToList();
            var doctorlist = await _unitOfWork.Doctors.GetAll();
            appointment.DoctorList = doctorlist.ToList();
            var patientlist = await _unitOfWork.Patient.GetAll();
            appointment.PatientList = patientlist.ToList();
            var timeslot = await _unitOfWork.TimeSlot.GetAll();
            appointment.TimeSlotList = timeslot.ToList();
            var specializationlist = await _unitOfWork.Specialization.GetAll();
            appointment.SpecializationList = specializationlist.ToList();
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Appointment appointment)
        {
            var appointmentresult = _unitOfWork.Appointment.GetAppointment(appointment.AppointmentId);
            appointmentresult.StateId = appointment.StateId;
            appointmentresult.LocationId = appointment.LocationId;
            appointmentresult.SpecializationId = appointment.SpecializationId;
            appointmentresult.DoctorId = appointment.DoctorId;
            appointmentresult.PatientId = appointment.PatientId;
            appointmentresult.TimeSlotId = appointment.TimeSlotId;
            appointmentresult.AppointmentDate = appointment.AppointmentDate;

            _unitOfWork.Complete();
            return RedirectToAction("Appointmentdashboard");

        }

        public ActionResult Deleteappointment(int id)
        {
            Appointment appointment = new Appointment();
            appointment =  _unitOfWork.Appointment.GetAppointment(id);
            _unitOfWork.Appointment.Remove(appointment);
            _unitOfWork.Complete();
            return RedirectToAction("Appointmentdashboard");

        }


    }
}