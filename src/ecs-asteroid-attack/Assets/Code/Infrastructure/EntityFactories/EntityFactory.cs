using System;
using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Identifiers;
using Entitas;

namespace Code.Common.EntityFactories
{
  public class EntityFactory : IEntityFactory
  {
    private readonly Dictionary<Type, string> _entityTypeToContextName = new();
    private readonly Dictionary<string, IContext> _contextNameToContext;
    private readonly IIdProvider _idProvider;

    private EntityFactory(IIdProvider idProvider)
    {
      _idProvider = idProvider;
      _contextNameToContext = Contexts.sharedInstance.allContexts
        .ToDictionary(c => c.contextInfo.name, c => c);
    }

    public TEntity Create<TEntity>() where TEntity : class, IEntity
    {
      string name = GetContextName(typeof(TEntity));
      
      IContext<TEntity> context = _contextNameToContext[name] as IContext<TEntity>;
      
      TEntity entity = context?.CreateEntity();
      entity?.AddComponent(new IdComponent { Value = _idProvider.NextId });
      
      return entity;
    }

    private string GetContextName(Type type)
    {
      if (_entityTypeToContextName.TryGetValue(type, out string name)) return name;
      
      name = type.Name.Replace("Entity", "");
      _entityTypeToContextName.Add(type, name);
      return name;
    }
  }
}