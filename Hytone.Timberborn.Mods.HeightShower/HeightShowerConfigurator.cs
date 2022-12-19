using Bindito.Core;
using TimberApi.ConfiguratorSystem;
using TimberApi.SceneSystem;

namespace Hytone.Timberborn.Mods.HeightShower
{
    public class HeightShowerConfigurator
    {
        [Configurator(SceneEntrypoint.InGame)]
        public class ScheduleSystemConfigurator : IConfigurator
        {
            public void Configure(IContainerDefinition containerDefinition)
            {
                containerDefinition.Bind<HeightShowerPanel>().AsSingleton();
            }
        }
    }
}
