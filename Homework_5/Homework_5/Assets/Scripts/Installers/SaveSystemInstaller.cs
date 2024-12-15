using DI;
using SaveSystem;

namespace Installers
{
    public class SaveSystemInstaller : BaseInstaller
    {
        [Service(typeof(ISaveLoader))]
        private readonly ResourcesSaveLoader resourcesSaveLoader = new();

        [Service(typeof(ISaveLoader))]
        private readonly UnitsSaveLoader unitsSaveLoader = new();
    }
}