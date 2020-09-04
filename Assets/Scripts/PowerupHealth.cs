using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerHealth>()) {
            if (other.gameObject.GetComponent<PlayerHealth>().healthUP()) {
                Destroy(this.gameObject);
            }
        }
    }
}
