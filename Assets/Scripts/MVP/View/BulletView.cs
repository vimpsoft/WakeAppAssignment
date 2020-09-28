using System;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public event Action<GameObject> OnCollided;

    [SerializeField]
    private Rigidbody _riginBody;

    //public void Move(float speed) => transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    public void Push(float speed) => _riginBody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    private void OnTriggerEnter(Collider other) => OnCollided?.Invoke(other.gameObject);
}
