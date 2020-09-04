using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBatteries : MonoBehaviour
{
    [SerializeField] GameObject Batteries;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 3; i++) {
            Instantiate(Batteries, new Vector3(Random.Range(-280, 280), 0, Random.Range(-280, 280)), Quaternion.Euler(0, 0, 0), this.transform);

        }
    }
}
