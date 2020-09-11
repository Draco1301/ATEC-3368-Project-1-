using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;
    [SerializeField] Bullet bullet;
    Queue<Bullet> targetQueue = new Queue<Bullet>();
    public static int ricochetLV = 0;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    public void spawnBullet(Vector3 pos, Quaternion rot, int ricochet) {
        if(targetQueue.Count > 200){
            return;
        }
        Bullet b = Instantiate(bullet, pos, rot, this.transform);
        b.ricochet = ricochet;
        targetQueue.Enqueue(b);
        StartCoroutine(deleteBullet());
    }

    private IEnumerator deleteBullet() {

        yield return new WaitForSeconds(3);

        Bullet delete = targetQueue.Dequeue();
        if (delete != null) {
            Destroy(delete.gameObject);
        }
    }
}
