﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Model.RepositoryModel
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserMail { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
