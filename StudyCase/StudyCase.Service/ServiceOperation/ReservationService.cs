using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using StudyCase.Model;
using StudyCase.Model.RepositoryAbstraction;
using StudyCase.Model.RepositoryModel;
using StudyCase.Model.ServiceAbstraction;
using StudyCase.Model.ServiceModel;

namespace StudyCase.Service.ServiceOperation
{
    public class ReservationService : IReservationService
    {
        private IGenericRepository<Reservation> _genericRepository;
        public ReservationService()
        {
            _genericRepository = IoCCore.Resolver<IGenericRepository<Reservation>>();
        }


        public void DeleteReservation(int reservationId)
        {
            Reservation reservation = _genericRepository.Find(x => x.Id == reservationId);
            reservation.IsDeleted = true;

            _genericRepository.Edit(reservation);
        }

        public ReservationResultModel AddReservation(int userId, string userMail, DateTime dateTime)
        {
            ReservationResultModel model = new ReservationResultModel();
            var reservationTemp = GetReservationsByDate(dateTime).Find(x => x.ReservationStartDate == dateTime);
            if (dateTime < DateTime.Today)
            {
                model.ResultText = "Reservation Date Is Outdated";
                model.Result = false;
            }
            else if (reservationTemp == null)
            {
                Reservation reservation = new Reservation();
                reservation.UserId = userId;
                reservation.ReservationStartDate = dateTime;
                reservation.IsDeleted = false;
                reservation.UserMail = userMail;
                int i = _genericRepository.Add(reservation);
                model.Result = true;
                model.ResultText = "Reservation Created Successfully";
            }
            else
            {
                model.ResultText = "Selected Reservation Time Is Not Enabled";
                model.Result = false;
            }

            return model;
        }

        public List<Reservation> GetReservationsByDate(DateTime dateTime)
        {
            DateTime dateMax = dateTime.AddDays(1);
            return _genericRepository.FindMany(x => x.ReservationStartDate >= dateTime && x.ReservationStartDate < dateMax && x.IsDeleted == false).ToList();
        }

    }
}
