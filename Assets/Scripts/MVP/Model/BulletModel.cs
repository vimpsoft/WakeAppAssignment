using System;
using UnityEngine;

public class BulletModel : MonoBehaviour
{
    [SerializeField]
    private FloatValue _lifeTime;
    [SerializeField]
    private FloatValue _damage;
    void Start() => Invoke("selfDestruct", _lifeTime.Value);
    private void selfDestruct() => Destroy(gameObject);
    internal void ProcessCollision(GameObject go)
    {
        go.GetComponent<ILivingThingModel>()?.ProcessDamage(_damage.Value);
        selfDestruct();
    }
}
