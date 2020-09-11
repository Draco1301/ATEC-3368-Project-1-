using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Vector3 spawnPoint;
    [SerializeField] float shootRate;
    private float shootTimer;
    public bool autoFire;
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if ((Input.GetKeyDown(KeyCode.Mouse0) && shootTimer < 0)) {
            shootTimer = shootRate;
            BulletManager.Instance.spawnBullet(this.transform.position + this.transform.rotation * spawnPoint, this.transform.rotation, BulletManager.ricochetLV);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(this.transform.position + this.transform.rotation * spawnPoint, 0.1f);
    }
}
