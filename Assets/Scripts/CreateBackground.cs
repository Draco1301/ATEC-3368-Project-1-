using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackground : MonoBehaviour {
    [SerializeField] GameObject starPrefab;

    // Start is called before the first frame update
    void Start() {
        for (int i=0;i<5;i++) {
            for (int n = 0; n < 100; n++) {
                Instantiate(starPrefab, new Vector3(Random.Range(-350, 350), -20-i*20, Random.Range(-350, 350)), Quaternion.Euler(0,0,0), this.transform);
            }
        }
    }
}
