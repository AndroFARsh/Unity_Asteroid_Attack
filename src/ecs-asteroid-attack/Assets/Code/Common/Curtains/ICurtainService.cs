using Cysharp.Threading.Tasks;

namespace Code.Common.Curtains
{
  public interface ICurtainService
  {
    UniTask Show();

    UniTask Hide();
  }
}