﻿using UnityEngine;

//объявляю делегаты явно, чтобы назвать параметры - так понятнее, чего от них ожидать
public delegate void MoveNavigationHandler(Vector2 localPositionDelta);
public delegate void RotateNavigationHandler(Vector3 eulerAngles);

[CreateAssetMenu(fileName = nameof(PlayerNavigationModel), menuName = "WakeApp/" + nameof(PlayerNavigationModel), order = 0)]
public class PlayerNavigationModel : ScriptableObject
{
    public event MoveNavigationHandler OnMove;
    public event RotateNavigationHandler OnRotate;

    [SerializeField]
    private FloatValue _moveSpeed;

    [SerializeField]
    private FloatValue _rotateSensitivity;
    [SerializeField]
    private FloatValue _minPitch;
    [SerializeField]
    private FloatValue _maxPitch;

    private Vector3 _currentRotation;

    public void OnInputKey(KeyCode keyCode)
    {
        var forwardValue = default(float);
        switch (keyCode)
        {
            case KeyCode.W:
                forwardValue = _moveSpeed.Value;
                break;
            case KeyCode.S:
                forwardValue = -_moveSpeed.Value;
                break;
        }

        var rightValue = default(float);
        switch (keyCode)
        {
            case KeyCode.A:
                rightValue = _moveSpeed.Value;
                break;
            case KeyCode.D:
                rightValue = -_moveSpeed.Value;
                break;
        }
        OnMove?.Invoke(new Vector2(forwardValue, rightValue));
    }

    public void OnMouseMove(Vector2 delta)
    {
        _currentRotation = new Vector3(Mathf.Clamp(_currentRotation.x + delta.y * _rotateSensitivity.Value, _minPitch.Value, _maxPitch.Value), _currentRotation.y - delta.x * _rotateSensitivity.Value, 0f);
        OnRotate?.Invoke(_currentRotation);
    }
}
