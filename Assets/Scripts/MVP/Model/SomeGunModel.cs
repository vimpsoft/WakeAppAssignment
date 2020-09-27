using UnityEngine;

public class SomeGunModel : MonoBehaviour, IGunModel
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private Transform _bulletSpawnTransform;
    [SerializeField]
    private Transform _rotationTransform;
    [SerializeField]
    private FloatValue _shootingDelay;

    private float _timeCounter;

    public void Shoot()
    {
        if (_timeCounter < 0)
        {
            var bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = _bulletSpawnTransform.position;
            bullet.transform.rotation = _rotationTransform.rotation;
            _timeCounter = _shootingDelay.Value;
        }
    }

    private void Update()
    {
        _timeCounter -= Time.deltaTime;
    }
}
