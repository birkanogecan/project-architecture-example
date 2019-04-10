using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyCase.UI.Models
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public string UserMail { get; set; }
        public DateTime ReservationStartDate { get; set; }

    }
}