using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] Bullet bullet;
    public int ricochet = 0;
    private Rigidbody _rb;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.velocity = transform.forward * _speed;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Astro")) {

            for (int i = 0; i < ricochet; i++) {
                BulletManager.Instance.spawnBullet(collision.transform.position, Quaternion.Euler(0, UnityEngine.Random.Range(0, 360), 0), ricochet - 1);
            }

            collision.gameObject.GetComponent<Asteroid>()?.Die();
            PlayManager.instance.addScore(100);
        }
        if (!collision.gameObject.tag.Equals("Player")) {
            Destroy(this.gameObject);
        }
    }
}
