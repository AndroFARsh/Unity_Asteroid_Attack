using Code.Infrastructure.AssetManagement;
using Entitas;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Common.View.Factories
{
  public class EntityViewFactory : IEntityViewFactory
  {
    private static readonly Vector3 _farAway = new(999, 999, 0);
    
    private readonly IObjectResolver _objectResolver;
    private readonly IAssetProvider _assetProvider;

    public EntityViewFactory(IObjectResolver objectResolver, IAssetProvider assetProvider)
    {
      _objectResolver = objectResolver;
      _assetProvider = assetProvider;
    }

    public IEntityView CreateViewForEntityFromPath(IEntity entity) => 
      CreateEntityView(entity, 
        _assetProvider.LoadAsset<EntityViewBehaviour>(entity.GetComponent<ViewPathComponent>().Value));

    public IEntityView CreateViewForEntityFromPrefab(IEntity entity) =>
      CreateEntityView(entity, entity.GetComponent<ViewPrefabComponent>().Value);

    private EntityViewBehaviour CreateEntityView(IEntity entity, EntityViewBehaviour prefab)
    {
      EntityViewBehaviour view = _objectResolver.Instantiate(prefab,
        position: _farAway,
        rotation: Quaternion.identity);
      
      view.Retain(entity);

      return view;
    }
  }
}