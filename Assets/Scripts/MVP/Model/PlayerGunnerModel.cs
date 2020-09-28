using System;
using UnityEngine;

/// <summary>
/// Класс объединяет логику от различных источников стрельбы игрока
/// </summary>
public class PlayerGunnerModel : MonoBehaviour, IGunnerModel
{
    public event Action OnShoot;

    [SerializeField]
    private GunnerModelSerializableInterface[] _gunnerModels;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _gunnerModels.Length; i++)
            _gunnerModels[i].Interface.OnShoot += OnShoot;
    }
}
