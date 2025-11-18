namespace HRManagementSystem.Features.Common.HierarchyLookup;

public sealed record HierarchyLookupItem<TKey>(TKey Id, string Name) where TKey : struct;

