using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Infrastructure.LifetimeScope.Installers
{
  public class SceneGameObjectInstaller : MonoBehaviourInstaller
  {
    [SerializeField] private bool _autoInjectSceneObjects = true;

    public override void Install(IContainerBuilder builder) 
    {
      if (_autoInjectSceneObjects)
        builder.RegisterBuildCallback(RegisterAllSceneObjects);
    }

    private void RegisterAllSceneObjects(IObjectResolver resolver)
    {
      foreach (GameObject go in gameObject.scene.GetRootGameObjects())
        resolver.InjectGameObject(go);
    }
  }
}