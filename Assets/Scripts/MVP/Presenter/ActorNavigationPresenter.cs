using UnityEngine;

public class ActorNavigationPresenter : MonoBehaviour
{
    [SerializeField]
    private ActorNavigationView _view;
    [SerializeField]
    private NavigationModelSerializableInterface _model;

    // Start is called before the first frame update
    void Start()
    {
        _model.Interface.OnMove += _view.Move;
        _model.Interface.OnRotate += _view.Rotate;
    }

    private void OnDestroy()
    {
        _model.Interface.OnMove -= _view.Move;
        _model.Interface.OnRotate -= _view.Rotate;
    }
}
