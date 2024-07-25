using System.Linq;
using Entitas;
using UnityEngine;

namespace Code.Common.View.Factories
{
  public abstract class SelfInitializedEntityView<TEntity> : MonoBehaviour 
    where TEntity : class, IEntity
  {
    [SerializeField] private EntityViewBehaviour _entityViewBehaviour;
    
    private void Awake()
    {
      if (_entityViewBehaviour == null)
        _entityViewBehaviour = GetComponentInChildren<EntityViewBehaviour>();

      Context<TEntity> context = GetContext();
      if (context != null)
        _entityViewBehaviour.Retain(context.CreateEntity());  
      
    }

    private static Context<TEntity> GetContext() => Contexts.sharedInstance.allContexts.OfType<Context<TEntity>>().FirstOrDefault();
  }
}