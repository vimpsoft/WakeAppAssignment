using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerGunnerModel), menuName = "WakeApp/" + nameof(PlayerGunnerModel), order = 0)]
public class PlayerGunnerModel : ScriptableObject, IGunnerModel
{
    public event Action OnShoot;
    public void OnLBM() => OnShoot?.Invoke();
}
