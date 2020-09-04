using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmHealthup : MonoBehaviour
{
    [SerializeField] GameObject _heathPowerup;
    // Start is called before the first frame update
    void Awake() {
        for (int i = 0; i < 50; i++) {
            Instantiate(_heathPowerup, new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300)), Quaternion.Euler(0, 0, 0), this.transform);
        }
    }
}
