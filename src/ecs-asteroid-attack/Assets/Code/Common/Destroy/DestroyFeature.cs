using Code.Common.Destroy.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common.Destroy
{
  public sealed class DestroyFeature : Feature
  {
    public DestroyFeature(ISystemFactory systems)
    {
      Add(systems.Create<SelfDestructedCountDownMetaEntitySystem>());
      Add(systems.Create<SelfDestructedCountDownInputEntitySystem>());
      Add(systems.Create<SelfDestructedCountDownGameEntitySystem>());
      
      Add(systems.Create<CleanupReadyToDestroyMetaEntityViewSystem>());
      Add(systems.Create<CleanupReadyToDestroyInputEntityViewSystem>());
      Add(systems.Create<CleanupReadyToDestroyGameEntityViewSystem>());
      
      Add(systems.Create<CleanupReadyToDestroyMetaEntitySystem>());
      Add(systems.Create<CleanupReadyToDestroyInputEntitySystem>());
      Add(systems.Create<CleanupReadyToDestroyGameEntitySystem>());
    }
  }
}