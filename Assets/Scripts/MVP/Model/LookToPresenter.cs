using UnityEngine;

public class LookToPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("На что смотрим?")]
    private Transform _target;

    private void Update() => transform.LookAt(_target);
}
