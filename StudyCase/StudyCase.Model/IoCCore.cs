
using Castle.Windsor;

namespace StudyCase.Model
{
    public static class IoCCore
    {
        private static readonly IWindsorContainer container = new WindsorContainer();

        public static IWindsorContainer CastleInstance()
        {
            return container;
        }
        public static T Resolver<T>()
        {
            return container.Resolve<T>();
        }
    }
}
