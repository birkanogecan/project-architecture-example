using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyCase.Repository;
using StudyCase.Service;

namespace StudyCase.AppStarter
{
    public static class IoCBootstraper
    {
        public static void Bootstraper()
        {
            IoCRepositoryInit.Initializer();
            IoCServiceInit.Initializer();
        }
    }
}
