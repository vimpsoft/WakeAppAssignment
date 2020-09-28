using UnityEngine;

public class LaserAimView : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;
    [SerializeField]
    private FloatValue _laserStartWidth;
    [SerializeField]
    private FloatValue _laserEndWidth;

    internal void DrawLaserAim(Vector3 point1, Vector3 point2)
    {
        _lineRenderer.startWidth = _laserStartWidth.Value;
        _lineRenderer.endWidth = _laserEndWidth.Value;
        _lineRenderer.SetPositions(new Vector3[2] { point1, point2 });
    }
}
