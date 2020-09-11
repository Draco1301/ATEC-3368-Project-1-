using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardVolume : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        PlayerMove playerShip = other.gameObject.GetComponent<PlayerMove>();

        if (playerShip != null) {
            playerShip.Kill();
        
        }
    }
}
