using UnityEngine;

public class LaserAimPresenter : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private Transform _rotation;
    [SerializeField]
    private FloatValue _defaultLaserLength;
    [SerializeField]
    private FloatValue _laserStartWidth;
    [SerializeField]
    private FloatValue _laserEndWidth;

    private void Update()
    {
        var ray = new Ray(transform.position, _rotation.forward);
        var laserLength = _defaultLaserLength.Value;
        var hitInfo = default(RaycastHit);
        if (Physics.Raycast(ray, out hitInfo))
            laserLength = hitInfo.distance;
        _lineRenderer.startWidth = _laserStartWidth.Value;
        _lineRenderer.endWidth = _laserEndWidth.Value;
        _lineRenderer.SetPositions(new Vector3[2]
        {
            transform.position,
            transform.position + _rotation.forward * laserLength
        });
        //var pos = new List<Vector3>();
        //pos.Add(transform.position);
        //pos.Add(transform.position + _rotation.forward * laserLength);
        //_lineRenderer.startWidth = 1f;
        //_lineRenderer.endWidth = 1f;
        //_lineRenderer.SetPositions(pos.ToArray());
        //_lineRenderer.useWorldSpace = true;
    }
}
