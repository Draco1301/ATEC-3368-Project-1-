using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killzone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        PlayerHealth PH = other.gameObject.GetComponent<PlayerHealth>();

        if (PH != null) {
            PH.InstantKill();
        }
    }
}
