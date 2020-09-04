using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupBomb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerHealth>()) {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 30);
            foreach (var hitCollider in hitColliders) {
                hitCollider.GetComponent<Asteroid>()?.Die(); 
            }
            Destroy(this.gameObject);
        }
    }
}
