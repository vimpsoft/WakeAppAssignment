using System;
using UnityEngine;

/// <summary>
/// Вьюха у нас занимается отображением и отловом событий. В данном случае отображения нет, зато есть отлов
/// </summary>
public class PlayerInteractionView : MonoBehaviour
{
    public event Action<KeyCode> OnKeyPressed;
    public event Action<Vector2> OnMouseMove;
    public event Action OnLmbClicked;

    private Vector3 _oldMousePosition;

    private void Start()
    {
        _oldMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        //Тут по-моему нельзя тупо эмитить все коды какие есть, поэтому эмитим те, что нам интересны.
        if (Input.GetKey(KeyCode.W))
            OnKeyPressed?.Invoke(KeyCode.W);
        if (Input.GetKey(KeyCode.S))
            OnKeyPressed?.Invoke(KeyCode.S);
        if (Input.GetKey(KeyCode.A))
            OnKeyPressed?.Invoke(KeyCode.A);
        if (Input.GetKey(KeyCode.D))
            OnKeyPressed?.Invoke(KeyCode.D);

        var delta = _oldMousePosition - Input.mousePosition;
        if (delta != default)
        {
            OnMouseMove?.Invoke(new Vector2(delta.x, delta.y));
            _oldMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
            OnLmbClicked?.Invoke();
    }
}
