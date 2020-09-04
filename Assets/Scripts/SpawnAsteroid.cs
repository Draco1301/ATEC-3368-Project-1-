using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{

    [SerializeField] GameObject astro;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; i++) {
            Instantiate(astro, new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300)), Quaternion.Euler(0, 0, 0), this.transform);
        }
    }
}
