using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Asteroid astro = other.GetComponent<Asteroid>();
        if (astro != null) {
            astro.Die();
            PlayManager.instance.addScore(200);
        }
    }
}
