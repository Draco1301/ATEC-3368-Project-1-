using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBackground : MonoBehaviour {
    [SerializeField] GameObject starPrefab;
    float _size;
    Vector3 _pos;

    // Start is called before the first frame update
    void Start() {
        for (int i=0;i<3;i++) {
            for (int n = 0; n < 100; n++) {
                Instantiate(starPrefab, new Vector3(Random.Range(-100,100), -20-i*20, Random.Range(-100, 100)), Quaternion.Euler(0,0,0));
            }
        }
    }
}
