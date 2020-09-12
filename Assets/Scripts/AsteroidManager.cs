using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public static AsteroidManager Instance;
    [SerializeField] Asteroid bullet;
    Queue<Asteroid> targetQueue = new Queue<Asteroid>();

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    public void spawnBullet(Vector3 pos, Quaternion rot, int ricochet) {
        if (targetQueue.Count > 200) {
            return;
        }
        Asteroid b = Instantiate(bullet, pos, rot, this.transform);
        targetQueue.Enqueue(b);
        StartCoroutine(deleteBullet());
    }

    private IEnumerator deleteBullet() {

        yield return new WaitForSeconds(3);

        Asteroid delete = targetQueue.Dequeue();
        if (delete != null) {
            Destroy(delete.gameObject);
        }
    }
}
