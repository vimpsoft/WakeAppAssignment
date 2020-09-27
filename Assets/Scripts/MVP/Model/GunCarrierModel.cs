using UnityEngine;

public class GunCarrierModel : MonoBehaviour
{
    [SerializeField]
    private GunModelSerializableInterface _gun;
    [SerializeField]
    private GunnerModelSerializableInterface _gunnerModel;

    private void Start() => _gunnerModel.Interface.OnShoot += _gun.Interface.Shoot;
}
