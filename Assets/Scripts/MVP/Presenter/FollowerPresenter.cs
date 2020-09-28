using System.Net.NetworkInformation;
using TMUnity;
using UnityEngine;

public class FollowerPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("Что преследовать-то собственно?")]
    private Transform _whatToFollow;

    [SerializeField, Tooltip("На сколько сдвигать будем?")]
    private Vector3 _offset;
    [SerializeField, Tooltip("Записать в оффсет изначальное смещение объекта?")]
    private bool _applyInitialOffset;

    /*
     * Interpolator - это класс, который я своровал из майкрософтвоского холотулкита, когда работал с очками Хололенс.
     * Очень полезный класс и под MIT лицензией.
     */
    [SerializeField]
    private Interpolator _interpolator;

    private void Start()
    {
        if (_applyInitialOffset)
            //_offset = _whatToFollow.position - transform.position;
            _offset = _whatToFollow.InverseTransformPoint(transform.position);
    }

    private void Update()
    {
        if (_whatToFollow != null)
            _interpolator.SetTargetPosition(_whatToFollow.TransformPoint(_offset));
    }
}
