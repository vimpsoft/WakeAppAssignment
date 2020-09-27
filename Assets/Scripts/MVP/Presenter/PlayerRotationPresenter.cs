using UnityEngine;

public class PlayerRotationPresenter : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed;

    private Vector3 _mousePosition;

    private void Start()
    {
        _mousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        var delta = _mousePosition - Input.mousePosition;
        if (delta == default)
            return;

    }
}
