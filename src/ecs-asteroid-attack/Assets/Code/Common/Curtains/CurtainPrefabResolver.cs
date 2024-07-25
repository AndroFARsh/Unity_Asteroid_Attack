using Code.Common.Extensions;
using Code.Infrastructure.AssetManagement;
using VContainer;

namespace Code.Common.Curtains
{
  public static class CurtainPrefabResolver
  {
    private const string CurtainPrefabPath = "Common/Curtain";
    public static Curtain Resolver(IObjectResolver resolver)
    {
      IAssetProvider assetProvider = resolver.Resolve<IAssetProvider>();
      return assetProvider.LoadAsset<Curtain>(CurtainPrefabPath)
        .With(c => c.gameObject.SetActive(false));
    }
  }
}