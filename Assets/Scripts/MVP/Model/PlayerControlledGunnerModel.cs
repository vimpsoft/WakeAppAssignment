using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerControlledGunnerModel), menuName = "WakeApp/" + nameof(PlayerControlledGunnerModel), order = 0)]
public class PlayerControlledGunnerModel : ScriptableObject, IGunnerModel
{
    public event Action OnShoot;
    public void OnLBM() => OnShoot?.Invoke();
}
