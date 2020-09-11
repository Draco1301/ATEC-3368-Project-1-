using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerHealth>()) {
            Asteroid[] astros = GameObject.FindObjectsOfType<Asteroid>();
            foreach (Asteroid a in astros) {
                a.Die();
                PlayManager.instance.addScore(100);
            }
            Destroy(this.gameObject);
        } else if (other.gameObject.GetComponent<MotherShip>()) {
            Destroy(this.gameObject);
        }
    }
}
