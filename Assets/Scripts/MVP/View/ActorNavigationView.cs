using TMUnity;
using UnityEngine;

public class ActorNavigationView : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private Interpolator _interpolator;

    public void Move(Vector2 localPositionDelta)
    {
        var targetPosition = transform.position + transform.forward * localPositionDelta.x + transform.right * localPositionDelta.y;
        targetPosition.y = 0; //мы не хотим взлетать и погружаться под землю
        _interpolator.SetTargetPosition(targetPosition);
    }

    public void Rotate(Vector3 rotation) => _interpolator.SetTargetRotation(Quaternion.Euler(rotation));
}
