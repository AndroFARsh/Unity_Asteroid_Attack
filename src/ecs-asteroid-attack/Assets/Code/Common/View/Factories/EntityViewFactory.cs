using Code.Infrastructure.AssetManagement;
using Entitas;
using UnityEditor;
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
    private readonly IEntityViewPool _pool;

    public EntityViewFactory(IObjectResolver objectResolver, IAssetProvider assetProvider, IEntityViewPool pool)
    {
      _objectResolver = objectResolver;
      _assetProvider = assetProvider;
      _pool = pool;
    }

    public IEntityView CreateViewForEntityFromPath(IEntity entity) => 
      CreateEntityView(entity, 
        _assetProvider.LoadAsset<EntityViewBehaviour>(entity.GetComponent<ViewPathComponent>().Value));

    public IEntityView CreateViewForEntityFromPrefab(IEntity entity) =>
      CreateEntityView(entity, entity.GetComponent<ViewPrefabComponent>().Value);

    public void Release(IEntityView view)
    {
      view.Release();
      
      view.GameObject.SetActive(false);
      view.GameObject.transform.position = _farAway;
      
      _pool.Release(view.PoolKey, view);
    }

    private IEntityView CreateEntityView(IEntity entity, EntityViewBehaviour prefab)
    {
      string poolKey = prefab.GetInstanceID().ToString();
      if (!_pool.TryRetain(poolKey, out IEntityView view))
      {
        view = _objectResolver.Instantiate(prefab,
          position: _farAway,
          rotation: Quaternion.identity);
        view.PoolKey = poolKey;
      }

      view.Retain(entity);

      return view;
    }
  }
}