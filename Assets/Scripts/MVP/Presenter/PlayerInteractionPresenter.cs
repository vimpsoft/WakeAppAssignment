using UnityEngine;

public class PlayerInteractionPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerInteractionModel _model;
    [SerializeField]
    private PlayerInteractionView _view;

    // Start is called before the first frame update
    void Start()
    {
        _view.OnKeyPressed += _model.ProcessKeyPress;
        _view.OnMouseMove += _model.ProcessMouseMove;
        _view.OnLmbClicked += _model.ProcessLmbPressed;
    }

    private void OnDestroy()
    {
        _view.OnKeyPressed -= _model.ProcessKeyPress;
        _view.OnMouseMove -= _model.ProcessMouseMove;
        _view.OnLmbClicked -= _model.ProcessLmbPressed;
    }
}
