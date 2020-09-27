using System;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public event Action<GameObject> OnCollided;
    public void Move(float speed) => transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    //private void OnCollisionEnter(Collision collision) => OnCollided?.Invoke(collision.gameObject);
    private void OnTriggerEnter(Collider other) => OnCollided?.Invoke(other.gameObject);
}
