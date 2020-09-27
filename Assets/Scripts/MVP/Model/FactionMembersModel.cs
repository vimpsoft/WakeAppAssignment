using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(FactionMembersModel), menuName = "WakeApp/" + nameof(FactionMembersModel), order = 0)]
/// <summary>
/// Класс служит хранилищем всех членов какой-либо фракции - чтобы можно было быстро выполнять поиск по ним например
/// </summary>
public class FactionMembersModel : ScriptableObject
{
    private Dictionary<Faction, List<Transform>> _registry = new Dictionary<Faction, List<Transform>>();

    public void Register(Faction faction, Transform trans)
    {
        if (!_registry.ContainsKey(faction))
            _registry.Add(faction, new List<Transform>());
        if (!_registry[faction].Contains(trans))
            _registry[faction].Add(trans);
    }

    internal void Unregister(Faction faction, Transform trans)
    {
        if (!_registry.ContainsKey(faction))
            return;
        if (_registry[faction].Contains(trans))
            _registry[faction].Remove(trans);
    }

    internal IEnumerable<Transform> GetAllFactionMembers(Faction fraction) => _registry[fraction];
}
