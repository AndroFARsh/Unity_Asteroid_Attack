using Code.Infrastructure.StaticData;
using Code.Infrastructure.WindowManagement.Behaviours;
using Code.Infrastructure.WindowManagement.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.WindowManagement.Factories
{
  public class WindowFactory : IWindowFactory
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IObjectResolver _resolver;

    public WindowFactory(
      IStaticDataService staticDataService,
      IObjectResolver resolver)
    {
      _staticDataService = staticDataService;
      _resolver = resolver;
    }

    public IWindow CreateWindow(WindowName name, Transform parrent)
    {
      WindowConfig config = _staticDataService.GetWindowConfig(name);
      config.Prefab.gameObject.SetActive(false);

      return _resolver.Instantiate(config.Prefab, parrent);
    }
  }
}