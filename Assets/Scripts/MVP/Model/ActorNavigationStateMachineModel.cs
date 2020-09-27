using UnityEngine;

public class ActorNavigationStateMachineModel : MonoBehaviour
{
    private INavigationStateModel _currrentState;
    public void SetState(INavigationStateModel newState) => _currrentState = newState; //Нам вроде никаких действий по выходу\входу из стейта предпринимать не надо
    private void Update() => _currrentState?.UpdateState();
}
