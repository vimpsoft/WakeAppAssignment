using UnityEngine;

public class SomeGunModel : MonoBehaviour, IGunModel
{
    [SerializeField]
    private GameObject _bulletPrefab;

    public void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab);
        bullet.transform.position = transform.position;
    }
}
