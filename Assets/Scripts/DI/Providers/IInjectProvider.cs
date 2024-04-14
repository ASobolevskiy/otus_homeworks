using ShootEmUp.DI;

namespace ShootEmUp.Providers
{
    public interface IInjectProvider
    {
        void Inject(ServiceLocator serviceLocator);
    }
}