using TMUnity;
using UnityEngine;

public class ActorNavigationView : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private Interpolator _interpolator;

    [SerializeField]
    private bool _useInterpolator;

    public void Move(Vector2 localPositionDelta)
    {
        var targetPosition = transform.position + transform.forward * localPositionDelta.x + transform.right * localPositionDelta.y;
        targetPosition.y = 0; //мы не хотим взлетать и погружаться под землю
        if (_useInterpolator)
            _interpolator.SetTargetPosition(targetPosition);
        else
            transform.position = targetPosition;
    }

    public void Rotate(Vector3 rotation)
    {
        if (_useInterpolator)
            _interpolator.SetTargetRotation(Quaternion.Euler(rotation));
        else
            transform.rotation = Quaternion.Euler(rotation);
    }
}
