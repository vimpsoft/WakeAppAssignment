using UnityEngine;

public class LaserAimPresenter : MonoBehaviour
{
    [SerializeField]
    private LaserAimModel _model;
    [SerializeField]
    private LaserAimView _view;

    private void Start() => _model.OnLaserLinePointsUpdate += _view.DrawLaserAim;
}
