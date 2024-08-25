using Code.Common.View;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Common
{
  [Game, Meta, Input] public class IdComponent : IComponent { [PrimaryEntityIndex] public ulong Value; }
  [Game, Meta, Input] public class ReadyToCleanUpComponent : IComponent { }
  [Game, Meta, Input] public class SelfDestroyTimerComponent : IComponent { public float Value; }
  [Game, Meta, Input] public class ViewComponent : IComponent { public IEntityView Value; }
  [Game, Meta, Input] public class ViewPathComponent : IComponent { public string Value; }
  [Game, Meta, Input] public class ViewPrefabComponent : IComponent { public EntityViewBehaviour Value; }
  
  [Game, Meta, Input] public class ViewDDDComponent : IComponent { public EntityViewBehaviour Value; }
}
