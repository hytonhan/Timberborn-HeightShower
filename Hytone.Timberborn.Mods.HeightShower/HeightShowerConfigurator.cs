using Bindito.Core;

namespace Hytone.Timberborn.Mods.HeightShower
{
    public class HeightShowerConfigurator
    {
        [Context("Game")]
        [Context("MapEditor")]
        public class ScheduleSystemConfigurator : IConfigurator
        {
            public void Configure(IContainerDefinition containerDefinition)
            {
                containerDefinition.Bind<HeightShowerPanel>().AsSingleton();
                containerDefinition.Bind<CursorTracker>().AsSingleton();
            }
        }
    }
}
