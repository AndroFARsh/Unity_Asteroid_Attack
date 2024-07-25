using Entitas;
using UnityEngine;

namespace Code.Common.View
{
  public interface IEntityView
  {
    GameObject GameObject { get; }
    
    void Retain(IEntity entity);
    void Release();
  }
}