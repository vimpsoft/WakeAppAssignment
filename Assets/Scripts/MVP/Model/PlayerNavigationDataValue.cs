using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerNavigationDataValue), menuName = "WakeApp/" + nameof(PlayerNavigationDataValue), order = 0)]
public class PlayerNavigationDataValue : ScriptableObject
{
    public event Action<Vector3> OnPositionUpdate;
    public event Action<Quaternion> OnRotationUpdate;
    public Vector3 Position
    {
        get => _position;
        set
        {
            if (_position != value)
            {
                _position = value;
                OnPositionUpdate?.Invoke(value);
            }
        }
    }
    private Vector3 _position;
    public Quaternion Rotation
    {
        get => _rotation;
        set
        {
            if (_rotation != value)
            {
                _rotation = value;
                OnRotationUpdate?.Invoke(value);
            }
        }
    }
    private Quaternion _rotation;
}