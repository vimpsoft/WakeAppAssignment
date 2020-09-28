using UnityEngine;
using UnityEngine.XR.WSA.Input;

/// <summary>
/// Модель навигации определяет что конкретно мы делаем в плане навигации.
/// Стандартная стратегия такая - если мы управляем игроком - подчиняемся, иначе, а если видим противника - стреляем по нему
/// Также, раз этот класс объединяет стейты навигации - используем его аггрегатор всех
/// навигационных сообщений от всех стейтов
/// </summary>
public class PlayerNavigationModel : MonoBehaviour, INavigationModel
{
    public event MoveNavigationHandler OnMove;
    public event RotateNavigationHandler OnRotate;

    [SerializeField]
    private float _delayUntilStartAggroStrategy = 2f;

    [SerializeField]
    private ActorNavigationStateMachineModel _stateMachine;

    [SerializeField]
    private NavigationStateModelSerializableInterface _aggroState;
    [SerializeField]
    private NavigationStateModelSerializableInterface _playerControlledState;

    [SerializeField]
    private NavigationModelSerializableInterface _playerControlledNavigationModel;

    [SerializeField]
    private NavigationModelSerializableInterface[] _navigationModels;

    private float _timeCounter;

    private void Start()
    {
        _timeCounter = _delayUntilStartAggroStrategy;

        for (int i = 0; i < _navigationModels.Length; i++)
        {
            _navigationModels[i].Interface.OnMove += OnMove;
            _navigationModels[i].Interface.OnRotate += OnRotate;
        }

        //При любом инпуте от пользователя мы переключаемся на его стейт
        _playerControlledNavigationModel.Interface.OnMove += _ => setPlayerControlledState();
        _playerControlledNavigationModel.Interface.OnRotate += _ => setPlayerControlledState();

        void setPlayerControlledState()
        {
            _timeCounter = _delayUntilStartAggroStrategy;
            _stateMachine.SetState(_playerControlledState.Interface);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < _navigationModels.Length; i++)
        {
            _navigationModels[i].Interface.OnMove -= OnMove;
            _navigationModels[i].Interface.OnRotate -= OnRotate;
        }
    }

    private void Update()
    {
        _timeCounter -= Time.deltaTime;
        if (_timeCounter <= 0)
            _stateMachine.SetState(_aggroState.Interface);
    }
}
