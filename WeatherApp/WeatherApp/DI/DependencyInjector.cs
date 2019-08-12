
using Unity;
using Unity.Lifetime;

namespace WeatherApp.DI
{
    public static class DependencyInjector
    {
        public static readonly UnityContainer unityContaner = new UnityContainer();
        public static void Register<I, T>() where T : I => unityContaner.RegisterType<I, T>(new ContainerControlledLifetimeManager());

        public static T Retrieve<T>() => unityContaner.Resolve<T>();
        public static void Inject<I>(I instance) => unityContaner.RegisterInstance<I>(instance);


    }
}
