using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCase.Model.RepositoryModel;
using StudyCase.Model.ServiceModel;

namespace StudyCase.Model.ServiceAbstraction
{
    public interface IReservationService
    {
        ReservationResultModel AddReservation(int userId, string userMail, DateTime dateTime);
        List<Reservation> GetReservationsByDate(DateTime dateTime);

        void DeleteReservation(int reservationId);
    }
}
