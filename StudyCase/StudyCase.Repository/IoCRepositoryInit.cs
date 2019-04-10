using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using StudyCase.Model;
using StudyCase.Model.RepositoryAbstraction;
using StudyCase.Repository.RepositoryOperation;

namespace StudyCase.Repository
{
    public class IoCRepositoryInit
    {
        public static void Initializer()
        {
            IoCCore.CastleInstance().Register(Component.For(typeof(IGenericRepository<>))
            .ImplementedBy(typeof(GenericRepository<>))
            .LifeStyle.Transient);
        }
    }
}
