using System;
using UnityEngine;

public class LivingThingModel : MonoBehaviour, ILivingThingModel
{
    public event Action OnDeath;
    [SerializeField]
    private FloatValue _initialLife;

    private float _currentLife;

    private void Start() => _currentLife = _initialLife.Value;

    public void ProcessDamage(float damage)
    {
        _currentLife = Mathf.Max(_currentLife - damage, 0);
        Debug.LogWarning($"Попадание! Осталось {_currentLife}");
        if (_currentLife == 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
