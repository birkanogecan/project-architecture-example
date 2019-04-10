using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using StudyCase.Model;
using StudyCase.Model.ServiceAbstraction;
using StudyCase.Service.ServiceOperation;

namespace StudyCase.Service
{
    public class IoCServiceInit
    {
        public static void Initializer()
        {
            IoCCore.CastleInstance().Register(Component.For<IReservationService>().ImplementedBy<ReservationService>());
        }
    }
}
