using UnityEngine;

public class FactionMemberModel : MonoBehaviour
{
    [SerializeField]
    private LivingThingModel _livingThing;
    public Faction Faction => _faction;
    [SerializeField]
    private Faction _faction;
    [SerializeField]
    private FactionMembersModel _registry;
    private void Start()
    {
        _registry.Register(_faction, transform);
        _livingThing.OnDeath += () => _registry.Unregister(_faction, transform);
    }
}
