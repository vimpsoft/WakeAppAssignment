using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerInteractionModel), menuName = "WakeApp/" + nameof(PlayerInteractionModel), order = 0)]
/// <summary>
/// Этот класс у нас эмитит в систему инпут от пользователя.
/// </summary>
public class PlayerInteractionModel : ScriptableObject
{
    [SerializeField]
    private KeyCodeUnityEvent _onKeyPressed;
    [SerializeField]
    private Vector2UnityEvent _onMouseDelta;

    internal void ProcessKeyPress(KeyCode key) => _onKeyPressed.Invoke(key);
    internal void ProcessMouseMove(Vector2 delta) => _onMouseDelta.Invoke(delta);
}
