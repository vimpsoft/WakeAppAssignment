using UnityEngine;

public class EnemyNavigationModel : MonoBehaviour, INavigationModel
{
    public event MoveNavigationHandler OnMove;
    public event RotateNavigationHandler OnRotate;

    [SerializeField]
    private Transform[] _partolPoints;

    [SerializeField]
    private FloatValue _evemyMoveSpeed;

    private int _targetIndex;

    private void Update()
    {
        if (_partolPoints.Length < 2) //Патрулировать мы можем минимум между 2 точками, не меньше
            return;

        var from = _partolPoints[_targetIndex % _partolPoints.Length];
        var to = _partolPoints[(_targetIndex + 1) % _partolPoints.Length];

        var vector = to.position - from.position;

        if (Vector3.Dot(vector, to.position - transform.position) < 0) //Если мы зашли за цель, идем к следующей.
            _targetIndex++;

        OnRotate?.Invoke(Quaternion.LookRotation(vector.normalized).eulerAngles);
        OnMove?.Invoke(new Vector2(_evemyMoveSpeed.Value * Time.deltaTime, 0));
    }
}
