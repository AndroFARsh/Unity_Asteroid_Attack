//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by KSyndicate.CustomGenerators.Plugins.SingleValueComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial interface IViewPrefabEntity<TEntity> : Entitas.IEntity where TEntity : Entitas.IEntity  {

    Code.Common.View.EntityViewBehaviour ViewPrefab { get; }
    Code.Common.ViewPrefabComponent viewPrefab { get; }
    bool hasViewPrefab { get; }

    TEntity AddViewPrefab(Code.Common.View.EntityViewBehaviour newValue);
    TEntity ReplaceViewPrefab(Code.Common.View.EntityViewBehaviour newValue);
    TEntity RemoveViewPrefab();
}

public interface IViewPrefabEntity : IViewPrefabEntity<Entitas.IEntity> {}
