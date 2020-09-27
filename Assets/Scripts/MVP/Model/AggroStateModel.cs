using System;
using System.Linq;
using UnityEngine;

/// <summary>
/// Враги стреляют по принципу - если вижу врага в неком радиусе - стреляю
/// </summary>
public class AggroStateModel : MonoBehaviour, IGunnerModel, INavigationModel, INavigationStateModel
{
    public event Action OnShoot;
    public event MoveNavigationHandler OnMove;
    public event RotateNavigationHandler OnRotate;

    [SerializeField]
    private FloatValue _enemySightRadius;

    [SerializeField]
    private FactionMembersModel _fractionsRegistry;
    [SerializeField]
    private FactionMemberModel _myFractionHolder;

    public void UpdateState()
    {
        var allEnemies = _fractionsRegistry.GetAllFactionMembers(~_myFractionHolder.Faction & Faction.Everything);
        //Тут я использую линк просто для быстроты разработки. А вообще это не очень производительно.
        if (!allEnemies.Any())
            return;
        var allEnemiesInRange = allEnemies
            .OrderBy(enemy => Vector3.Distance(enemy.position, transform.position))
            .Where(enemy => Vector3.Distance(enemy.position, transform.position) <= _enemySightRadius.Value);
        if (!allEnemiesInRange.Any())
            return;
        OnRotate?.Invoke(Quaternion.LookRotation((allEnemiesInRange.First().position - transform.position).normalized).eulerAngles);
        OnShoot?.Invoke();
    }
}
