using UnityEngine;

public class FactionMemberModel : MonoBehaviour
{
    public Faction Faction => _faction;
    [SerializeField]
    private Faction _faction;
    [SerializeField]
    private FactionMembersModel _registry;
    private void Start() => _registry.Register(_faction, transform);
}
