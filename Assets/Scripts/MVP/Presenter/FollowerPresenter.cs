using TMUnity;
using UnityEngine;

public class FollowerPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("Что преследовать-то собственно?")]
    private Transform _whatToFollow;

    [SerializeField, Tooltip("На сколько сдвигать будем?")]
    private Vector3 _offset;

    /*
     * Interpolator - это очень полезный класс, который я своровал из майкрософтвоского холотулкита, когда работал с очками Хололенс.
     * Очень полезный класс и под MIT лицензией.
     */
    [SerializeField]
    private Interpolator _interpolator;

    private void Update()
    {
        _interpolator.SetTargetPosition(_whatToFollow.position + _offset);
    }
}
