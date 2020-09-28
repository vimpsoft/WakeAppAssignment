using System;
using UnityEngine;

public class LaserAimModel : MonoBehaviour
{
    public event Action<Vector3, Vector3> OnLaserLinePointsUpdate;

    [SerializeField]
    private Transform _rotation;
    [SerializeField]
    private FloatValue _defaultLaserLength;

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(transform.position, _rotation.forward);
        var laserLength = _defaultLaserLength.Value;
        var hitInfo = default(RaycastHit);
        if (Physics.Raycast(ray, out hitInfo))
            laserLength = hitInfo.distance;
        OnLaserLinePointsUpdate?.Invoke(transform.position, transform.position + _rotation.forward * laserLength);
    }
}
