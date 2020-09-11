using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHealth : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<PlayerHealth>()) {
            other.gameObject.GetComponent<PlayerHealth>().healthUP();
            GameObject.FindObjectOfType<MotherShip>().addHealth(5);
            Destroy(this.gameObject);
            
        } else if (other.gameObject.GetComponent<MotherShip>()) {
            Destroy(this.gameObject);
        }
    }
}
