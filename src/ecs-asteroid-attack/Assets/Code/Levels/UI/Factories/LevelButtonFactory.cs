using Code.Common.Extensions;
using Code.Infrastructure.AssetManagement;
using Code.Levels.UI.LevelsButton;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code.Levels.UI.Factories
{
  public class LevelButtonFactory : ILevelButtonFactory
  {
    private const string LevelButtonPrefabPath = "Levels/LevelButton";
    
    private readonly IAssetProvider _assetProvider;
    private readonly IObjectResolver _objectResolver;
    
    public LevelButtonFactory(IAssetProvider assetProvider, IObjectResolver objectResolver)
    {
      _assetProvider = assetProvider;
      _objectResolver = objectResolver;
    }
    
    public LevelButtonUIView CreateButton(Transform at)
    {
      LevelButtonUIView prefab = _assetProvider.LoadAsset<LevelButtonUIView>(LevelButtonPrefabPath);
      return _objectResolver.Instantiate(prefab, at);
    }
  }
}