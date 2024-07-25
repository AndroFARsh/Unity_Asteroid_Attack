using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.UI
{
  public interface IWindowRoot
  {
    Transform Transform { get; }

    UniTask Show();
    UniTask Hide();
  }
}