using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StudyCase.Model;
using StudyCase.Model.RepositoryAbstraction;
using StudyCase.Model.RepositoryModel;
using StudyCase.Model.ServiceAbstraction;
using StudyCase.Model.ServiceModel;
using StudyCase.UI.Models;

namespace StudyCase.UI.Controllers
{
    public class HomeController : Controller
    {

        private IReservationService _reservationService;

        public HomeController()
        {
            _reservationService = IoCCore.Resolver<IReservationService>();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult AddReservation(string date, string time)
        {
            DateTime dateTime = string.IsNullOrEmpty(date) ? DateTime.Today : Convert.ToDateTime(date).Date;

            dateTime = dateTime.AddHours(Convert.ToDouble(time));
            ReservationResultModel result = _reservationService.AddReservation(Convert.ToInt32(User.Identity.GetUserId()), User.Identity.GetUserName(), dateTime);

            TempData["result"] = result.ResultText;

            return PartialView("_ReservationList", GetReservationModel(date));
        }

        public ActionResult GetReservationList(string date)
        {
            return PartialView("_ReservationList", GetReservationModel(date));
        }

        [Authorize]
        public ActionResult DeleteReservation(int reservationId, string date)
        {
            _reservationService.DeleteReservation(reservationId);
            return PartialView("_ReservationList", GetReservationModel(date));
        }

        private List<ReservationViewModel> GetReservationModel(string date)
        {
            string selectedDateTime;
            List<Reservation> reservationList = new List<Reservation>();
            if (string.IsNullOrEmpty(date))
            {
                reservationList = _reservationService.GetReservationsByDate(DateTime.Today);
                selectedDateTime = DateTime.Today.ToShortDateString();
            }
            else
            {
                reservationList = _reservationService.GetReservationsByDate(Convert.ToDateTime(date).Date);
                selectedDateTime = Convert.ToDateTime(date).ToShortDateString();
            }

            List<ReservationViewModel> model = new List<ReservationViewModel>();
            foreach (var item in reservationList)
            {
                ReservationViewModel reservation = new ReservationViewModel()
                {
                    ReservationStartDate = item.ReservationStartDate,
                    UserId = item.UserId,
                    ReservationId = item.Id,
                    UserMail = item.UserMail
                };


                model.Add(reservation);
            }

            ViewBag.SelectedDate = selectedDateTime;
            return model;
        }
    }
}