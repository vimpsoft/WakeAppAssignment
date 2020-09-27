using UnityEngine;

public class PlayerNavigationPresenter : MonoBehaviour
{
    [SerializeField]
    private PlayerNavigationView _view;
    [SerializeField]
    private PlayerNavigationModel _model;
    [SerializeField]
    private PlayerNavigationDataValue _navigationData;

    // Start is called before the first frame update
    void Start()
    {
        _model.OnMove += _view.Move;
        _model.OnRotate += _view.Rotate;

        _view.OnNavigate += (position, rotation) =>
        {
            _navigationData.Position = position;
            _navigationData.Rotation = rotation;
        };
    }
}
