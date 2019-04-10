using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCase.Model.RepositoryModel;

namespace StudyCase.Repository
{
    public class ReservationContext : DbContext
    {
        public ReservationContext() : base("ReservationContext")
        {
            
        }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
