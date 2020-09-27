using System.Linq;
using UnityEngine;

/// <summary>
/// Модель навигации определяет что конкретно делает в плане навигации противник.
/// Стандартная стратегия такая - патрулируем, а если видим игрока - стреляем по нему
/// Также, раз этот класс объединяет стейты навигации - используем его аггрегатор всех
/// навигационных сообщений от всех стейтов
/// </summary>
public class EnemyNavigationModel : MonoBehaviour, INavigationModel
{
    public event MoveNavigationHandler OnMove;
    public event RotateNavigationHandler OnRotate;

    [SerializeField]
    private ActorNavigationStateMachineModel _stateMachine;

    [SerializeField]
    private NavigationStateModelSerializableInterface _patrolState;
    [SerializeField]
    private NavigationStateModelSerializableInterface _aggroState;

    [SerializeField]
    private NavigationModelSerializableInterface[] _navigationModels;

    [SerializeField]
    private FloatValue _enemySightRadius;

    [SerializeField]
    private FactionMembersModel _fractionsRegistry;
    [SerializeField]
    private FactionMemberModel _myFractionHolder;

    private void Start()
    {
        for (int i = 0; i < _navigationModels.Length; i++)
        {
            _navigationModels[i].Interface.OnMove += OnMove;
            _navigationModels[i].Interface.OnRotate += OnRotate;
        }
    }

    private void Update()
    {
        var allEnemies = _fractionsRegistry.GetAllFactionMembers(~_myFractionHolder.Faction & Faction.Everything);
        //Тут я использую линк просто для быстроты разработки. А вообще это не очень производительно.
        if (!allEnemies.Any())
            return;
        var allEnemiesInRange = allEnemies
            .OrderBy(enemy => Vector3.Distance(enemy.position, transform.position))
            .Where(enemy => Vector3.Distance(enemy.position, transform.position) <= _enemySightRadius.Value);
        _stateMachine.SetState(allEnemiesInRange.Any() ? _aggroState.Interface : _patrolState.Interface);
    }
}
