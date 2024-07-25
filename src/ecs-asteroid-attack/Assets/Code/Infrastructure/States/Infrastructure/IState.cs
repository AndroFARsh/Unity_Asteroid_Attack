using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.Infrastructure
{
  public interface IState
  {
    UniTask Exit();
  }
}