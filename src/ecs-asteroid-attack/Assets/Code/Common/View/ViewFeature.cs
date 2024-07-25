using Code.Common.View.Systems;
using Code.Infrastructure.Systems;

namespace Code.Common.View
{
  public sealed class ViewFeature : Feature
  {
    public ViewFeature(ISystemFactory systems)
    {
      Add(systems.Create<CreateMetaEntityViewFromPrefabSystem>());
      Add(systems.Create<CreateMetaEntityViewFromPathSystem>());
      
      Add(systems.Create<CreateGameEntityViewFromPrefabSystem>());
      Add(systems.Create<CreateGameEntityViewFromPathSystem>());
      
      Add(systems.Create<CreateInputEntityViewFromPrefabSystem>());
      Add(systems.Create<CreateInputEntityViewFromPathSystem>());
    }
  }
}