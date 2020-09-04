using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    [SerializeField] GameObject _BombPowerup;
    // Start is called before the first frame update
    void Awake() {
        for (int i = 0; i < 50; i++) {
            Instantiate(_BombPowerup, new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300)), Quaternion.Euler(0, 0, 0), this.transform);
        }
    }
}
